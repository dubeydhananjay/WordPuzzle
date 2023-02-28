using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private static GameManager instance;
    public static GameManager Instance => instance;
    public List<LevelWordSO> levelWordSOs;
    [SerializeField]
    private Level[] levels;
    private int levelCount;

    private void Awake() {
        instance = this;
        levels = FindObjectsOfType<Level>();
    }

    private void Start() {
        NextLevel();
    }

    public void NextLevel() {
        int count = levels.Length;
        for (int i = 0; i < count; i++) {
            levels[i].levelWordSO = levelWordSOs[levelCount];
            levels[i].Initialize();
        }

        levelCount++;
        if (levelCount >= levelWordSOs.Count)
            levelCount = 0;
    }
}
