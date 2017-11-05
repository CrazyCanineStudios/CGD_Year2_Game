using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentWalls : MonoBehaviour
{
    // Written by Kenneth Yorke on 01.10.2017

    public GameObject player;
    public float distanceToPlayer;
    public float distanceForward = 2;
    public float distanceBack = -2;
    public float alpha = .98f;
    public Color originalColor;
    public Color transparentColor;

	void Awake () {
        originalColor = this.GetComponent<Renderer>().material.color;
        transparentColor = originalColor;
        transparentColor.a = alpha;
    }
	
	void Update () {
        distanceToPlayer = player.transform.position.x - this.transform.position.x;
        if ((distanceToPlayer >distanceBack) && (distanceToPlayer<distanceForward))
        {
            this.GetComponent<Renderer>().material.color = transparentColor;
            Debug.Log("Transparent Wall");
        }
        else 
        {
            this.GetComponent<Renderer>().material.color = originalColor;
            Debug.Log("Normal Wall");
        }
        
	}
}
