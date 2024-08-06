using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    WaveController waveController;
    float maxSpawnRate = 3f;
    List<GameObject> spawnList = new List<GameObject>();
    private int index = 0;
    List<Vector2> spawnPositions = new List<Vector2>();

    // Start is called before the first frame update
    void Start()
    {
        spawnList = waveController.GetEnemies();
        spawnPositions = waveController.GetPositions();
        Invoke("SpawnEnemy", maxSpawnRate);

        InvokeRepeating("IncreaseSpawnRate", 0f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        spawnList[index] = Instantiate(spawnList[index]) as GameObject;
        spawnList[index].transform.position = new Vector2(spawnPositions[index].x, max.y);
        JellyControl control = spawnList[index].GetComponent<JellyControl>();
        if (control != null)
        {
            control.SpawnY = spawnPositions[index].y;
        }
        else
        {
            BossControl controlBoss = spawnList[index].GetComponent<BossControl>();
        }
        NextEnemySpawn();
    }

    void NextEnemySpawn()
    {
        float spawnInSeconds;
        if (maxSpawnRate > 1f)
        {
            spawnInSeconds = Random.Range(1f, maxSpawnRate);
        }
        else
        {
            spawnInSeconds = 1f;
        }
        index++;
        if (index < spawnList.Count)
            Invoke("SpawnEnemy", spawnInSeconds);
        else
        {
            List<GameObject> spawnedJelly = spawnList;
            foreach (GameObject enemy in spawnedJelly)
            {
                JellyControl control = enemy.GetComponent<JellyControl>();
                control.StartTimeOut();
            }
            waveController.NextWave();
            spawnList = waveController.GetEnemies();
            spawnPositions = waveController.GetPositions();
            index = 0;
            Invoke("SpawnEnemy", 15f);
        }
    }

    void IncreaseSpawnRate()
    {
        if (maxSpawnRate > 1f)
            maxSpawnRate--;
        if (maxSpawnRate == 1f)
            CancelInvoke("IncreaseSpawnRate");
    }
}
