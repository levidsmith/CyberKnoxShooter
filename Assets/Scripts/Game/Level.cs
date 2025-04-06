//2025 Levi D. Smith <developer@levidsmith.com>
using UnityEngine;

public class Level : MonoBehaviour {
    public GameObject EnemyPrefab;
    public GameObject ShipPrefab;

    bool[,] levelLayout;
    Enemy[,] levelEnemies;
    public string strName;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {


    }

    // Update is called once per frame
    void Update() {
        
    }


    public void createLevel() {
        

        Ship ship = Instantiate(ShipPrefab, Vector3.zero, Quaternion.identity).GetComponent<Ship>();
        ship.transform.SetParent(this.transform);


        levelEnemies = new Enemy[DataReader.LEVEL_ROWS, DataReader.LEVEL_COLS];

        int i, j;
        for (i = 0; i < DataReader.LEVEL_ROWS; i++) {

            for (j = 0; j < DataReader.LEVEL_COLS; j++) {
                createEnemyAt(i, j);
            }
        }

    }

    public void setupLevel(bool[,] inLevelLayout) {

        levelLayout = inLevelLayout;

        int i, j;
        for (i = 0; i < DataReader.LEVEL_ROWS; i++) {

            for (j = 0; j < DataReader.LEVEL_COLS; j++) {
                if (levelLayout[i, j]) {
                    levelEnemies[i, j].setAlive(true);
                } else {
                    levelEnemies[i, j].setAlive(false);
                }


            }
        }

    }


    public void createNextGeneration() {
        bool[,] levelNextLayout = new bool[DataReader.LEVEL_ROWS, DataReader.LEVEL_COLS];
        int i, j;


        for (i = 0; i < DataReader.LEVEL_ROWS; i++) {
            for (j = 0; j < DataReader.LEVEL_COLS; j++) {
                levelNextLayout[i, j] = false;
            }
        }

        for (i = 0; i < DataReader.LEVEL_ROWS; i++) {
            for (j = 0; j < DataReader.LEVEL_COLS; j++) {

                if (levelEnemies[i, j].gameObject.activeSelf) {
                    if (getNeighborCount(i, j) < 2) {
                        levelNextLayout[i, j] = false;
                    } else if (getNeighborCount(i, j) > 3) {
                        levelNextLayout[i, j] = false;
                    } else {
                        levelNextLayout[i, j] = true;
                    }
                } else { 
                    if (getNeighborCount(i, j) == 3) {
                        levelNextLayout[i, j] = true;
                    }
                
                }



            }
        }

        for (i = 0; i < DataReader.LEVEL_ROWS; i++) {
            for (j = 0; j < DataReader.LEVEL_COLS; j++) {
                if (!levelEnemies[i, j].gameObject.activeSelf && levelNextLayout[i, j]) {
                    levelEnemies[i, j].setAlive(true);
                }

                if (levelEnemies[i, j].gameObject.activeSelf && !levelNextLayout[i, j]) {
                    levelEnemies[i, j].setAlive(false);
                }

                /*
                if (levelEnemies[i,j] == null && levelNextLayout[i, j]) {
                    createEnemyAt(i, j);
                }

                if (levelEnemies[i, j] != null && !levelNextLayout[i, j]) {
                    Destroy(levelEnemies[i, j].gameObject);
                }
                */
            }
        }


            }

    public void createEnemyAt(int i, int j) {
        Vector3 vectOffset = new Vector3(DataReader.LEVEL_ROWS * -0.5f, 0f, DataReader.LEVEL_COLS * 0.5f);

        if (levelEnemies[i, j] == null) {

            Enemy enemy = Instantiate(EnemyPrefab, vectOffset + new Vector3(j * 1f, 0f, i * -1f), Quaternion.identity).GetComponent<Enemy>();
            enemy.transform.SetParent(transform);
            enemy.setAlive(false);
            levelEnemies[i, j] = enemy;
        }
    }

    private int getNeighborCount(int i, int j) {
        int iCount;
        iCount = 0;

        int iMod, jMod;

        iMod = getCellRow(i - 1);
        jMod = getCellCol(j - 1);
        if (levelEnemies[iMod, jMod].gameObject.activeSelf) {
            iCount++;
        }

        iMod = getCellRow(i - 1);
        jMod = getCellCol(j);
        if (levelEnemies[iMod, jMod].gameObject.activeSelf) {
            iCount++;
        }

        iMod = getCellRow(i - 1);
        jMod = getCellCol(j + 1);
        if (levelEnemies[iMod, jMod].gameObject.activeSelf) {
            iCount++;
        }

        iMod = getCellRow(i);
        jMod = getCellCol(j - 1);
        if (levelEnemies[iMod, jMod].gameObject.activeSelf) {
            iCount++;
        }

        iMod = getCellRow(i);
        jMod = getCellCol(j + 1);
        if (levelEnemies[iMod, jMod].gameObject.activeSelf) {
            iCount++;
        }


        iMod = getCellRow(i + 1);
        jMod = getCellCol(j - 1);
        if (levelEnemies[iMod, jMod].gameObject.activeSelf) {
            iCount++;
        }

        iMod = getCellRow(i + 1);
        jMod = getCellCol(j);
        if (levelEnemies[iMod, jMod].gameObject.activeSelf) {
            iCount++;
        }

        iMod = getCellRow(i + 1);
        jMod = getCellCol(j + 1);
        if (levelEnemies[iMod, jMod].gameObject.activeSelf) {
            iCount++;
        }

        //Debug.Log("neighbor count: " + iCount);

        return iCount;
    }

    public int getCellRow(int i) {
        if (i < 0) {
            return i + DataReader.LEVEL_ROWS;
        } else {
            return i % DataReader.LEVEL_ROWS;
        }
    }

    public int getCellCol(int j) {
        if (j < 0) {
            return j + DataReader.LEVEL_COLS;
        } else {
            return j % DataReader.LEVEL_COLS;
        }
    }


    public void clearLevel() {
        int i;
        for (i = 0; i < transform.childCount; i++) {
            //Destroy(transform.GetChild(i).gameObject);
            foreach (Enemy enemy in levelEnemies) {
                enemy.setAlive(false);
            }
        }
    }

    public bool checkLevelComplete() {
        //        Enemy[] enemyArray = GetComponentsInChildren<Enemy>();

        //        Debug.Log("CheckLevelComplete: " + enemyArray.Length);
        
        foreach (Enemy enemy in levelEnemies) {
//            Debug.Log("enemy isAlive: " + enemy.gameObject.activeSelf);
            if (enemy.isActiveAndEnabled) {
                return false;
            }
        }
        return true;
    }




}
