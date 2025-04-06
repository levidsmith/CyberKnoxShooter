//2025 Levi D. Smith
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMenu : MonoBehaviour {

    float fRulesScroll = -12f;
    public GameObject canvasRules;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (fRulesScroll < 0f) {
            fRulesScroll += Time.deltaTime;
            if (fRulesScroll > 0f) {
                fRulesScroll = 0f;
            }
        }
        canvasRules.transform.position = new Vector3(5.1f, fRulesScroll, 0f);
        
    }

    public void doStart() {
        SceneManager.LoadScene("game");
    }

    public void doQuit() {
        Application.Quit();
    }

}
