using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public GameObject[] roads;
    public GameObject block;
    public float blockIndex = 0, roadIndex = 1;
    
    public void MakeRoad()
    {
        int n = Random.Range(0, roads.Length);
        Vector3 newPosition = new Vector3(roadIndex * 100 - 100, 0f, 0f);
        GameObject newRoad = Instantiate(roads[n], newPosition, roads[n].transform.rotation);
        for (int i = 0; i < 10; i++)
        {
            SpawnBlock();
        }
        roadIndex++;
    }
    void SpawnBlock()
    {
        Vector3 newPosition = new Vector3(Random.Range(blockIndex * 10 - 50, blockIndex * 10 - 40), 1f, Random.Range(-1f, 1f));
        GameObject newBlock = Instantiate(block, newPosition, Quaternion.identity);
        blockIndex++;
    }
}
