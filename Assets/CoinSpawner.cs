using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public static CoinSpawner Instance { get; private set; }
    public float repeatRate = 5;
    private float timer = 0;
    private float topBound;
    private float bottomBound;
    public GameObject coinPrefab;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (timer > repeatRate)
        {
            timer = 0;
            SpawnCoin();
        }

        timer += Time.deltaTime;
    }

    public void SetSpawnBounds(float top, float bottom)
    {
        topBound = top;
        bottomBound = bottom;
    }

    private void SpawnCoin()
    {
        float spawnY = Random.Range(bottomBound, topBound);
        GameObject newCoin = Instantiate(coinPrefab);
        newCoin.transform.position = transform.position + new Vector3(0, spawnY, 0);
        Destroy(newCoin, 10f);
    }
    
}