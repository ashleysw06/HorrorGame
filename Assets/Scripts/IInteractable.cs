public interface IInteractable {
    public abstract void Interact();
    string GetInteractPrompt();
    
    void OnFocusEnter();
    void OnFocusExit();
}