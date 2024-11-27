using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawnManager : MonoBehaviour
{
    [Header("Prefab Settings")]
    [SerializeField] private List<GameObject> prefabList;
    private int spawnCount;
    private float distance;

    [Header("Spawn Area")]
    [SerializeField] private Vector2 spawnAreaX;
    [SerializeField] private float startZ;
    [SerializeField] private float zStep;

    private List<Vector3> spawnedPositions = new List<Vector3>();

    private void Start()
    {
        spawnCount = GameManager.Instance.carCounter;
        distance = GameManager.Instance.carDistance;


        SpawnPrefabs();
    }
    private void SpawnPrefabs()
    {
        float currentZ = startZ;

        for (int i = 0; i < spawnCount; i++)
        {
            int attempts = 0;
            bool spawned = false;

            while (!spawned && attempts < 100)
            {
                Vector3 randomPosition = new Vector3(
                    Random.Range(spawnAreaX.x, spawnAreaX.y),
                    0,                                     
                    currentZ                               
                );

                Quaternion randomRotation = Quaternion.Euler(
                    0,
                    Random.Range(0, 360),
                    0
                );

                if (IsPositionValid(randomPosition))
                {
                    GameObject prefabToSpawn = prefabList[Random.Range(0, prefabList.Count)];
                    Instantiate(prefabToSpawn, randomPosition, randomRotation,transform);
                    spawnedPositions.Add(randomPosition);
                    spawned = true;
                }

                attempts++;
            }
            currentZ += zStep;
        }
    }

    private bool IsPositionValid(Vector3 position)
    {
        foreach (Vector3 spawnedPosition in spawnedPositions)
        {
            if (Vector3.Distance(position, spawnedPosition) < distance)
            {
                return false;
            }
        }
        return true;
    }
}
