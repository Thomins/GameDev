using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDisplay : MonoBehaviour {

    public bool Rotation;
    public float RotationSpeed = 0.1f;
	
	// Update is called once per frame
	void Update () 
    {
        if (Rotation)
        {
            transform.eulerAngles = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + RotationSpeed, transform.rotation.eulerAngles.z);
        }
    }
}
