using ServiceLocator.Wave.Bloon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomBloonSpawner : MonoBehaviour
{

    public IEnumerator SpawnWaveBloons(List<BloonType> bloonsToSpawn, Vector3 spawnPosition, int startingWaypointIndex, float spawnRate, BloonPool bloonPool)
    {
        foreach (BloonType bloonType in bloonsToSpawn)
        {
            yield return new WaitForSeconds(spawnRate);
            BloonController bloon = bloonPool.GetBloon(bloonType);
            bloon.SetPosition(spawnPosition);
            bloon.SetWayPoints(GameService.Instance.mapService.GetWayPointsForCurrentMap(), startingWaypointIndex);

            GameService.Instance.waveService.AddBloon(bloon);


        }
    }

    public void spawnBloon(List<BloonType> bloonsToSpawn, Vector3 spawnPosition, int startingWaypointIndex, float spawnRate, BloonPool bloonPool)
    {
        StartCoroutine(SpawnWaveBloons(bloonsToSpawn, spawnPosition, startingWaypointIndex, spawnRate, bloonPool));
    }
}
