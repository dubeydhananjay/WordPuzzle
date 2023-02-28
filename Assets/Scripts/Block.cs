using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshPro textMesh;

    public bool ActivatedBlock { get; set; }

    public void SetLetter(string letter) {
        textMesh.text = letter;
        ActivatedBlock = true;
        gameObject.SetActive(true);
    }

    public void ActivateLetter() {
        textMesh.gameObject.SetActive(true);
    }
}
