using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {

    public float RoatationSpeed = 0.1f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.eulerAngles = new Vector3(-30, transform.rotation.eulerAngles.y + RoatationSpeed, 0);
    }
}
