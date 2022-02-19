using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeSpawner : MonoBehaviour
{
    // object variables
    public GameObject treePrefab;
    public Transform[] spawnPoints;
    public int numSpawnPoints;
    private Transform currentSpawnPoint;
    public GameObject timeText;
    public GameObject gameOverText;

    // Timing variables
    public float spawnRangeStart = 0.5f;
    public float spawnRangeEnd = 1.2f;
    private float timeToSpawn;
    private float spawnTimer = 0f;

    public int gameTime = 20;
    private float gameTimer = 0f;

    void Start() {
        numSpawnPoints = spawnPoints.Length - 1;

        gameOverText.SetActive(false);
        UpdateTime();
    }

    void FixedUpdate() {
       timeToSpawn = Random.Range(spawnRangeStart, spawnRangeEnd);
       spawnTimer += 0.01f;

       if (spawnTimer >= timeToSpawn) {
           spawnTree();
           spawnTimer = 0f;
       }

       gameTimer += 0.02f;
       if (gameTimer >= 1f) {
           gameTime -= 1;
           gameTimer = 0;
           UpdateTime();
       }
       if (gameTime <= 0) {
           gameTime = 0;
           gameOverText.SetActive(true);
       }
    }

    void spawnTree() {
        int SPNum = Random.Range(0, numSpawnPoints);
        currentSpawnPoint = spawnPoints[SPNum];

        if (gameTime > 0) {
            Instantiate(treePrefab, currentSpawnPoint.position, Quaternion.identity);
        }
    }

    public void UpdateTime() {
        Text timeTextBox = timeText.GetComponent<Text>();
        timeTextBox.text = "" + gameTime.ToString();
    }
}
