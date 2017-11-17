using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunPosition : MonoBehaviour {

    Vector3 idlePosition;
    Vector3 idleRotation;
    Vector3 runPosition;
    Vector3 runRotation;

    // Use this for initialization
    void Awake () {
        idlePosition = this.transform.localPosition;
        idleRotation = this.transform.localEulerAngles;
        runPosition = new Vector3(0.181f, 0.295f, -0.014f);
        runRotation = new Vector3(-44.854f, -108.237f, -64.55901f);
	}

    public void setGunRunningPosition()
    {
        Debug.Log("Running");
        //this.transform.localPosition = runPosition;
        this.transform.localPosition = runPosition;
        this.transform.localEulerAngles = runRotation;
    }
    public void setGunidlePosition()
    {
        Debug.Log("Idle");
        this.transform.localPosition = idlePosition;
        this.transform.localEulerAngles = idleRotation;
    }
}
