using TMPro;
using UnityEngine;

public class UITimer : MonoBehaviour {
    [SerializeField] TextMeshProUGUI textMeshProUGUI;

    protected void OnEnable() {
        GameManager.onUpdateTime += HandleTime;
    }

    protected void OnDisable() {
        GameManager.onUpdateTime -= HandleTime;
    }

    void HandleTime(float obj) {
        textMeshProUGUI.text = ((int)obj).ToString();
    }
}
