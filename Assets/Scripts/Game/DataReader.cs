//2025 Levi D. Smith <developer@levidsmith.com>
using System.Collections.Generic;
using UnityEngine;


public class DataReader : MonoBehaviour {

    public List<TextAsset> textLevels;

    public const int LEVEL_ROWS = 64;
    public const int LEVEL_COLS = 64;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public bool[,] getLevel(int iLevel) {
        bool[,] levelLayout = new bool[LEVEL_ROWS,LEVEL_COLS];

        int i, j;
        i = 0;
        j = 0;
        foreach(string strLine in textLevels[iLevel].ToString().Split('\n')) {
            if (i == 0) {
                i++;
                continue;
            }

            foreach (char c in strLine.ToCharArray()) {
                if (c == 'X' && j < LEVEL_COLS) {
                    levelLayout[i - 1,j] = true;
                }
                j++;
            }
            j = 0;
            i++;
        }


        return levelLayout;

    }

    public string getLevelName(int iLevel) {
        return textLevels[iLevel].ToString().Split('\n')[0];
    }
}
