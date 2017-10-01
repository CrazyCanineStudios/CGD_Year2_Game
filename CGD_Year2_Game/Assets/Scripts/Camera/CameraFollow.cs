using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Written by Kenneth Yorke on 01.10.2017
    // code adapted from the Unity Survival Shooter Tutorial Series
    // https://unity3d.com/learn/tutorials/projects/survival-shooter-tutorial

    public Transform target;
    [Range(0,10)] public float smoothing = 5f;

    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - target.position;
    }

    private void FixedUpdate()
    {
        Vector3 camPositionTarget = target.position + offset;
        transform.position = Vector3.Lerp(this.transform.position, camPositionTarget, smoothing * Time.deltaTime);
    }
}
