using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Written by Kenneth Yorke on 01.10.2017
    // Code adapted from the Unity Survival Shooter Tutorial Series
    // https://unity3d.com/learn/tutorials/projects/survival-shooter-tutorial

    [Range(1, 10)] public float playerSpeed = 6f;

    private Vector3 movement;
    private Rigidbody playerRigidbody;
    private Animator anim;
    private int groundMask;
    private float camRayLength = 100f;
    public bool dancing = false;
    public float dancingTime = 10f;
    public float atDance;
    public GameObject starting;

    private void Awake()
    {
        groundMask = LayerMask.GetMask("Ground");
        playerRigidbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Death")
        {
            this.transform.position = starting.transform.position;
        }
    }
    private void FixedUpdate()
    {
        float downUp = Input.GetAxisRaw("DownUp");

        Animating(downUp);
        Move(downUp);
        Turning();
        Dancing();


        if (dancing && Time.time > atDance)
        {
            dancing = false;
            playerSpeed = 5;
            Debug.Log("Dance Finished");
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
                playerRigidbody.MoveRotation(newRotation);
            }
            
        }
    }
    private void Animating(float downUp)
    {
        bool walking = downUp != 0f;
        anim.SetBool("IsWalking", walking);
        anim.SetFloat("downUp", downUp);
    }
    private void Dancing()
    {
        if ((Input.GetKey(KeyCode.K) && (dancing == false)))
        {
            anim.SetTrigger("Dance");
            playerSpeed = 0;
            atDance = Time.time + dancingTime;
            dancing = true;
        }
    }
}
