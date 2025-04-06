//2025 Levi D. Smith
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMenu : MonoBehaviour {

    float fRulesScroll;
    float fTitleTextScale;
    public GameObject canvasRules;
    public GameObject textTitle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        fRulesScroll = -12f;
        fTitleTextScale = 0f;
        
    }

    // Update is called once per frame
    void Update() {
        if (fRulesScroll < 0f) {
            fRulesScroll += Time.deltaTime;
            if (fRulesScroll > 0f) {
                fRulesScroll = 0f;
            }
        }

        if (fTitleTextScale < 1.8f) {
            fTitleTextScale += Time.deltaTime;
            if (fTitleTextScale > 1.8f) {
                fTitleTextScale = 1.8f;
            }
        }

        canvasRules.transform.position = new Vector3(5.1f, fRulesScroll, 0f);
        textTitle.transform.localScale = new Vector3(1f, fTitleTextScale, 1f);
        
    }

    public void doStart() {
        SceneManager.LoadScene("game");
    }

    public void doQuit() {
        Application.Quit();
    }

}
