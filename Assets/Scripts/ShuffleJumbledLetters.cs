using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(BoxCollider2D))]
public class ShuffleJumbledLetters : MonoBehaviour, IPointerDownHandler {
    private List<Transform> jls;
    private List<Vector3> letterPositions;
    private static ShuffleJumbledLetters instance;
    public static ShuffleJumbledLetters Instance => instance;

    private void Awake() {
        instance = this;
        jls = new List<Transform>();
        letterPositions = new List<Vector3>();
    }

    public void ClearLetters() {
        jls.Clear();
    }

    public void AddLetters(Transform jl) {
        jls.Add(jl);
    }

    public void ShuffleLetters() {
        letterPositions.Clear();
        int count = jls.Count;
        for(int i = 0; i < count; i++) {
            letterPositions.Add(jls[i].transform.position);
        }
        List<Vector3> cachePoses = new List<Vector3>();
        Vector3 pos = Vector3.one;
        for (int i = 0; i < count; i++) {
            do {
                pos = letterPositions[Random.Range(0, count)];
            } while (cachePoses.Contains(pos));
            cachePoses.Add(pos);
            jls[i].transform.position = pos;
        }
    }

    public void OnPointerDown(PointerEventData eventData) {
        ShuffleLetters();
    }

    public void Activation(bool activate) {
        gameObject.SetActive(activate);
    }
}
