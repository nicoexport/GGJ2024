using UnityEngine;

public class AntMovementSlower : MonoBehaviour {
    protected void OnTriggerStay(Collider other) {
        if (other.TryGetComponent(out AntMovement movement)) {
            movement.isSlowed = true;
        }
    }

    protected void OnTriggerExit(Collider other) {
        if (other.TryGetComponent(out AntMovement movement)) {
            movement.isSlowed = false;
        }
    }
}