using UnityEngine;

public class AntMovementLogger : MonoBehaviour {
    protected void OnEnable() {
        Ant.onAntMove += LogAntMovement;
    }

    protected void OnDisable() {
        Ant.onAntMove -= LogAntMovement;
    }

    void LogAntMovement(float movement) {
        Debug.Log(movement);
    }
}
