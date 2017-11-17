using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveTextController : MonoBehaviour {

    public Text text;
    public string objective;
    public float timetillfade = 3;
    // Use this for initialization
    void Start () {
        text = this.GetComponent<Text>();  
    }
	
	// Update is called once per frame
	void Update () {
        text.text = objective;
        timetillfade -= Time.deltaTime;
        if (timetillfade < 0.0f)
        {
            text.text = "";
        }
	}
    public void changeText(string objectiveText, float timeTill)
    {
        GetComponent<AudioSource>().Play();
        objective = objectiveText;
        timetillfade = timeTill;
    }
}
