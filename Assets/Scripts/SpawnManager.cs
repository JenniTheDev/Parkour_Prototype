//using System.Collections;
//using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    // private int numberOfPrefabs;
    private int somePrefab;
    private float spawnY;
    private float spawnX;
    private float spawnZ;
    [SerializeField] private GameObject obstaclePrefab;
    private UnityEngine.Vector3 spawnPos;
    [SerializeField] private float startDelay = 2;
    [SerializeField] private float repeatRate = 6;

    [SerializeField] private GameObject[] prefabs = new GameObject[5];

    // Start is called before the first frame update
    void Start() {


        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);


    }

    // Update is called once per frame
    void Update() {

    }

    public void SpawnObstacle() {

        // need to get the mesh collider for each obstacle
        // can this be figured out when the obstacles are pooled at the begining? 
        
        spawnY = GetComponent<MeshCollider>().bounds.center.y - spawnPos.y;
        somePrefab = Random.Range(0, 5);
        spawnPos = new UnityEngine.Vector3(spawnX, spawnY, spawnZ);
        Instantiate(prefabs[somePrefab], spawnPos, prefabs[somePrefab].transform.rotation);
    }

    
}
