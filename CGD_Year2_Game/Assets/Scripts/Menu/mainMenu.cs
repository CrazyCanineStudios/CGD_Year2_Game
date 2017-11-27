using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMenu : MonoBehaviour {

	public bool isStart;
	public bool isQuit;

	void OnMouseUp() {
		if (isStart) {
			UnityEngine.SceneManagement.SceneManager.LoadScene ("Level 03");
		}
		if (isQuit) {
			Application.Quit ();
		}
	}
}
