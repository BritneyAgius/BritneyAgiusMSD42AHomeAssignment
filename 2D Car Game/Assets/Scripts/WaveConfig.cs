using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//object wave 
[CreateAssetMenu(menuName = "Obstacle wave config")]

public class waveConfig : ScriptableObject
{

    [SerializeField] GameObject obstaclePrefab; //obstacle
    [SerializeField] GameObject path1Prefab; //path which bbstacles move on
    [SerializeField] float timeBetweenSpawns = 0.5f; //time between each spawn
    [SerializeField] float spawnRandomFactor = 0.3f; //random time between each spawn
    [SerializeField] int numberOfObstacles = 1; //obstacles per wave
    [SerializeField] float obstacleMoveSpeed = 0.2f; //obstacle movement speed

    public GameObject getObstaclePrefab()
    {
        return obstaclePrefab;
    }

    public List<Transform> getWaypoints()
    {
        int r = Random.Range(0, 3);
        List<Transform> waveWaypoints = new List<Transform>();

                foreach (Transform child in path1Prefab.transform)
                {
                    waveWaypoints.Add(child);
                }
        
        return waveWaypoints;
    }

    public float getTimeBetweenSpawns()
    {
        return timeBetweenSpawns;
    }

    public float getSpawnRandomFactor()
    {
        return spawnRandomFactor;
    }

    public int getNumberOfObstacles()
    {
        return numberOfObstacles;
    }

    public float getObstacleMoveSpeed()
    {
        return obstacleMoveSpeed;
    }
}
