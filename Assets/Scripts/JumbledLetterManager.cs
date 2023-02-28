using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumbledLetterManager : Level {
   
    private int letterCount;
    private float rad = 0.35f;
    private string longestWord;
    [SerializeField]
    private Transform puzzledLetterParent;
    public PuzzleLetter puzzleLetter;

    private void SetJumbledLetters() {
        longestWord = levelWordSO.LongestWord();
        letterCount = longestWord.Length;
        SetPuzzledLetters();
    }

    //Set the puzzle letters in the circle by number of letter from SO i.e LevelWordSO and setting it in equidistant.
    private void SetPuzzledLetters() {
        float step = 360 / letterCount;
        for (int i = 0; i < letterCount; i++) {
            float theta = i * step;
            float x = rad * (Mathf.Cos(theta * Mathf.Deg2Rad));
            float y = rad * (Mathf.Sin(theta * Mathf.Deg2Rad));
            PuzzleLetter pl = Instantiate(puzzleLetter, puzzleLetter.transform.parent);
            pl.gameObject.SetActive(true);
            pl.transform.localPosition = new Vector3(x, y, 0);
            pl.ActivateColor(false);
            pl.SetLetter(longestWord.Substring(i, 1));
            ShuffleJumbledLetters.Instance.AddLetters(pl.transform);
        }
        ShuffleJumbledLetters.Instance.ShuffleLetters();
    }

    public override void Initialize() {
        ClearPuzzleLetters();
        SetJumbledLetters();
    }

    private void ClearPuzzleLetters() {
        for (int i = puzzledLetterParent.childCount - 1; i > 0; i--) {
            Destroy(puzzledLetterParent.GetChild(i).gameObject);
        }
        ShuffleJumbledLetters.Instance.ClearLetters();
    }
}
