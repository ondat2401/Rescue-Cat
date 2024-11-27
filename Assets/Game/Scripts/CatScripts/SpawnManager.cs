using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject spawnAreasPrefabs;
    [SerializeField] List<Vector2> spawnDistances = new List<Vector2>();
    private PlayerMovement playerMovement;
    private void Start()
    {
        playerMovement = FindAnyObjectByType<PlayerMovement>();
        Vector3 spawnPosition = playerMovement.transform.position;

        for (int i = 0; i < spawnDistances.Count; i++)
        {
            spawnPosition = spawnPosition + (playerMovement.transform.forward) * spawnDistances[i].y;

            spawnPosition.x = spawnDistances[i].x;

            SpawnPrefabAtPosition(spawnPosition);
        }
    }
    private void SpawnPrefabAtPosition(Vector3 position)
    {
        GameObject newArea = Instantiate(spawnAreasPrefabs, position, Quaternion.identity, transform);
        newArea.transform.localPosition = position;
        newArea.GetComponent<SpawnArea>().SpawnCat(newArea.transform);
    }
}
