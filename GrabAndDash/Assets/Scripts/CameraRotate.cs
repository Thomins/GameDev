using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour {

    public float RoatationSpeed = 0.1f;

    float startAngle;

    // Use this for initialization
    void Start () {
        startAngle = transform.rotation.eulerAngles.y;
	}

    // Update is called once per frame
    void Update()
    {
        float currentAngle = transform.rotation.eulerAngles.y;
        if ((currentAngle - startAngle) <= -20 || (currentAngle - startAngle) >= 20)
        {
            RoatationSpeed *= -1;
        }
        transform.eulerAngles = new Vector3(10, transform.rotation.eulerAngles.y + RoatationSpeed, 0);
    }
}
