//2025 Levi D. Smith <developer@levidsmith.com>
using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject objLevel;
    public GameObject EnemyPrefab;
    public GameObject ShipPrefab;

    public GameMenu gamemenu;
    public Level level;

    public DataReader datareader;

    int iLevel;
    bool isCompleted;

    float fGenerationTimeout;
    float fGenerationMaxTimeout;

    public DisplayManager displaymanager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        Debug.Log("GameManager Start");
        iLevel = 0;
        level.strName = datareader.getLevelName(iLevel);
        displaymanager.textLevelName.text = level.strName;
        level.createLevel(datareader.getLevel(iLevel));
        isCompleted = false;
        fGenerationMaxTimeout = 5f;
        fGenerationTimeout = fGenerationMaxTimeout;
        
    }

    // Update is called once per frame
    void Update() {
        if (!isCompleted) {
            Debug.Log("check level complete");

            if (level.checkLevelComplete()) {
                if (iLevel < 2) {
                    gamemenu.showLevelComplete();
                } else {
                    gamemenu.showGameComplete();
                }

            }


            fGenerationTimeout -= Time.deltaTime;
            if (fGenerationTimeout <= 0f) {
                level.createNextGeneration();
                fGenerationTimeout += fGenerationMaxTimeout;
            }
        }

        
    }



    public void nextLevel() {
        iLevel++;

        level.clearLevel();
        level.strName = datareader.getLevelName(iLevel);
        displaymanager.textLevelName.text = level.strName;
        level.createLevel(datareader.getLevel(iLevel));
        isCompleted = false;
        gamemenu.hideLevelComplete();
    }
}
