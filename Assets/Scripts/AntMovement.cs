using System;
using Slothsoft.UnityExtensions;
using UnityEngine;
using UnityEngine.InputSystem;

public class AntMovement : MonoBehaviour {
    public static event Action<float> onAntMove;

    [SerializeField] CharacterController characterController;
    [SerializeField] float moveSpeed = 1f;

    Vector2 velocity;
    public Vector2 aimDirection { get; private set; } = Vector2.right;

    Vector3 lastPos;

    protected void Awake() {
        lastPos = transform.position;
    }

    protected void FixedUpdate() {
        characterController.Move(velocity * Time.deltaTime);
        float deltaMovement = Vector2.Distance(lastPos.SwizzleXY(), transform.position.SwizzleXY());
        lastPos = transform.position;   
        if (deltaMovement > 0f) {
            onAntMove?.Invoke(deltaMovement);
        }
    }

    protected void OnValidate() {
        if (!characterController) {
            TryGetComponent(out characterController);
        }
    }

    public void OnMove(InputValue value) {
        velocity = value.Get<Vector2>().normalized * moveSpeed;
    }

    public void OnAim(InputValue value) {
        var input = value.Get<Vector2>().normalized;
        if (input.magnitude > 0f) {
            aimDirection = input;
        }
    }
}
