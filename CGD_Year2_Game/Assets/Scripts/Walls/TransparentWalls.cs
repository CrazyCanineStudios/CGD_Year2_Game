using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentWalls : MonoBehaviour
{
    // Written by Kenneth Yorke on 01.10.2017

    public GameObject player;
    public float distanceToPlayer;
    public Color originalColor;
    public Color transparentColor;

	void Awake () {
        originalColor = this.GetComponent<Renderer>().material.color;
        transparentColor = originalColor;
        transparentColor.a = .28f;
    }
	
	void Update () {
        distanceToPlayer = player.transform.position.z - this.transform.position.z;
        if (distanceToPlayer <= 14)
        {
            this.GetComponent<Renderer>().material.color = transparentColor;
        }
        else if (distanceToPlayer > 14)
            {
            this.GetComponent<Renderer>().material.color = originalColor;
            
        }
	}
}
