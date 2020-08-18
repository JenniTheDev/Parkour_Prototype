//using System.Collections;
//using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    // private int numberOfPrefabs;
    private int somePrefab;
    private float spawnY;
    private float spawnX ;
    private float spawnZ;
    [SerializeField] private GameObject obstaclePrefab;
    private UnityEngine.Vector3 spawnPos;
    [SerializeField] private float startDelay = 2;
    [SerializeField] private float repeatRate = 6;

    // List to dynamically allocate more prefab types ?
    // This gave an error for Index being out of range
    // [SerializeField] private List<GameObject> prefabs = new List<GameObject>();
    // An array may not be best when you have to put a number for how many objects?
     [SerializeField] private GameObject[] prefabs = new GameObject[5];

  
    void Start() {

       // prefabs = Resources.LoadAll<GameObject>("Prefabs").ToList();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);


    }

    // Update is called once per frame
    void Update() {

    }

    public void SpawnObstacle() {

        // need to get the mesh collider for each obstacle
        // can this be figured out when the obstacles are pooled at the begining? 
        spawnX = 26;
        spawnZ = Random.Range(-17, -2);

        somePrefab = Random.Range(0, 5);
        spawnY = prefabs[somePrefab].GetComponent<MeshCollider>().bounds.center.y - spawnPos.y;
        spawnPos = new UnityEngine.Vector3(spawnX, spawnY, spawnZ);
        Instantiate(prefabs[somePrefab], spawnPos, prefabs[somePrefab].transform.rotation);
    }

    
}
