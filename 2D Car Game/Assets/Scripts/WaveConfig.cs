using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//object wave 
[CreateAssetMenu(menuName = "Enemy wave config")]
public class waveConfig : ScriptableObject
{
    //enemy

    [SerializeField] GameObject enemyPrefab;


    //the path on which to go
    [SerializeField] GameObject path1Prefab;
    [SerializeField] GameObject path2Prefab;


    //time between each spawn
    [SerializeField] float timeBetweenSpawns = 0.5f;

    //include this random time diffrence between spawns 
    [SerializeField] float spawnRandomFactor = 0.3f;

    //number of enemies in a wave
    [SerializeField] int numberOfObstacles = 1;

    //enem movment speed
    [SerializeField] float obstacleMoveSpeed = 0.2f;

    public GameObject getObstaclePrefab()
    {
        return enemyPrefab;
    }

    /*public GameObject getPathPrefab()
    {
        return pathPrefab;
    }*/

    public List<Transform> getWaypoints()
    {
        int r = Random.Range(0, 3);
        List<Transform> waveWaypoints = new List<Transform>();
        switch (r)
        {
            case 1:

                foreach (Transform child in path1Prefab.transform)
                {
                    waveWaypoints.Add(child);
                }

                break;
            case 2:
                foreach (Transform child in path2Prefab.transform)
                {
                    waveWaypoints.Add(child);
                }
                break;
            default:
                foreach (Transform child in path1Prefab.transform)
                {
                    waveWaypoints.Add(child);
                }
                break;

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
