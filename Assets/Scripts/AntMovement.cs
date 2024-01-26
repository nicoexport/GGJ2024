using UnityEngine;
using UnityEngine.InputSystem;

public class AntMovement : MonoBehaviour {
    [SerializeField] CharacterController characterController;

    Vector2 velocity;

    protected void FixedUpdate() {
        characterController.Move(velocity);
    }

    protected void OnValidate() {
        if (!characterController) {
            TryGetComponent(out characterController);
        }
    }

    public void OnMove(InputValue value) {
        velocity = value.Get<Vector2>();
    }
}
