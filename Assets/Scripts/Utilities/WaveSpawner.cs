using ServiceLocator.Map;
using ServiceLocator.Wave;
using ServiceLocator.Wave.Bloon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    List<BloonType> bloonsToSpawn;
    Vector3 spawnPosition;
    int startingWaypointIndex;
    float spawnRate;
    BloonPool bloonPool;

    MapService mapService;
    WaveService waveService;

    public void Init(List<BloonType> bloonsToSpawn, Vector3 spawnPosition, int startingWaypointIndex, float spawnRate, BloonPool bloonPool, MapService mapService, WaveService waveService)
    {
        this.waveService = waveService;
        this.mapService = mapService;
        this.bloonsToSpawn = bloonsToSpawn;
        this.spawnPosition = spawnPosition;
        this.startingWaypointIndex = startingWaypointIndex;
        this.spawnRate = spawnRate;
        this.bloonPool = bloonPool;
    }

    public void SpawnWave()
    {
        StartCoroutine(SpawnBloons());
    }
    private IEnumerator SpawnBloons()
    {
        foreach (BloonType bloonType in bloonsToSpawn)
        {
            yield return new WaitForSeconds(spawnRate);
            BloonController bloon = bloonPool.GetBloon(bloonType);
            bloon.SetPosition(spawnPosition);
            bloon.SetWayPoints(mapService.GetWayPointsForCurrentMap(), startingWaypointIndex);

            waveService.AddBloon(bloon);
        }
    }
}
