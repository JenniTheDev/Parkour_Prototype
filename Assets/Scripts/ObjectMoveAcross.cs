using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMoveAcross : MonoBehaviour, IKillZoneResetable {

    [SerializeField] private float speed = 0.01f;
    private Rigidbody rb;



    void Start() {
        rb = GetComponent<Rigidbody>();
    }


    void Update() {
        rb.velocity = new Vector3(-1, 0, 0);
    }

    private void FixedUpdate() {
        rb.velocity = new Vector3(-3, 0, 0) * speed;
    }

    public void KillZoneReset() {
        gameObject.SetActive(false);
    }


}
