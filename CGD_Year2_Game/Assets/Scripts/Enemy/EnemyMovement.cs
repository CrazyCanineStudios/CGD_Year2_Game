using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float distanceToPlayer;
    public float sight = 5;

    Transform player;
    UnityEngine.AI.NavMeshAgent nav;

	void Awake () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        distanceToPlayer = player.transform.position.x -2 - this.transform.position.x;
        if ((distanceToPlayer < sight) && (distanceToPlayer > -12))
        {
            nav.SetDestination(player.position);
        }
        else
        {
            //do nothing
        }
        Debug.Log(player.position);

	}
}
