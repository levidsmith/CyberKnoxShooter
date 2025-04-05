//2025 Levi D. Smith <developer@levidsmith.com>
using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject objLevel;
    public GameObject EnemyPrefab;
    public GameObject ShipPrefab;

    public GameMenu gamemenu;

    int iLevel;
    bool isCompleted;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        iLevel = 0;
        createLevel(iLevel);
        isCompleted = false;
        
    }

    // Update is called once per frame
    void Update() {
        if (!isCompleted) {
            checkLevelComplete();
        }
        
    }

    public void checkLevelComplete() {
        Enemy[] enemyArray = objLevel.GetComponentsInChildren<Enemy>();

        Debug.Log("CheckLevelComplete: " + enemyArray.Length);

        


        if (enemyArray.Length == 0) {
            Debug.Log("Level Completed");
            isCompleted = true;

            if (iLevel < 2) {
                gamemenu.showLevelComplete();
            } else {
                gamemenu.showGameComplete();
            }
        }
    }

    private void createLevel(int iLevel) {

        Ship ship = Instantiate(ShipPrefab, Vector3.zero, Quaternion.identity).GetComponent<Ship>();
        ship.transform.SetParent(objLevel.transform);

        Vector3 vectOffset = new Vector3(-20f, 0f, 0f);
        int i, j;
        for (i = 0; i < 3 + iLevel; i++) {
            for (j = 0; j < 5 + (iLevel * 2); j++) {
                Enemy enemy = Instantiate(EnemyPrefab, vectOffset + new Vector3(j * 1f, 0f, i * 1f), Quaternion.identity).GetComponent<Enemy>();
                enemy.transform.SetParent(objLevel.transform);
            }
        }
        isCompleted = false;

    }

    public void clearLevel() {
        int i;
        for (i = 0; i < objLevel.transform.childCount; i++) {
            Destroy(objLevel.transform.GetChild(i).gameObject);
        }
    }

    public void nextLevel() {
        iLevel++;
        clearLevel();
        createLevel(iLevel);
        gamemenu.hideLevelComplete();
    }
}
