using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour {

    public float walkSpeed = 10.0f;
    public float sprintSpeed = 1.33f;
    public float sneakSpeed = 0.5f;
    public float drag = 0.1f;
    public Vector3 moveDir = new Vector3(0.0f, 0.0f, 0.0f);
    public float moveSpeed = 0.0f;
    public float moveVelocity = 0.0f;

    Rigidbody rb;
    CharacterController cc;

    void Start() {
        cc = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	void Update () {
        moveSpeed = walkSpeed;
        if (Input.GetAxis("Sprint") == 1) moveSpeed = walkSpeed * sprintSpeed;
        if (Input.GetAxis("Crouch") == 1) moveSpeed = walkSpeed * sneakSpeed;

        moveDir.z = Input.GetAxis("Vertical");
        moveDir.x = Input.GetAxis("Horizontal");

        moveVelocity += Mathf.Sqrt(Mathf.Pow(moveDir.z, 2) + Mathf.Pow(moveDir.x, 2)) * moveSpeed;
        moveVelocity *= drag;

        transform.Translate(moveDir.normalized * moveVelocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Escape)) Cursor.lockState = CursorLockMode.None; // Show Cursor on ESC
        if (Input.GetMouseButton(0)) Cursor.lockState = CursorLockMode.Locked; // TEMPORARY: Hide Cursor on Click
    }
}