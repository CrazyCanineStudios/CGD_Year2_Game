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
    private int groundMask;
    private float camRayLength = 100f;

    private void Awake ()
    {
        groundMask = LayerMask.GetMask("Ground");
        playerRigidbody = GetComponent<Rigidbody> ();
    }

    private void FixedUpdate ()
    {
        float leftRight = Input.GetAxisRaw ("LeftRight");
        float downUp = Input.GetAxisRaw ("DownUp");

        Move (leftRight, downUp);
        Turning ();

    }

    private void Move (float leftRight, float downUp)
    {
        movement.Set (leftRight, 0f, downUp);
        movement = movement.normalized * playerSpeed * Time.deltaTime;
        playerRigidbody.MovePosition (transform.position + movement);
    }

    private void Turning ()
    {
        Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
        RaycastHit groundHit;

        if (Physics.Raycast (camRay, out groundHit, camRayLength, groundMask))
        {
            Vector3 playerToMouse = groundHit.point - transform.position;
            playerToMouse.y = 0f;
            Quaternion newRotation = Quaternion.LookRotation (playerToMouse);
            playerRigidbody.MoveRotation (newRotation);
        }
    }
}
