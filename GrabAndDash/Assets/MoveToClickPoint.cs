// MoveToClickPoint.cs
using UnityEngine;
using UnityEngine.AI;

public class MoveToClickPoint : MonoBehaviour
{
    public Camera grid2x1_CENTER;
    public Camera grid1x1_LEFT;
    public Camera grid1x1_RIGHT;

    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {   
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 POSITION_CENTER_CAMERA = grid2x1_CENTER.ScreenToViewportPoint(Input.mousePosition);
            Vector3 POSITION_LEFT_CAMERA = grid1x1_LEFT.ScreenToViewportPoint(Input.mousePosition);
            Vector3 POSITION_RIGHT_CAMERA = grid1x1_RIGHT.ScreenToViewportPoint(Input.mousePosition);
            Debug.Log(POSITION_CENTER_CAMERA + "" + POSITION_LEFT_CAMERA + "" + POSITION_RIGHT_CAMERA);

            RaycastHit hit;

            if ((POSITION_CENTER_CAMERA.x >= 0.0 && POSITION_CENTER_CAMERA.y >= 0.0) && (POSITION_CENTER_CAMERA.x <= 1.0 && POSITION_CENTER_CAMERA.y <= 1.0))
            {
                if (Physics.Raycast(grid2x1_CENTER.ScreenPointToRay(Input.mousePosition), out hit, 100))
                {
                    agent.destination = hit.point;
                }
            }
            else if ((POSITION_LEFT_CAMERA.x >= 0.0 && POSITION_LEFT_CAMERA.y >= 0.0) && (POSITION_LEFT_CAMERA.x <= 1.0 && POSITION_LEFT_CAMERA.y <= 1.0))
            {
                if (Physics.Raycast(grid1x1_LEFT.ScreenPointToRay(Input.mousePosition), out hit, 100))
                {
                    agent.destination = hit.point;
                }
            }
            else if ((POSITION_RIGHT_CAMERA.x >= 0.0 && POSITION_RIGHT_CAMERA.y >= 0.0) && (POSITION_RIGHT_CAMERA.x <= 1.0 && POSITION_RIGHT_CAMERA.y <= 1.0))
            {
                if (Physics.Raycast(grid1x1_RIGHT.ScreenPointToRay(Input.mousePosition), out hit, 100))
                {
                    agent.destination = hit.point;
                }
            }
        }
    }
}