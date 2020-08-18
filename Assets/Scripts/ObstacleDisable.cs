using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDisable : MonoBehaviour {
    // Start is called before the first frame update
    void OnEnable() {
        Invoke("Destroy", 2f);
    }

    public void OnDestroy() {
        gameObject.SetActive(false);
    }

    public void OnDisable() {
        CancelInvoke();
    }
}


