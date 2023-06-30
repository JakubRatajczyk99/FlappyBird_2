using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public float repeatRate = 1;
    private float timer = 0;
    public float height = 5;
    public GameObject[] prefabPipes;

    private GameObject lastSpawnedPipe;

        // Update is called once per frame
    void Update()
    {
        if (timer > repeatRate)
        {
            timer = 0;
            lastSpawnedPipe = SpawnPipe();
        }

        timer += Time.deltaTime;

        if (lastSpawnedPipe != null)
        {
            float topPosition = lastSpawnedPipe.transform.position.y + height;
            float bottomPosition = lastSpawnedPipe.transform.position.y - height;

            CoinSpawner.Instance.SetSpawnBounds(topPosition, bottomPosition);
        }
    }

    private GameObject SpawnPipe()
    {
        GameObject prefabPipe = prefabPipes[Random.Range(0, prefabPipes.Length)];
        GameObject newPipe = Instantiate(prefabPipe);
        newPipe.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
        Destroy(newPipe, 10f);
        return newPipe;
    }
}