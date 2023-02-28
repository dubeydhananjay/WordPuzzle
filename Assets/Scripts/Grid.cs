using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Grid : MonoBehaviour {
    public float constVal = 1.5f;
    public Block block;
    public List<Block> blocks = new List<Block>();

    //generating grids by taking row and col from the current level i.e from SO LevelWordSO
    public void GridGen(int row,int col) {
        ClearBlocks();
        float x = 0;
        float y = 0;
        Block g = null;
        for (int i = 0; i < row; i++) {
            for(int j = 0; j < col; j++) {
                g = Instantiate(block,block.transform.parent);
                g.transform.localPosition = new Vector2(x, y);
                g.name = string.Format("B{0}{1}", i, j);
                blocks.Add(g);
                x = g.transform.localPosition.x + constVal;
            }
            y = g.transform.localPosition.y + constVal;
            x = 0;
        }
    }

    public Block BlockByPos(Vector3 pos) {
        return blocks.Where(x => x.transform.position == pos).FirstOrDefault();
    }

    public Block BlockByName(string name) {
        return blocks.Where(b => b.name == name).FirstOrDefault();
    }

    private void ClearBlocks() {
        if (blocks == null || blocks.Count <= 0) return;
        for(int i = transform.childCount - 1; i > 0; i--) {
            Destroy(transform.GetChild(i).gameObject);
        }
        blocks.Clear();
    }
}
