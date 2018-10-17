using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class acquireDonut : MonoBehaviour {

    public GameObject player;
    public float distance;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(gameObject.transform.position.x - player.transform.position.x <= distance &&
            gameObject.transform.position.z - player.transform.position.z <= distance)
        {
            //delete object
            Destroy(gameObject);
        }
	}
}
