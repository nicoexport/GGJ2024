using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UISummary : MonoBehaviour {
    [SerializeField] Button restartButton;
    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    [SerializeField] Button returnButton;

    protected void OnEnable() {
        restartButton.onClick.AddListener(Restart);
        returnButton.onClick.AddListener(Return);
        GameManager.onWin += HandleWin;
        GameManager.onLose += HandleLose;
    }

    void Return() => SceneManager.LoadScene(0);

    protected void OnDisable() {
        restartButton.onClick.RemoveListener(Restart);
        returnButton.onClick.RemoveListener(Return);
        GameManager.onWin -= HandleWin;
        GameManager.onLose -= HandleLose;
    }

    protected void Start() {
        restartButton.gameObject.SetActive(false);
        returnButton.gameObject.SetActive(false);
        textMeshProUGUI.gameObject.SetActive(false);
    }

    void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    void HandleWin() {
        restartButton.gameObject.SetActive(true);
        textMeshProUGUI.gameObject.SetActive(true);
        returnButton.gameObject.SetActive(true);
        textMeshProUGUI.text = "YOU WIN";
    }

    void HandleLose() {
        restartButton.gameObject.SetActive(true);
        textMeshProUGUI.gameObject.SetActive(true);
        returnButton.gameObject.SetActive(true);
        textMeshProUGUI.text = "YOU LOSE";
    }
}
