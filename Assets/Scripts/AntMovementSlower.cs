using UnityEngine;

public class AntMovementSlower : MonoBehaviour {
    protected void OnTriggerStay(Collider other) {
        if (other.TryGetComponent(out Ant movement)) {
            movement.isSlowed = true;
        }

        if (other.CompareTag("Projectile")) {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    protected void OnTriggerExit(Collider other) {
        if (other.TryGetComponent(out Ant movement)) {
            movement.isSlowed = false;
        }
    }
}