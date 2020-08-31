using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledObjectSpawner : MonoBehaviour {

    [SerializeField] private GameObjectPool barObstaclePool;
    [SerializeField] private GameObjectPool cubePool;
    [SerializeField] private GameObjectPool hurdlePool;
    [SerializeField] private GameObjectPool prismPool;
    [SerializeField] private GameObjectPool wallCubePool;

    private float spawnY;
    private float spawnX;
    private float spawnZ;

    private UnityEngine.Vector3 spawnPos;
    [SerializeField] private float startDelay = 2;
    [SerializeField] private float repeatRate = 6;

    void Start() {
        StartCoroutine(StartObstacleCourse());
    }

    private IEnumerator StartObstacleCourse() {
        for(int i = 0; i < 10; i++) {
            MoveObstacles(barObstaclePool.Get());
            yield return new WaitForEndOfFrame();
        }
    }

    private void MoveObstacles(GameObject go) {
        spawnX = 26;
        spawnZ = Random.Range(-17, -2);

        
        spawnY = go.GetComponent<MeshCollider>().bounds.center.y - spawnPos.y;
        spawnPos = new UnityEngine.Vector3(spawnX, spawnY, spawnZ);


    }


}
