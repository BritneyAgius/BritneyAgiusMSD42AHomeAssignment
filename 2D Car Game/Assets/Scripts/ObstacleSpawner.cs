using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    //a list of WaveConfigs
    WaveConfig waveConfigs;

    //we start always from Wave 0
    [SerializeField] int startingWave = 0;
    public int waveIndex;
    [SerializeField] bool looping = false;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            //start the coroutine that spawns all enemies in our currentWave
            yield return StartCoroutine(SpawnAllWaves());
        }
        //when coroutine SpawnAllWaves finishes check if looping == true
        while (looping);

    }

    IEnumerator SpawnAllWaves()
    {
        //this will loop from startingWave until we reach the last within our List
        for (int waveIndex = startingWave; waveIndex < waveConfigs.Count; waveIndex++)
        {
            var currentWave = waveConfigs[waveIndex];
            //the coroutine will wait for all enemies in Wave to spawn
            //before yielding and going to the next loop
            yield return StartCoroutine(SpawnAllObstaclesInWave(currentWave));
        }
    }

    //when calling this Corotuine, we need to specify which WaveConfig we want to spawn
    IEnumerator SpawnAllObstaclesInWave(WaveConfig waveConfig)
    {
        //spawns an obstacle until obstacleCount == GetNumberOfObstacles()
        for (int obstacleCount = 0; obstacleCount < waveConfig.GetNumberOfObstacles(); obstacleCount++)
        {
            //spawn the obstacle from 
            //at the position specified by the waveConfig waypoints
            var newObstacle = Instantiate(
                waveConfig.GetObstaclePrefab(),
                waveConfig.GetWaypoints()[0].transform.position,
                Quaternion.identity);
            //the wave will be selected from here and the obstacle applied to it
            newObstacle.GetComponent<ObstaclePathing>().SetWaveConfig(waveConfig);

            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }

    }
}