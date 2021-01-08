using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigList;

    int startingWave = 0;

    // Start is called before the first frame update
    void Start()
    {

        var currentWave = waveConfigList[startingWave];

        StartCoroutine(SpawnAllObstaclesinWave(currentWave));
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator SpawnAllObstaclesinWave(WaveConfig waveToSpawn)
    {
        for (int obstacleCount = 1; obstacleCount <= waveToSpawn.GetNumberOfObstacles(); obstacleCount++)
            //spawn the obstacle from waveConfig at the position speicified by waveConfig waypoints
            var newObstacle = Instantiate(
                waveToSpawn.getObstaclePrefab(),
                waveToSpawn.GetWaypoints()[0].transforn.position, Quaternion.identity);

        newObstacle.GetComponent<ObstaclePathing>().SetWaveConfig(waveToSpawn); 

        //wait TimeBetweenSpawns before spawning another obstacle
        yield return new WaitForSeconds(waveToSpawn.GetTimeBetweenSpawns());        
    }
}