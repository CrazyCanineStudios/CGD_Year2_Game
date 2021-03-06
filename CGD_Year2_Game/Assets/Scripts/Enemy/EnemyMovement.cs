﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float distanceToPlayer;
    public float sight = 5;
    public int health = 3;
    public float timetilLChase = 0;
    public bool waiting = true;
    public bool canChase = true;

    Transform player;
    UnityEngine.AI.NavMeshAgent nav;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Bullet")
        {
            if (health > 0){
                Debug.Log("OW I'm Hit");
                health -= 1;
                Destroy(other);
            }
            else
            {
				//Get Death explosion and play it
				ParticleSystem exp = GetComponent<ParticleSystem>();
				exp.Play ();

                Debug.Log("I'm dead");
                Destroy(other.gameObject);
				Destroy(gameObject, exp.duration);
            }
        }
    }
    void Awake () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (waiting)
        {
            timetilLChase -= Time.deltaTime;
            if (timetilLChase <= 0)
            {
                canChase = true;
                waiting = false;
            }
        }

        distanceToPlayer = player.transform.position.x -2 - this.transform.position.x;
        if ((distanceToPlayer < sight) && (distanceToPlayer > -12))
        {
            if (canChase)
            {
                nav.SetDestination(player.position);
            }
        }
        else
        {
            //Do nothing
        }

	}
}
