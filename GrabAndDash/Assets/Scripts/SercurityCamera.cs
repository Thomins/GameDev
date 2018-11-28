using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class CameraProperties
{
    [Tooltip("Camera On/Off")]
    public bool Power;
    [Tooltip("Speed of the camera rotaion. 0 for no rotaion.\n0.1 for best results.")]
    public float Rotation;
    [Tooltip("Time to switch out of the camera.")]
    private float CameraTimer;

}

[System.Serializable]
public class Detection
{
    [Tooltip("UI Text field to show if the player is detected by the camera.")]
    public Text DetectionStatus;
    [Tooltip("Boolean to show if the player has been detected.")]
    public bool PlayerDetected;
}

public class SercurityCamera : MonoBehaviour {

    public CameraProperties properties;
    public Detection detection;

    float startAngle;
    private Camera camera;
    private GameObject player;
    private Text detectedText;

	// Use this for initialization
	void Start () {

        startAngle = transform.rotation.eulerAngles.y;
        camera = gameObject.GetComponent<Camera>();
        player = GameObject.FindGameObjectWithTag("Player");

    }
	
	// Update is called once per frame
	void Update () {

        if (properties.Power)
        {
            camera.enabled = properties.Power;

            //RotateCamera();

            if (Targeting())
            {
                detection.DetectionStatus.text = "Intruder Detected";
                detection.PlayerDetected = true;
            }
            else
            {
                detection.DetectionStatus.text = "";
                detection.PlayerDetected = false;
            }
        }

	}

    void RotateCamera ()
    {
        float currentAngle = transform.rotation.eulerAngles.y;

        if ((currentAngle - startAngle) <= -20 || (currentAngle - startAngle) >= 20)
        {
            properties.Rotation *= -1;
        }

        transform.eulerAngles = new Vector3(10, transform.rotation.eulerAngles.y + properties.Rotation, 0);
    }

    bool Targeting()
    {
        Vector3 targetDirection = (player.transform.position - gameObject.transform.position);
        float angleToPlayer = (Vector3.Angle(gameObject.transform.forward, targetDirection));

        Vector3 screenPoint = camera.WorldToViewportPoint(player.transform.position + (Vector3.up * 1.25f));
        bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;

        RaycastHit hit = new RaycastHit();

        //Debug.Log(gameObject.name + " " + (int)angleToPlayer + " " + (int)(camera.fieldOfView - 10));
        //Debug.Log(onScreen + "\n==================================");

        if (onScreen)
        {
            if (angleToPlayer < camera.fieldOfView)
            {
                if (Physics.Raycast(this.gameObject.transform.position, targetDirection + (Vector3.up * 1.25f), out hit))
                {
                    //Debug.Log("We have hit some object.");

                    if (hit.collider.gameObject.tag.Equals("Player"))
                    {
                        //Debug.Log("We hit the player object");

                        Debug.DrawRay(this.gameObject.transform.position, targetDirection + (Vector3.up * 1.25f), Color.green);

                        return true;

                        //if (Mathf.Abs(targetDir.x) <= 15f && Mathf.Abs(targetDir.y) <= 15f && Mathf.Abs(targetDir.z) <= 15f)
                        //{
                        //    //Debug.DrawRay(this.gameObject.transform.position, targetDir, Color.blue);
                        //    return true;
                        //}
                    }
                }
            }
        }
        return false;
    }
}
