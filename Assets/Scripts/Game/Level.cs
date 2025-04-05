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
        Debug.Log("Level Start");


    }

    // Update is called once per frame
    void Update() {
        
    }


    public void createLevel(bool[,] inLevelLayout) {
        

        Ship ship = Instantiate(ShipPrefab, Vector3.zero, Quaternion.identity).GetComponent<Ship>();
        ship.transform.SetParent(this.transform);


        levelLayout = inLevelLayout;
        levelEnemies = new Enemy[DataReader.LEVEL_ROWS, DataReader.LEVEL_COLS];

        int iRows = DataReader.LEVEL_ROWS;
        int iCols = DataReader.LEVEL_COLS;

        int i, j;
        for (i = 0; i < DataReader.LEVEL_ROWS; i++) {

            for (j = 0; j < DataReader.LEVEL_COLS; j++) {
                if (levelLayout[i, j]) {
                    createEnemyAt(i, j);
                }

            }
        }

        Debug.Log("level created");
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


                if (levelEnemies[i, j] != null) {
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
                if (levelEnemies[i,j] == null && levelNextLayout[i, j]) {
                    createEnemyAt(i, j);
                }

                if (levelEnemies[i, j] != null && !levelNextLayout[i, j]) {
                    Destroy(levelEnemies[i, j].gameObject);
                }
            }
        }


            }

    public void createEnemyAt(int i, int j) {
        Vector3 vectOffset = new Vector3(DataReader.LEVEL_ROWS * -0.5f, 0f, DataReader.LEVEL_COLS * 0.5f);

        if (levelEnemies[i, j] == null) {

            Enemy enemy = Instantiate(EnemyPrefab, vectOffset + new Vector3(j * 1f, 0f, i * -1f), Quaternion.identity).GetComponent<Enemy>();
            enemy.transform.SetParent(transform);
            levelEnemies[i, j] = enemy;
        }
    }

    private int getNeighborCount(int i, int j) {
        int iCount;
        iCount = 0;

        int iMod, jMod;

        iMod = getCellRow(i - 1);
        jMod = getCellCol(j - 1);
        if (levelEnemies[iMod, jMod] != null) {
            iCount++;
        }

        iMod = getCellRow(i - 1);
        jMod = getCellCol(j);
        if (levelEnemies[iMod, jMod] != null) {
            iCount++;
        }

        iMod = getCellRow(i - 1);
        jMod = getCellCol(j + 1);
        if (levelEnemies[iMod, jMod] != null) {
            iCount++;
        }

        iMod = getCellRow(i);
        jMod = getCellCol(j - 1);
        if (levelEnemies[iMod, jMod] != null) {
            iCount++;
        }

        iMod = getCellRow(i);
        jMod = getCellCol(j + 1);
        if (levelEnemies[iMod, jMod] != null) {
            iCount++;
        }


        iMod = getCellRow(i + 1);
        jMod = getCellCol(j - 1);
        if (levelEnemies[iMod, jMod] != null) {
            iCount++;
        }

        iMod = getCellRow(i + 1);
        jMod = getCellCol(j);
        if (levelEnemies[iMod, jMod] != null) {
            iCount++;
        }

        iMod = getCellRow(i + 1);
        jMod = getCellCol(j + 1);
        if (levelEnemies[iMod, jMod] != null) {
            iCount++;
        }

        Debug.Log("neighbor count: " + iCount);

//        return 1;
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
            Destroy(transform.GetChild(i).gameObject);
        }
    }

    public bool checkLevelComplete() {
        Enemy[] enemyArray = GetComponentsInChildren<Enemy>();

        //        Debug.Log("CheckLevelComplete: " + enemyArray.Length);




        if (enemyArray.Length == 0) {
            Debug.Log("Level Completed");
            return true;

        }
        return false;
    }




}
