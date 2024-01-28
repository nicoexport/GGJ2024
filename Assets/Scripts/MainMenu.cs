using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    [SerializeField] GameObject main;
    [SerializeField] GameObject credits;

    protected void Start() {
        main.SetActive(true);
        credits.SetActive(false);
    }

    public void GoToCredits() {
        main.SetActive(false);
        credits.SetActive(true);
    }

    public void GoToMain() {
        main.SetActive(true);
        credits.SetActive(false);
    }

    public void Play() {
        SceneManager.LoadScene(1);
    }

    public void Quit() {
        Application.Quit();
    }
}

