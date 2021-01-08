using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Obstacle Wave Config")]
public class WaveConfig : ScriptableObject
{
    //the obstacle
    [SerializeField] GameObject obstaclePrefab;

    //the path on which to go
    [SerializeField] GameObject pathPrefab;

    //time between each spawn
    [SerializeField] float timeBetweenSpawns = 0.5f;

    //include this random time difference between spawns
    [SerializeField] float spawnRandomFactor = 0.3f;

    //number of obstacles in the wave
    [SerializeField] int numberOfObstacles = 5;

    //obstacle movement speed
    [SerializeField] float obstacleMoveSpeed = 5f;

    public GameObject GetObstaclePrefab()
    {
        return obstaclePrefab;
    }

    public List<Transform> GetWaypoints()
    {
        //each wave can have different waypoints
        var waveWayPoints = new List<Transform>();

        //go into Path prefab and for each child, add it to the List waveWaypoints
        foreach (Transform child in pathPrefab.transform)
        {
            waveWayPoints.Add(child);
        }
        return waveWayPoints;
    }

    public float GetTimeBetweenSpawns()
    {
        return timeBetweenSpawns;
    }

    public float GetSpawnRandomFactor()
    {
        return spawnRandomFactor;
    }

    public int GetNumberOfObstacles()
    {
        return numberOfObstacles;
    }

    public float GetObstacleMoveSpeed()
    {
        return obstacleMoveSpeed;
    }
}
