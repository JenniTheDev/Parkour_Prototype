using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectPool : MonoBehaviour {
    private const int DEFAULT_MAX = 100;
    private const int DEFAULT_MIN = 1;
    private const int DEFAULT_BUFFER = 10;

    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform container;
    [SerializeField] private int max = DEFAULT_MAX;
    [SerializeField] private int min = DEFAULT_MIN;
    [SerializeField] private int buffer = DEFAULT_BUFFER;

    private List<GameObject> Pool { get; } = new List<GameObject>();

    private bool isMaintaining = false;

    #region MonoBehaviour
    private void Start() {    }

    private void OnDisable() {
        StopAllCoroutines();
    }
    #endregion

    public GameObject Get() {
        foreach (var go in Pool) {
            if (!go.activeSelf) {
                return go;
            }
        }

        return Add();
    }

    public GameObject Add() {
        GameObject go = Instantiate(prefab, container, true);
        go.SetActive(false);
        Pool.Add(go);
        return go;
    }

    public IEnumerator Fill() {
        isMaintaining = true;
        int freeCount, delta;

        freeCount = 0;
        foreach (var go in Pool) {
            if (!go.activeSelf) { freeCount++; }
        }

        delta = 0;
        if (freeCount < (min + buffer)) {
            delta = (min + buffer) - freeCount;
            for (int i = 0; i < delta; i++) {
                Add();
                yield return null;
            }
        }

        isMaintaining = false;
    }
}
