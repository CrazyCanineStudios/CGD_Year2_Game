using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour {

    public float bulletSpeed = 1000;
    public float timeTillDestroyed = 1.2f;
    // Use this for initialization
    void Start () {
		
	}
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
        Debug.Log("Hit something");
    }
    // Update is called once per frame
    void Update () {
        transform.position += transform.up.normalized * Time.deltaTime * bulletSpeed;

        timeTillDestroyed -= Time.deltaTime;
        if (timeTillDestroyed < 0.0f)
        {
            Destroy(gameObject);
        }
    }
}
