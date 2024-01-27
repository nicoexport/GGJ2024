using System;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance { get; private set; }

    [SerializeField] float gameTime = 30f;
    [SerializeField] float totalMovementGoal;
    float time;

    public static event Action<float, float> onTotalMoveUpdate;
    public static event Action onWin;
    public static event Action onLose;
    public static event Action<float> onUpdateTime;

    float movementTotal = 0f;

    bool count = true;

    protected void Awake() {
        if (instance != null && instance != this) {
            Destroy(this);
        } else {
            instance = this;
        }
        time = gameTime;
    }

    protected void FixedUpdate() {
        if (!count) {
            return;
        }

        if (time > 0f) {
            time -= Time.deltaTime;

        } else {
            onLose?.Invoke();
            count = false;
        }
        onUpdateTime?.Invoke(time);
    }

    protected void Start() {
        onTotalMoveUpdate.Invoke(movementTotal, totalMovementGoal);
    }

    protected void OnEnable() {
        Ant.onAntMove += HandleAntMovement;
    }

    protected void OnDisable() {
        Ant.onAntMove -= HandleAntMovement;
    }

    void HandleAntMovement(float value) {
        movementTotal += value;
        onTotalMoveUpdate?.Invoke(movementTotal, totalMovementGoal);
        if (movementTotal >= totalMovementGoal) {
            onWin?.Invoke();
            count = false;
        }
    }
}
