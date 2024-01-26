using UnityEngine;
using UnityEngine.InputSystem;

public class AntMovement : MonoBehaviour {
    [SerializeField] CharacterController characterController;
    [SerializeField] float moveSpeed = 1f;

    Vector2 velocity;

    protected void FixedUpdate() {
        characterController.Move(velocity * Time.deltaTime);
    }

    protected void OnValidate() {
        if (!characterController) {
            TryGetComponent(out characterController);
        }
    }

    public void OnMove(InputValue value) {
        velocity = value.Get<Vector2>().normalized * moveSpeed;
    }
}
