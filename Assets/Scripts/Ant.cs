using System;
using Slothsoft.UnityExtensions;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ant : MonoBehaviour {
    public static event Action<float> onAntMove;

    [SerializeField] Projectile projectilePrefab;
    [SerializeField] CharacterController characterController;
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float hairSlowFactor = 0.5f;
    [SerializeField] AnimationCurve chargeSlowCurve;
    [SerializeField] float rotationSpeed = 0.5f;
    public float charge;

    public Vector2 aimDirection { get; private set; } = Vector2.right;
    public bool isSlowed;
    public bool isOnBelly;

    bool active = true;

    Vector2 velocity;
    Vector3 lastPos;


    protected void OnEnable() {
        GameManager.onWin += HandleWin;
        GameManager.onLose += HandleWin;
    }

    protected void OnDisable() {
        GameManager.onWin -= HandleWin;
        GameManager.onLose -= HandleWin;
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

        // Calculate the rotation angle in degrees
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;

        // Create a rotation quaternion from the angle
        var rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        // Apply the rotation to the object
        transform.rotation = rotation;
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

        var spawnPos = transform.position + aimDirection.SwizzleXY();
        var proj = Instantiate(projectilePrefab, spawnPos, Quaternion.identity);
        proj.Setup(aimDirection);  
    }

    void HandleWin() {
        active = false;
    }
}
