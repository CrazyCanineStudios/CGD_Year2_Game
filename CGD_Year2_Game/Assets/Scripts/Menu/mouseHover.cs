using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseHover : MonoBehaviour {

	void Start () {
		GetComponent<Renderer> ().material.color = Color.white;
	}

	void OnMouseEnter() {
		GetComponent<Renderer> ().material.color = Color.gray;
	}

	void OnMouseExit() {
		GetComponent<Renderer> ().material.color = Color.white;
	}
}