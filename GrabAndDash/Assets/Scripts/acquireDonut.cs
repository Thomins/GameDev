using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class acquireDonut : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision with " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player has come in range of Doughnut.");
        }
    }

}
