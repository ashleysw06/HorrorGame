using UnityEngine;
using TMPro;

public class InteractionHandler : MonoBehaviour {
    public TMP_Text prompt;

    IInteractable focusedObject;
    IInteractable lastFocusedObject;

    LayerMask layerMask;

    void Awake() {
        layerMask = LayerMask.GetMask("Default");
    }

    void Update() {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hit, Mathf.Infinity, layerMask)) {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            focusedObject = interactable;
        } else {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            focusedObject = null;
        }

        if (focusedObject != lastFocusedObject) {
            focusedObject?.OnFocusEnter();
            lastFocusedObject?.OnFocusExit();
        }
        lastFocusedObject = focusedObject;

        prompt.text = "";

        if (focusedObject as Component == null) return;

        prompt.text = focusedObject.GetInteractPrompt();

        if (!Input.GetKey(KeyCode.E)) return;
        
        focusedObject.Interact();
    }
}