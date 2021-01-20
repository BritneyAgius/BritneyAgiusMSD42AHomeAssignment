using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePathing : MonoBehaviour
{
    waveConfig waveConfig; //Found in the assets project panel
    //type is not gameobject but waveConfig

    [SerializeField] AudioClip endSound;
    [SerializeField] [Range(0, 1)] float endVolumeSound = 0.75f;

    List<Transform> waypoints;
    int wayPointIndex = 0;
    [SerializeField] int points = 5;

    // Start is called before the first frame update
    void Start()
    {
        //Path is stored in waypoints which are stored in waveConfig
        //all waypoints are retrieved when calling waveConfig
        waypoints = waveConfig.getWaypoints();
        transform.position = waypoints[wayPointIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        obstacleMove();
    }
    
    void obstacleMove()
    {
        if (wayPointIndex < waypoints.Count)
        {
            var targetPosition = waypoints[wayPointIndex].transform.position;
            var movmentThisFrame = waveConfig.getObstacleMoveSpeed() * Time.deltaTime;//ostacle movement
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movmentThisFrame);

            if (transform.position == targetPosition)

                wayPointIndex++;


        }
        else
        {
            FindObjectOfType<ScoreSession>().AddToScore(points);
            Destroy(gameObject);
            print(points);

            int score = FindObjectOfType<ScoreSession>().GetScore();
            if (score >= 100)
            {
                GameObject explosion = Instantiate(FindObjectOfType<Player>().DeathVfx(), FindObjectOfType<Player>().transform.position, Quaternion.identity);

                FindObjectOfType<Level>().Winner();
            }

        }
    }

    public void SetWaveConfig(waveConfig waveConfigToSet)
    {
        waveConfig = waveConfigToSet;
    }
}
