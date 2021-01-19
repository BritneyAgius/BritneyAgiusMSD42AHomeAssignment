using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    //Variables

    [SerializeField] List<waveConfig> waveConfig;
    [SerializeField] bool looping = false;

    public int waveIndex;
    int startWave = 0;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        / waveConfig currentWave = waveConfig[startWave];
        StartCoroutine(SpawnAllObstaclesInWave(currentWave));
        StartCoroutine(spawnAllWaves());/
        do
        {
            yield return StartCoroutine(spawnAllWaves());
        } while (looping);
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator SpawnAllObstaclesInWave(waveConfig waveConfig)
    {
        for (int obstacleCount = 0; obstacleCount < waveConfig.getNumberOfObstacles(); obstacleCount++)
        {
            GameObject newObstacleClone = Instantiate(waveConfig.getObstaclePrefab(), waveConfig.getWaypoints()[0].position, Quaternion.identity);///creating enemy clone at waypoint[0] in list 
            newEnemyClone.GetComponent<ObstaclePathing>().SetWaveConfig(waveConfig);//reading the enemyPathing to follow waypoints

            yield return new WaitForSeconds(waveConfig.getTimeBetweenSpawns());// wait (time ) before spawn another enemy 
        }
    }
    IEnumerator spawnAllWaves()//Spawn wave one then two then three...
    {

        for (int waveIndex = startWave; waveIndex < waveConfig.Count; waveIndex++)
        {
            waveConfig currentWave = waveConfig[waveIndex];

            yield return StartCoroutine(SpawnAllObstaclesInWave(currentWave));
        }


    }


}