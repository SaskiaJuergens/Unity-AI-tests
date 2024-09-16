using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPosition;
    private Vector3 lastSpawnPosition;
    private bool foodSpawned = false;

    // Methode zum Spawnen von Essen
    public void SpawnFood()
    {
        spawnPosition.localPosition = new Vector3(Random.Range(-6f, +6f), 0, Random.Range(-5f, +7f));
        lastSpawnPosition = spawnPosition.localPosition;
        foodSpawned = true;
    }
    public bool HasFoodSpawned()
    {
        return foodSpawned;
    }
    public Vector3 GetLastSpawnPosition()
    {
        return lastSpawnPosition;
    }

    public void ResetFoodSpawn()
    {
        foodSpawned = false;
    }
}
