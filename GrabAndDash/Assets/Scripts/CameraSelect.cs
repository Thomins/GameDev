using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSelect : MonoBehaviour {

    GameObject[] sceneCameras;

    public List<GameObject> camerasWithView = new List<GameObject>();

	// Use this for initialization
	void Start () {
        sceneCameras = GameObject.FindGameObjectsWithTag("Camera");
	}
	
	// Update is called once per frame
	void Update () {
        camerasWithView.Clear();
		foreach(GameObject obj in sceneCameras)
        {
            if (obj.GetComponent<Detection>().isDetected)
            {
                Debug.Log(obj.name + " has located the player object");
                if (camerasWithView.Find(camObject => camObject.name == obj.name) == null)
                {
                    camerasWithView.Add(obj);
                }
            }
            
        }
        Debug.Log(camerasWithView.Count);
	}
}
