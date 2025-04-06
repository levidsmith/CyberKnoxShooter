//2025 Levi D. Smith <developer@levidsmith.com>
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour {
    public GameManager gamemanager;
    public GameObject PanelLevelComplete;
    public GameObject PanelGameComplete;
    public TMP_Text textGameCompletedTime;

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
        int iSeconds = Mathf.FloorToInt(gamemanager.fGameTime);
        textGameCompletedTime.text = string.Format("{0:0}:{1:00}", iSeconds / 60, iSeconds % 60);
        PanelGameComplete.SetActive(true);

    }

    public void hideGameComplete() {
        PanelGameComplete.SetActive(false);
    }

}
