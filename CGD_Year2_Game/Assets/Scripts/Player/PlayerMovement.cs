using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    // Written by Kenneth Yorke on 01.10.2017
    // Code adapted from the Unity Survival Shooter Tutorial Series
    // https://unity3d.com/learn/tutorials/projects/survival-shooter-tutorial

    [Range(1, 10)] public float playerSpeed = 6f;

    //private Rigidbody playerRigidbody;
    private Animator anim;
    private int groundMask;
    private float camRayLength = 100f;
    public bool intro = true;
    public float introTime = 11f;
    public float health = 100;
    public GameObject starting;
    public GameObject gun;
    private void Awake()
    {
        groundMask = LayerMask.GetMask("Ground");
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Death")
        {
            this.transform.position = starting.transform.position;
        }
        else if (other.tag == "Enemies")
        {
            other.GetComponent<EnemyMovement>().canChase = false;
            other.GetComponent<EnemyMovement>().timetilLChase = 3f;
            other.GetComponent<EnemyMovement>().waiting = true;
           if (health > 0 )
            {
                this.GetComponent<ImpactReciever>().AddImpact(new Vector3(40, 0, 0), 40);
                this.health -= 25;
                Debug.Log("player hurt");
            }
            if (health <= 0)
            {
                ParticleSystem exp = GetComponent<ParticleSystem>();
                exp.Play();
                Destroy(exp, exp.duration);
                anim.SetTrigger("Die");
                intro = true;
                introTime = 5f;
            }
        }
    }
    private void FixedUpdate()
    {
        float downUp = Input.GetAxisRaw("DownUp");
        if (intro)
        {
            introTime -= Time.deltaTime;
            if (introTime <= 0)
            {
                intro = false;
                if (health <= 0)
                {
                    SceneManager.LoadScene("Level 03");
                }
            }
        }
        if (intro == false)
        {
            Animating(downUp);
            Move(downUp);
            Turning();
        }
    }

    private void Move(float downUp)
    {
        if (downUp>0)
        {
            transform.position += transform.forward.normalized * Time.deltaTime * playerSpeed;
        }
        else if (downUp<0)
        {
            transform.position -= transform.forward.normalized * Time.deltaTime * playerSpeed;
        }
    }

    private void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit groundHit;

        if (Physics.Raycast(camRay, out groundHit, camRayLength, groundMask))
        {
            Vector3 playerToMouse = groundHit.point - transform.position;
            playerToMouse.y = 0f;
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            //Debug.Log(playerToMouse);
            if ((playerToMouse.x <-0.2) || (playerToMouse.x > 0.7))
            {
                //playerRigidbody.MoveRotation(newRotation);
                transform.rotation = newRotation;
            }     
        }
    }
    private void Animating(float downUp)
    {
        bool walking = downUp != 0f;
        bool isJumping = anim.GetBool("isJumping");
        if ((walking) && (!isJumping))
        {
            gun.GetComponent<gunPosition>().setGunRunningPosition();
        }
        else if (!walking)
        {
            gun.GetComponent<gunPosition>().setGunidlePosition();
        }
        if (isJumping)
        {
            gun.GetComponent<gunPosition>().setGunidlePosition();
        }
        anim.SetBool("IsWalking", walking);
        anim.SetFloat("downUp", downUp);
    }
}
