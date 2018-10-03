using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Detection : MonoBehaviour {

    public GameObject player;
    public Camera cam;
    public Text uiTextAlert;

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        if (IsInView (this.gameObject, player)) 
        {
            Debug.DrawLine(cam.transform.position, player.GetComponentInChildren<Renderer> ().bounds.center, Color.red);
            //Debug.Log ("In view of " + cam.name);
            uiTextAlert.text = "Intruder Detected";
        } else {
            uiTextAlert.text = "";
        }

    }

    private bool IsInView (GameObject origin, GameObject toCheck) {
        Vector3 pointOnScreen = cam.WorldToScreenPoint (toCheck.GetComponentInChildren<Renderer> ().bounds.center);
        // Debug.DrawLine (cam.transform.position, toCheck.GetComponentInChildren<Renderer> ().bounds.center, Color.red);
        //Is in front
        //if (pointOnScreen.z < 0) {
        //    //Debug.Log("Behind: " + toCheck.name);
        //    return false;
        //}

        //Is in FOV
        //if ((pointOnScreen.x < 0) || (pointOnScreen.x > Screen.width) ||
        //    (pointOnScreen.y < 0) || (pointOnScreen.y > Screen.height)) {
        //    //Debug.Log("OutOfBounds: " + toCheck.name);
        //    return false;
        //}

        RaycastHit hit;
        Vector3 heading = toCheck.transform.position - origin.transform.position;
        Vector3 direction = heading.normalized; // / heading.magnitude;

        if (Physics.Linecast (cam.transform.position, toCheck.GetComponentInChildren<Renderer> ().bounds.center, out hit)) {
            if (hit.transform.name != toCheck.name) {
                /* -->
                Debug.DrawLine(cam.transform.position, toCheck.GetComponentInChildren<Renderer>().bounds.center, Color.red);
                Debug.LogError(toCheck.name + " occluded by " + hit.transform.name);
                */
                //Debug.Log(toCheck.name + " occluded by " + hit.transform.name);
                return false;
            }
        }

        return true;
    }
}