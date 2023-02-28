using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridWordSetter : Level
{
    private Grid grid;

    private void Awake() {
        grid = GetComponent<Grid>();
    }

    //Adding words from current level either horizontally or vertically from SO LevelWordSO
    public void AddWords() {
        int count = levelWordSO.WordSetters.Count;
        for(int i = 0; i < count; i++) {
            string word = levelWordSO.WordSetters[i].word;
            char[] wordCharArray = word.ToCharArray();
            string blockname = string.Format("B{0}{1}", levelWordSO.WordSetters[i].row, levelWordSO.WordSetters[i].col);
            Block block = grid.BlockByName(blockname);
            if (levelWordSO.WordSetters[i].vertical)
                AddLettersVertically(wordCharArray, block);
            else
                AddLettersHorizontally(wordCharArray, block);
        }
    }

    public void AddLettersVertically(char[] wordCharArray, Block block) {
        int count = wordCharArray.Length;
        for(int i = 0; i < count; i++) {
            block.SetLetter(wordCharArray[i].ToString());
            Vector3 pos = block.transform.position;
            pos.y -= grid.constVal;
            block = grid.BlockByPos(pos);
        }
    }

    public void AddLettersHorizontally(char[] wordCharArray, Block block) {
        int count = wordCharArray.Length;
        for (int i = 0; i < count; i++) {
            block.SetLetter(wordCharArray[i].ToString());
            Vector3 pos = block.transform.position;
            pos.x += grid.constVal;
            block = grid.BlockByPos(pos);
        }
    }

    public override void Initialize() {
        grid.GridGen(levelWordSO.Row, levelWordSO.Col);
        AddWords();
    }
}
