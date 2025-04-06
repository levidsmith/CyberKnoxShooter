//2025 Levi D. Smith <developer@levidsmith.com>
using TMPro;
using UnityEngine;

public class DisplayManager : MonoBehaviour {

    public TMP_Text textLevelName;
    public TMP_Text textGameTime;
    public GameManager gamemanager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        int iSeconds = Mathf.FloorToInt(gamemanager.fGameTime);
        textGameTime.text = string.Format("{0:0}:{1:00}", iSeconds / 60, iSeconds % 60);
        
    }
}
