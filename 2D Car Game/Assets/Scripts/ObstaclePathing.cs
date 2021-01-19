using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePathing : MonoBehaviour
{
    //the asset item in the project panel which is of type waveConfig
    waveConfig waveConfig;
    [SerializeField] AudioClip endSound;
    [SerializeField] [Range(0, 1)] float endVolumeSound = 0.75f;
    List<Transform> waypoints;
    //[SerializeField] float moveSpeed = 2f;
    int wayPointIndex = 0;
    [SerializeField] int points = 5;

    // Start is called before the first frame update
    void Start()
    {
        waypoints = waveConfig.getWaypoints();//fetch the method get waypoint from our
        //currunt waveconfig retrivve all of the pints found in the current
        //linked path
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
            var movmentThisFrame = waveConfig.getObstacleMoveSpeed() * Time.deltaTime;//making rhe enmen movment
            //movment frame indepednent (moving at the same speed of every pc)
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movmentThisFrame);

            if (transform.position == targetPosition)

                wayPointIndex++;


        }
        else
        {

            //AudioSource.PlayClipAtPoint(dieSound, Camera.main.transform.position, dieVolumeSound);
            FindObjectOfType<ScoreSession>().AddToScore(points);
            Destroy(gameObject);
            print(points);

            int score = FindObjectOfType<ScoreSession>().GetScore();
            if (score >= 100)
            {
                GameObject explosion = Instantiate(FindObjectOfType<PlayerScript>().DeathVfx(), FindObjectOfType<PlayerScript>().transform.position, Quaternion.identity);

                FindObjectOfType<Level>().Winner();
            }

        }
    }
    public void SetWaveConfig(waveConfig waveConfigToSet)
    {
        waveConfig = waveConfigToSet;
    }
}
