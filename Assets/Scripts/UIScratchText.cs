using TMPro;
using UnityEngine;

public class UIScratchText : MonoBehaviour {
    [SerializeField] TextMeshProUGUI textMeshPro;

    protected void OnEnable() {
        GameManager.onTotalMoveUpdate += HandleMoveUpdate;
    }

    protected void OnDisable() {
        GameManager.onTotalMoveUpdate -= HandleMoveUpdate;
    }

    void HandleMoveUpdate(float current, float total) {
        int percent = (int)(current / total * 100f);
        textMeshPro.text = $"{percent}%";
    }

    protected void OnValidate() {
        if (!textMeshPro) {
            TryGetComponent(out textMeshPro);
        }
    }
}
