using System;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance { get; private set; }

    [SerializeField] float totalMovementGoal;

    public static event Action<float, float> onTotalMoveUpdate;
    public static event Action onWin;

    float movementTotal = 0f;

    protected void Awake() {
        if (instance != null && instance != this) {
            Destroy(this);
        } else {
            instance = this;
        }
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
        }
    }
}
