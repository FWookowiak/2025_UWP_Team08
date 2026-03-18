using UnityEngine;

[CreateAssetMenu(menuName = "Wave/WaveGroup")]
public class WaveGroup : ScriptableObject{
    public GameObject enemyPrefab;
    public int count;
    public float spawnInterval = 1f;
    public float delayBeforeNextGroup;
}
