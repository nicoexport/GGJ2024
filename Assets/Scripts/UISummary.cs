using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UISummary : MonoBehaviour {
    [SerializeField] Button restartButton;

    protected void OnEnable() {
        restartButton.onClick.AddListener(Restart);
        GameManager.onWin += HandleWin;
    }


    protected void OnDisable() {
        restartButton.onClick.RemoveListener(Restart);
        GameManager.onWin -= HandleWin;
    }

    protected void Start() {
        restartButton.gameObject.SetActive(false);
    }

    void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    void HandleWin() => restartButton.gameObject.SetActive(true);
}
