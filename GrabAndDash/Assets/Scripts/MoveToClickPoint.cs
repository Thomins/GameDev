// MoveToClickPoint.cs
using UnityEngine;
using UnityEngine.AI;

public class MoveToClickPoint : MonoBehaviour
{
    public GameObject arrow;

    NavMeshAgent agent;

    GameObject[] cameras;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        cameras = GameObject.FindGameObjectsWithTag("Camera");
    }

    void Update()
    {   
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            foreach (GameObject cam in cameras)
            {
                if(cam.GetComponent<Toggle>().cameraSwitch == true)
                {
                    Vector3 POSITION_CENTER_CAMERA = cam.GetComponent<Camera>().ScreenToViewportPoint(Input.mousePosition);
                    if ((POSITION_CENTER_CAMERA.x >= 0.0 && POSITION_CENTER_CAMERA.y >= 0.0) && (POSITION_CENTER_CAMERA.x <= 1.0 && POSITION_CENTER_CAMERA.y <= 1.0))
                    {
                        if (Physics.Raycast(cam.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition), out hit, 100))
                        {
                            Debug.Log(hit.point);
                            Debug.Log(agent.transform.position);
                            Debug.Log(Mathf.Abs(hit.point.x - agent.transform.position.x));
                            if ((Mathf.Abs(hit.point.x - agent.transform.position.x)) <= 5 && Mathf.Abs((hit.point.z - agent.transform.position.z)) <= 5)
                            {
                                agent.destination = hit.point;
                                PositionObjectCreate(arrow, hit);
                            }
                        }
                    }
                }
            }
        }
    }

    void PositionObjectCreate(GameObject toPlace, RaycastHit clickPosition)
    {
        toPlace.transform.position = new Vector3(clickPosition.point.x, 0f, clickPosition.point.z);
        Instantiate(toPlace, toPlace.transform.position, toPlace.transform.rotation);
    }
}
