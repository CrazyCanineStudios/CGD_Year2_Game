using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveTextController : MonoBehaviour {

    public Text text;
    public float timetillfade = 3;
    // Use this for initialization
    void Start () {
        text = this.GetComponent<Text>();
        text.text = "Get to the Control Room";
    }
	
	// Update is called once per frame
	void Update () {
        timetillfade -= Time.deltaTime;
        if (timetillfade < 0.0f)
        {
            text.text = "";
        }
	}
}
