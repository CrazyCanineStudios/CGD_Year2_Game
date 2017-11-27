using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{

    CharacterController controller;
    private Animator anim;
    float vSpeed;
    float grav = 7.0f;
    float jumpHeight = 3.5f;
    float airjump = 2;
    float airjumpMax = 2;
    float airJumpHeight = 4.5f;
    public bool canGlide;
    float timetillGlide = 1.8f;
    public GameObject jetpack;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (this.GetComponent<PlayerMovement>().intro == false)
        {
            if (controller.isGrounded)
            {
                anim.SetBool("isJumping", false);
                anim.SetBool("Jetpack", false);
                canGlide = true;
                timetillGlide = 1.8f;
                airjump = airjumpMax;
                vSpeed = -grav * Time.deltaTime;
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    anim.SetBool("isJumping", true);
                    vSpeed = jumpHeight;
                }
            }
            else if ((!controller.isGrounded) && (airjump > 1))
            {
                vSpeed -= grav * Time.deltaTime;
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    anim.SetBool("isJumping", true);
                    vSpeed = airJumpHeight;
                    airjump -= 1;
                }
            }
            else if ((!controller.isGrounded) && (airjump == 1))
            {
                vSpeed -= grav * Time.deltaTime;
                if (canGlide)
                {
                    if (Input.GetKey(KeyCode.LeftControl))
                    {
                        glide();
                    }
                    else if (Input.GetKeyUp(KeyCode.LeftControl))
                    {
                        anim.SetBool("Jetpack", false);
                        vSpeed -= grav * Time.deltaTime;
                        canGlide = false;
                        jetpack.SetActive(false);
                    }
                    else
                    {
                        vSpeed -= grav * Time.deltaTime;
                    }
                }
            }
            else
            {
                vSpeed -= grav * Time.deltaTime;
            }

            Vector3 moveVector = Vector3.zero;
            moveVector.x = 0;
            moveVector.y = vSpeed;
            moveVector.z = 0;
            controller.Move(moveVector * Time.deltaTime);
        }
    }

    private void glide()
    {
        anim.SetBool("Jetpack", true);
        vSpeed = 1.5f;
        jetpack.SetActive(true);
        timetillGlide -= Time.deltaTime;
        if (timetillGlide < 0.0f)
        {
            anim.SetBool("Jetpack", false);
            vSpeed = -grav * Time.deltaTime;
            canGlide = false;
            jetpack.SetActive(false);
        }
    }
}
