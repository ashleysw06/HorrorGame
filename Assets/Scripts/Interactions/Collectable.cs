using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour, IInteractable {
    public Material outlineMaterial;
    public Material baseMaterial;
    private Renderer renderer;

    
    void Start() {
        renderer = gameObject.GetComponentInChildren<Renderer>();
        baseMaterial = renderer.material;
	}
	
	void Update () {
    }

    public void Interact() {
        Destroy(gameObject);
    }

    public string GetInteractPrompt() {
        return "Press [E] to collect.";
    }

    public void OnFocusEnter() {
        if(renderer!=null) renderer.material = outlineMaterial;
    }

    public void OnFocusExit() {
        if(renderer!=null) renderer.material = baseMaterial;
    }
}