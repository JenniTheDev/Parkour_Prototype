using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    // private int numberOfPrefabs;
    private int somePrefab;
    [SerializeField] private GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(29, 0, -5);
    [SerializeField] private float startDelay = 2;
    [SerializeField] private float repeatRate = 5;

    [SerializeField] private GameObject[] prefabs = new GameObject[5];

    // Start is called before the first frame update
    void Start() {

        
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
       

    }

    // Update is called once per frame
    void Update() {

    }

    public void SpawnObstacle() {
        somePrefab = Random.RandomRange(0, 5);
        Instantiate(prefabs[somePrefab], spawnPos, obstaclePrefab.transform.rotation);
    }
}
