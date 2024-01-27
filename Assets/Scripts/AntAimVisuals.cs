using Slothsoft.UnityExtensions;
using UnityEngine;

public class AntAimVisuals : MonoBehaviour {
    [SerializeField] Ant movement;

    protected void FixedUpdate() {
        transform.position = movement.transform.position + movement.aimDirection.SwizzleXY();
    }
}
