//2025 Levi D. Smith
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMenu : MonoBehaviour {
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void doStart() {
        SceneManager.LoadScene("game");
    }

    public void doQuit() {
        Application.Quit();
    }

}
