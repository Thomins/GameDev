using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addTimePowerUp : MonoBehaviour {

    countdown addMoreTime;
    public float newTime = 10f;


    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
            //GameObject.GetComponent<countdown>().timer += newTime;
        }
    }

    public void Pickup(Collider player)
    {
        Destroy(gameObject);
    }
}
