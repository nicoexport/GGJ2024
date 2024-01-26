using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance { get; private set; }


    protected void Awake() {
        if (instance != null && instance != this) {
            Destroy(this);
        } else {
            instance = this;
        }
    }
}
