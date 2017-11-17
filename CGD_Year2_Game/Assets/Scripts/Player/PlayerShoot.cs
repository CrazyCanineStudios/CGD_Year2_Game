using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    public GameObject bullet;
    public GameObject spawn;
    public float recharge = 0f;
    public float rechargeTime = 1f;
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        recharge -= Time.deltaTime;

        if (recharge < 0)
        {
            recharge = 0;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (recharge <= 0)
            {
                GameObject bullet2 = Instantiate(bullet, spawn.transform, false);
                bullet2.name = "Bullet";
                bullet2.transform.parent = null;
                recharge = rechargeTime;
            }
        }
    }
}
