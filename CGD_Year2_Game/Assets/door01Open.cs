using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door01Open : MonoBehaviour {

	public GameObject trigger;
	public GameObject door;

	private float doorClosed;
	private float doorOpen;

	void Start(){
		door = GameObject.Find ("prop_door01 (8)");
		trigger = GameObject.Find ("trigger01");
		trigger.SetActive (false);
	}

	void OnTriggerEnter(Collider trigger01)
	{
		if (trigger01.tag == "Trigger")
			trigger.SetActive (true);
	}
}
