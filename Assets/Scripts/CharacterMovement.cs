using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {
    // Start is called before the first frame update
    public CharacterController controller;
    public Transform cam;
    [SerializeField] private float speed = 6f;
    [SerializeField] private float turnSmoothTime = 0.1f;
    private float horitzontal;
    private float vertical;
    private float angle;
    Vector3 direction;
    private float targetAngle;
    private float turnSmoothVelocity;
    Vector3 moveDirection;


    // Update is called once per frame
    void Update() {
        horitzontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        direction = new Vector3(horitzontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f) {
            targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDirection.normalized * speed * Time.deltaTime);
        }


    }
}

