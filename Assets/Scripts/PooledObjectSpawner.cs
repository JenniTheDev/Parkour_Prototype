using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledObjectSpawner : MonoBehaviour {
    [SerializeField] private GameObjectPool[] obstaclePools;
    [SerializeField] private Transform startPos;

    private float spawnY;
    private float spawnX;
    private float spawnZ;

    private UnityEngine.Vector3 spawnPos;
    // [SerializeField] private float startDelay = 2;
    [SerializeField] private float startRatePerMinute = 30;
    [SerializeField] private float speedIncreasePerSpawn = 1;
    [SerializeField] private bool isRepeating = true;

    [SerializeField] private float ratePerMinute;

    void Start() {
        ratePerMinute = 60 / startRatePerMinute;
        speedIncreasePerSpawn /= 60;
        StartCoroutine(StartObstacleCourse());
    }

    private IEnumerator StartObstacleCourse() {
        int randPoolNum;
        GameObjectPool randPool;
        GameObject obstacleToMove;

        while(isRepeating) {
            randPoolNum = Random.Range(0, obstaclePools.Length - 1);
            randPool = obstaclePools[randPoolNum];
            obstacleToMove = randPool.Get();
            obstacleToMove.SetActive(true);

            MoveObstacles(obstacleToMove);
            yield return new WaitForSeconds(ratePerMinute);
            ratePerMinute -= speedIncreasePerSpawn;
        }
    }

    private void MoveObstacles(GameObject go) {
        Vector3 spawnPos = startPos.position;
        spawnPos.z = Random.Range(-17, -2);
        spawnPos.y += go.transform.lossyScale.y * 0.5f;

        go.transform.position = spawnPos;
    }


}
