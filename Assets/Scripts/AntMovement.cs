using System;
using Slothsoft.UnityExtensions;
using UnityEngine;
using UnityEngine.InputSystem;

public class AntMovement : MonoBehaviour {
    public static event Action<float> onAntMove;

    [SerializeField] CharacterController characterController;
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float slowFactor = 0.5f;

    public Vector2 aimDirection { get; private set; } = Vector2.right;
    public bool isSlowed;

    Vector2 velocity;
    Vector3 lastPos;

    protected void Awake() {
        lastPos = transform.position;
    }

    protected void FixedUpdate() {
        var movement = velocity * Time.deltaTime;

        if (isSlowed) {
            movement *= slowFactor;
        }

        characterController.Move(movement);
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
