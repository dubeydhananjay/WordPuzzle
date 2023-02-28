using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealLetters : Level {
    private static RevealLetters instance;
    public static RevealLetters Instance => instance;
    private Grid grid;
    [SerializeField]
    private float delay = 0.5f;
    private int wordCount;

    private void Awake() {
        if (instance == null) instance = this;
        grid = FindObjectOfType<Grid>();
    }

    //Once the touch is gone, the letters stored will pass the word here
    //From LevelWordSO, the word will be checked horizontally or vertically and the letters
    //in the blocks will be activated.
    public void RevealDetectedLetters(string word) {
        Block block = grid.BlockByName(levelWordSO.GetBlockName(word));
        if (block == null) return;
        char[] wordCharArray = word.ToCharArray();
        if (levelWordSO.CheckVertically)
            RevealLettersVertically(block, wordCharArray);
        else
            RevealLettersHorzontally(block, wordCharArray);
        wordCount++;
        if (wordCount >= levelWordSO.WordCount)
            StartCoroutine(WaitToActivateHUD());
    }

    private void RevealLettersVertically(Block block, char[] wordCharArray) {
        for(int i = 0; i < wordCharArray.Length; i++) {
            block.ActivateLetter();
            Vector3 pos = block.transform.position;
            pos.y -= grid.constVal;
            block = grid.BlockByPos(pos);
        }
    }

    private void RevealLettersHorzontally(Block block, char[] wordCharArray) {
        for (int i = 0; i < wordCharArray.Length; i++) {
            block.ActivateLetter();
            Vector3 pos = block.transform.position;
            pos.x += grid.constVal;
            block = grid.BlockByPos(pos);
        }
    }

    private IEnumerator WaitToActivateHUD() {
        wordCount = 0;
        yield return new WaitForSeconds(delay);
        GameManager.Instance.NextLevel();
    }
    public override void Initialize() {
        
    }
}
