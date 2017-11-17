using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveTrigger : MonoBehaviour
{

    public GameObject objectiveText;
    public string newText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            objectiveText.GetComponent<ObjectiveTextController>().changeText(newText, 3);
            Destroy(this.gameObject);
            Debug.Log("Objective changed");
        }
    }
}