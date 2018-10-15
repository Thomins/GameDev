using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShutOffCamera : MonoBehaviour {

    public float CountDownTime = 10f;
    public bool IsMonitoring = false;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if(IsMonitoring == true)
        {
            CountDownTime -= Time.deltaTime;
            if(CountDownTime < 0 && IsMonitoring == true)
            {
                IsMonitoring = false;
                CountDownTime = 10f;
            }
        }
	}

    public void StartMonitor(string positionOfScreen)
    {
        IsMonitoring = true;
        if (positionOfScreen.Equals("Top-Right"))
        {
            gameObject.GetComponent<Camera>().rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
        }
        else if (positionOfScreen.Equals("Top-Left"))
        {
            gameObject.GetComponent<Camera>().rect = new Rect(0f, 0.5f, 0.5f, 0.5f);
        }
        else if (positionOfScreen.Equals("Bottom-Right"))
        {
            gameObject.GetComponent<Camera>().rect = new Rect(0f, 0.5f, 0.5f, 0.5f);
        }
        else if (positionOfScreen.Equals("Bottom-Left"))
        {
            gameObject.GetComponent<Camera>().rect = new Rect(0f, 0f, 0.5f, 0.5f);
        }

    }
}
