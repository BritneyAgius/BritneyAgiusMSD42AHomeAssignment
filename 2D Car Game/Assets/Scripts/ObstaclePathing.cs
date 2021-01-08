using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePathing : MonoBehaviour
{

    [SerializeField] List<Transform> waypoints;
    [SerializeField] float ObstacleSpeed = 5f;
    static int points = 0;
    WaveConfig waveConfig;

    //saves the waypoint in which we want to go
    int waypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        waypoints = waveConfig.GetWaypoints();

        // Set the start position of the obstacle to the 1st WayPoint position
        transform.position = waypoints[waypointIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        ObstacleMoveOnPath();
    }


    private void ObstacleMoveOnPath()
    {
        if (waypointIndex < waypoints.Count)
        {
            //set targetPosition to the next waypoint
            Vector3 targetPosition = waypoints[waypointIndex].transform.position;

            //Make sure the z axis = 0
            
            var movementThisFrame = ObstacleSpeed * Time.deltaTime;

            //move obstacle from current position to targetPosition, at movementThisFrame
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);

            //if obstacle reaches the first point
            if (transform.position == targetPosition)
            {
                points + 5;
                waypointIndex++;
            }
        }
        //if obstacle reaches last waypoint
        else
        {
            Destroy(gameObject);
        }

        public void SetWaveConfig(WaveConfig waveConfigToSet)
        {
            waveConfig = waveConfigToSet;
        }
    }
}
