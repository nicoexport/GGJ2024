using UnityEngine;

public class Background : MonoBehaviour {
    MaterialPropertyBlock block;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Texture2D texture;
    [SerializeField] AnimationCurve curve;

    protected void Awake() {
        block = new();
    }

    protected void OnEnable() {
        GameManager.onTotalMoveUpdate += HandleUpdate;
    }

    protected void OnDisable() {
        GameManager.onTotalMoveUpdate -= HandleUpdate;
    }

    void HandleUpdate(float current, float max) {
        float ratio = current / max;
        ratio = curve.Evaluate(ratio);
        ratio = Mathf.Lerp(0.005f, 0.4f, ratio);
        block.SetFloat("_DistortionAmount", ratio);
        block.SetTexture("_MainTex", texture);
        Debug.Log(current / max);
        spriteRenderer.SetPropertyBlock(block);
    }
}
