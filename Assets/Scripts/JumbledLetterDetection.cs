using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumbledLetterDetection : MonoBehaviour {
    private ConnectingLine connectingLine;
    private Vector2 touchpoint;
    private Camera mainCamera;
    private List<PuzzleLetter> jls;
    private bool firstJL;
    [SerializeField]
    private TMPro.TextMeshPro textMesh;

    private void Awake() {
        touchpoint = Vector2.zero;
        mainCamera = Camera.main;
        jls = new List<PuzzleLetter>();
        connectingLine = FindObjectOfType<ConnectingLine>();
        SetText(string.Empty);
    }

    //Line renderer is used to connect the letters when detecting using the touch.
    //Once the letter is detected, it will be stored and once the touch is gone
    //the letters stored will be used to check if a valid word has been generated.
    private void Update() {
        if(Input.GetMouseButton(0)) {
            touchpoint = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit2D = Physics2D.Raycast(touchpoint, mainCamera.transform.forward);
            if (!hit2D) return;
            PuzzleLetter jl = hit2D.collider.GetComponent<PuzzleLetter>();
            if (!jl) return;
            ShuffleJumbledLetters.Instance.Activation(false);
            jl.ActivateColor(true);
            jl.ColliderActivation(false);
            jls.Add(jl);
            SetText(jl.Letter,false);
            Vector2 pos = jl.transform.position;
            if (!firstJL) {
                firstJL = true;
                connectingLine.SetStartPos(pos);
                return;
            }
            connectingLine.SetLinePos(pos);
            
        }
        else {
            RevealLetters.Instance.RevealDetectedLetters(textMesh.text);
            firstJL = false;
            ResetJumbledLetters();
            connectingLine.ResetSizeAndPos();
            ShuffleJumbledLetters.Instance.Activation(true);
        }
    }

    private void ResetJumbledLetters() {
        SetText(string.Empty);
        int count = jls.Count;
        for(int i = 0; i < count; i++) {
            jls[i].ActivateColor(false);
            jls[i].ColliderActivation(true);
        }
        jls.Clear();
    }

    private void SetText(string txt,bool noText = true) {
        if(noText) {
            textMesh.text = txt;
            return;
        }
        textMesh.text += txt;
    }
}
