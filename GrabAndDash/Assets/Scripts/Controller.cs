// MoveToClickPoint.cs
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(LineRenderer))]
public class Controller : MonoBehaviour
{
    public bool Moveable;
    public GameObject arrow;
    public int radius = 3;

    [Range(0, 50)]
    public int segments = 50;
    [Range(0, 5)]
    public float xradius = 5;
    [Range(0, 5)]
    public float yradius = 5;
    LineRenderer line;

    NavMeshAgent agent;

    GameObject[] cameras;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        cameras = GameObject.FindGameObjectsWithTag("Camera");


        line = gameObject.GetComponent<LineRenderer>();

        line.positionCount = (segments + 1);
        line.useWorldSpace = false;

        CreatePoints();
    }

    void Update()
    {
        if (Moveable)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                RaycastHit hit;
                foreach (GameObject cam in cameras)
                {
                    if (cam.GetComponent<SercurityCamera>().properties.Power == true)
                    {
                        Vector3 POSITION_CENTER_CAMERA = cam.GetComponent<Camera>().ScreenToViewportPoint(Input.mousePosition);
                        if ((POSITION_CENTER_CAMERA.x >= 0.0 && POSITION_CENTER_CAMERA.y >= 0.0) && (POSITION_CENTER_CAMERA.x <= 1.0 && POSITION_CENTER_CAMERA.y <= 1.0))
                        {
                            if (Physics.Raycast(cam.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition), out hit, 100))
                            {
                                float newX = hit.point.x - transform.position.x;
                                float newZ = hit.point.z - transform.position.z;
                                float hypot = Mathf.Sqrt((newX * newX) + (newZ * newZ));
                                //Debug.Log("__________________LOOK HERE______________________");
                                //Debug.Log(newX + " " + newZ);
                                //Debug.Log(hypot);
                                //Debug.Log(radius);
                                //Debug.Log("_________________________________________________");
                                if (hypot <= radius)
                                {
                                    agent.destination = hit.point;
                                    PositionObjectCreate(arrow, hit);
                                }
                            }
                        }
                    }
                }
            }

            if (Input.GetButton("Range"))
            {
                //Show te Range circle
                //Debug.Log("A is pressed");
                line.enabled = true;
            }
            if (Input.GetButtonUp("Range"))
            {
                //Show te Range circle
                //Debug.Log("A is released");
                line.enabled = false;
            }
        }
    }

    void PositionObjectCreate(GameObject toPlace, RaycastHit clickPosition)
    {
        toPlace.transform.position = new Vector3(clickPosition.point.x, gameObject.transform.position.y, clickPosition.point.z);
        Instantiate(toPlace, toPlace.transform.position, toPlace.transform.rotation);
    }

    void CreatePoints()
    {
        float x;
        float z;

        float angle = 20f;

        for (int i = 0; i < (segments + 1); i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * xradius;
            z = Mathf.Cos(Mathf.Deg2Rad * angle) * yradius;

            line.SetPosition(i, new Vector3(x, 0, z));

            angle += (360f / segments);
        }
    }
}
