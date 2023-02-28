using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

//Scriptable Object(SO) for different levels, where words can be added along with its position and other datas.
[CreateAssetMenu(fileName = "CreateLevelWord", menuName = "Level/Word", order = 1)]
public class LevelWordSO : ScriptableObject {

    [SerializeField]
    private List<WordSetter> wordSetters; // All the words that needs to be set will be added here.
    public List<WordSetter> WordSetters => wordSetters;

    [SerializeField]
    private int row;
    [SerializeField]
    private int col;
    private bool checkVerically;

    public int Row => row;
    public int Col => col;
    public bool CheckVertically => checkVerically;
    public int WordCount => wordSetters.Count;

    //using this function to get the longest word as it will contain all the letters.
    public string LongestWord() {
        int count = wordSetters.Count;
        string longestWord = string.Empty;
        for(int i = 0; i < count; i++) {
            string word = wordSetters[i].word;
            if (word.Length >= longestWord.Length)
                longestWord = word;
        }
        return longestWord;
    }

    public string GetBlockName(string word) {
        WordSetter wordSetter = wordSetters.Where(w => w.word == word).FirstOrDefault();
        if (wordSetter == null || wordSetter.wordChecked) return string.Empty;
        checkVerically = wordSetter.vertical;
        wordSetter.wordChecked = true;
        string blockName = string.Format("B{0}{1}", wordSetter.row, wordSetter.col);
        return blockName;
    }

    public void Reset() {
        for(int i = 0; i < wordSetters.Count; i++) {
            wordSetters[i].wordChecked = false;
        }
    }

    //All details of every word that needs to be set.
    [Serializable]
    public class WordSetter {
        public string word;
        public int row;
        public int col;
        public bool vertical;
        public bool wordChecked;
    }
   
}
