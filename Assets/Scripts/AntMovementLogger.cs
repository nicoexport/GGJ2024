using UnityEngine;

public class AntMovementLogger : MonoBehaviour {
    protected void OnEnable() {
        AntMovement.onAntMove += LogAntMovement;
    }

    protected void OnDisable() {
        AntMovement.onAntMove -= LogAntMovement;
    }

    void LogAntMovement(float movement) {
        Debug.Log(movement);
    }
}
