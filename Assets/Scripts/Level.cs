using UnityEngine;
public abstract class Level : MonoBehaviour {
    public LevelWordSO levelWordSO { get; set; }
    public abstract void Initialize();
}
