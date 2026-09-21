using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCamLook : MonoBehaviour {
    public float sensitivity = 5.0f;
    public float smoothing = 2.0f;
    public GameObject character;
    private Vector2 mouseLook;
    private Vector2 smoothVelocity;

	void Start () {
        character = transform.parent.gameObject;
	}
	
	void Update () {
        if (Cursor.lockState != CursorLockMode.Locked) return;

        var mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        mouseDelta = Vector2.Scale(mouseDelta, new Vector2(sensitivity * smoothing, sensitivity * smoothing));

        smoothVelocity.x = Mathf.Lerp(smoothVelocity.x, mouseDelta.x, 1f / smoothing);
        smoothVelocity.y = Mathf.Lerp(smoothVelocity.y, mouseDelta.y, 1f / smoothing);
        mouseLook += smoothVelocity;

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);
    }
}


