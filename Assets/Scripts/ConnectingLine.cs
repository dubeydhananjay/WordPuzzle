using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectingLine : MonoBehaviour {
    private LineRenderer lineRenderer;
    private int index;
    private Dictionary<int, Vector2> postDict = new Dictionary<int, Vector2>();

    private void Awake() {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void SetLinePos(Vector2 letterPos) {
        Vector3 pos = letterPos;
        index += 1;
        lineRenderer.positionCount += 1;
        lineRenderer.SetPosition(index, pos);
        postDict.Add(index, letterPos);
    }

    public void ResetSizeAndPos() {
        index = 0;
        lineRenderer.positionCount = 1;
        postDict.Clear();
    }

    public void SetStartPos(Vector2 pos) {
        lineRenderer.SetPosition(0, pos);
        postDict.Add(index, pos);
    }
}
