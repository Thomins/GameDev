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
        /*
        camerasWithView.Clear();
		foreach(GameObject obj in sceneCameras)
        {
            //if (obj.GetComponent<Detection>().isDetected)
            //{
                Debug.Log(obj.name + " has located the player object");
                if (camerasWithView.Find(camObject => camObject.name == obj.name) == null)
                {
                    camerasWithView.Add(obj);
                }
            //}
        }
        RandomCameraSelection();
        Debug.Log(camerasWithView.Count);
        */
	}

    void RandomCameraSelection()
    {
        //for(int i = 0; i < 4; i++)
        //{
        //    if (camerasWithView.Count < i) { break; }
        //    if (i == 0)
        //    {
        //        camerasWithView[Random.Range(0, camerasWithView.Count)].GetComponent<ShutOffCamera>().StartMonitor("Top-Left");
        //    }
        //    else if (i == 1)
        //    {
        //        camerasWithView[Random.Range(0, camerasWithView.Count)].GetComponent<ShutOffCamera>().StartMonitor("Top-Right");
        //    }
        //    else if (i == 2)
        //    {
        //        camerasWithView[Random.Range(0, camerasWithView.Count)].GetComponent<ShutOffCamera>().StartMonitor("Bottom-Right");
        //    }
        //    else if (i == 3)
        //    {
        //        camerasWithView[Random.Range(0, camerasWithView.Count)].GetComponent<ShutOffCamera>().StartMonitor("Bottom-Left");
        //    }
        //}
    }
}
