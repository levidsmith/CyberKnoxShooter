//2025 Levi D. Smith <developer@levidsmith.com>
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour {
    public GameManager gamemanager;
    public GameObject PanelLevelComplete;
    public GameObject PanelGameComplete;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void doNextLevel() {
        gamemanager.nextLevel();

    }

    public void showLevelComplete() {
        PanelLevelComplete.SetActive(true);

    }

    public void hideLevelComplete() {
        PanelLevelComplete.SetActive(false);

    }

    public void doReturnToTitle() {
        SceneManager.LoadScene("title");
    }

    public void showGameComplete() {
        PanelGameComplete.SetActive(true);
    }

    public void hideGameComplete() {
        PanelGameComplete.SetActive(false);
    }

}
