using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UISummary : MonoBehaviour {
    [SerializeField] Button restartButton;
    [SerializeField] TextMeshProUGUI textMeshProUGUI;

    protected void OnEnable() {
        restartButton.onClick.AddListener(Restart);
        GameManager.onWin += HandleWin;
        GameManager.onLose += HandleLose;
    }


    protected void OnDisable() {
        restartButton.onClick.RemoveListener(Restart);
        GameManager.onWin -= HandleWin;
        GameManager.onLose -= HandleLose;
    }

    protected void Start() {
        restartButton.gameObject.SetActive(false);
        textMeshProUGUI.gameObject.SetActive(false);
    }

    void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    void HandleWin() {
        restartButton.gameObject.SetActive(true);
        textMeshProUGUI.gameObject.SetActive(true);
        textMeshProUGUI.text = "YOU WIN";
    }

    void HandleLose() {
        restartButton.gameObject.SetActive(true);
        textMeshProUGUI.gameObject.SetActive(true);
        textMeshProUGUI.text = "YOU LOSE";
    }
}
