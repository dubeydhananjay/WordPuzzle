using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleLetter : MonoBehaviour {
    private TMPro.TextMeshPro textMesh;
    private Collider2D col;
    private SpriteRenderer spriteRenderer;

    public string Letter => textMesh.text;

    private void Awake() {
        textMesh = GetComponentInChildren<TMPro.TextMeshPro>();
        col = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetLetter(string letter) {
        textMesh.text = letter;
    }

    public void ColliderActivation(bool enable) {
        col.enabled = enable;
    }

    public void ActivateColor(bool enable) {
        Color color = spriteRenderer.color;
        color.a = enable ? 1 : 0;
        spriteRenderer.color = color;
    }
}
