using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleWord : MonoBehaviour
{
    public List<SpriteRenderer> letterSprites = new List<SpriteRenderer>();
    private void Awake()
    {
        foreach (Transform t in transform)
        {
            letterSprites.Add(t.GetComponent<SpriteRenderer>());
        }
        ActivateWord();
    }

    public void ActivateWord()
    {
        for(int i = 0; i < letterSprites.Count; i++)
        {
            letterSprites[i].color = Color.red;
        }
    }
}
