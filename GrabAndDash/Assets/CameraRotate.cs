using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour {

    public float RoatationSpeed = 0.1f;
    bool right = false;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (transform.rotation.eulerAngles.y <= 120 || transform.rotation.eulerAngles.y >= 160)
        {
            RoatationSpeed *= -1;
        }
        transform.eulerAngles = new Vector3(10, transform.rotation.eulerAngles.y + RoatationSpeed, 0);
    }
}
