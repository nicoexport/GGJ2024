using System;
using Slothsoft.UnityExtensions;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ant : MonoBehaviour {
    public static event Action<float> onAntMove;

    [SerializeField] CharacterController characterController;
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float hairSlowFactor = 0.5f;
    [SerializeField] AnimationCurve chargeSlowCurve;
    public float charge;

    public Vector2 aimDirection { get; private set; } = Vector2.right;
    public bool isSlowed;
    public bool isOnBelly;

    bool active = true;



    Vector2 velocity;
    Vector3 lastPos;


    protected void OnEnable() {
        GameManager.onWin += HandleWin;
    }


    protected void Awake() {
        lastPos = transform.position;
    }

    protected void FixedUpdate() {
        if (!active) {
            return;
        }

        var movement = velocity * Time.deltaTime;

        movement *= chargeSlowCurve.Evaluate(1f - charge);

        if (isSlowed) {
            movement *= hairSlowFactor;
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
        if (!active) {
            return;
        }
        velocity = value.Get<Vector2>().normalized * moveSpeed;
    }

    public void OnAim(InputValue value) {
        if (!active) {
            return;
        }
        var input = value.Get<Vector2>().normalized;
        if (input.magnitude > 0f) {
            aimDirection = input;
        }
    }

    public void OnCharge(InputValue value) {
        if (!active) {
            return;
        }

        charge = value.Get<float>();
    }

    public void OnChargeRelease() {
        if (!active) {
            return;
        }

        Debug.Log("Release");
    }

    void HandleWin() {
        active = false;
    }
}
