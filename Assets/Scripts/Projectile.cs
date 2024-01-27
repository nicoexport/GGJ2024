using UnityEngine;

public class Projectile : MonoBehaviour {
    [SerializeField] CharacterController controller;
    [SerializeField] float speed = 5f;

    Vector2 direction = Vector2.right;
    float charge = 1f;

    public void Setup(Vector2 direction, float charge = 1) {
        this.direction = direction;
        this.charge = charge;
    }

    protected void FixedUpdate() {
        controller.Move(Mathf.Clamp(charge, 0.2f, 1f) * speed * Time.deltaTime * direction);

        if (controller.collisionFlags != 0) {
            Destroy (gameObject);
        }
    }
}
