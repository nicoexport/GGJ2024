using Slothsoft.UnityExtensions;
using UnityEngine;

public class AntAimVisuals : MonoBehaviour {
    [SerializeField] AntMovement movement;

    protected void FixedUpdate() {
        transform.position = movement.transform.position + movement.aimDirection.SwizzleXY();
    }
}
