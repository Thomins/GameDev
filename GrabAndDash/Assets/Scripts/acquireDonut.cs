using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class acquireDonut : MonoBehaviour {

    public GameObject player;
    public float distance;
	
	// Update is called once per frame
	void Update () {
        if (Mathf.Abs(gameObject.transform.position.x) - Mathf.Abs(player.transform.position.x) <= distance &&
            Mathf.Abs(gameObject.transform.position.z) - Mathf.Abs(player.transform.position.z) <= distance)
        {
            //delete object
            Destroy(gameObject);
        }
	}
}
