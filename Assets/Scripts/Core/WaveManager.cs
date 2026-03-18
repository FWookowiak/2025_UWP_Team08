using System.Collections;
using UnityEngine;

public class WaveManager : MonoBehaviour{
    public static WaveManager Instance{ get; private set; }
    
    public EnemyFactory enemyFactory;
    public Transform spawnPoint;
    public WaveData[] allRounds;
    private int currentRoundIndex = 0;
    public int enemiesAlive = 0;

    private void Awake(){
        if (Instance != null && Instance != this){
            Debug.LogWarning("Znaleziono duplikat WaveManager! Niszczę go.");
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void StartNextRound(){
        if (currentRoundIndex < allRounds.Length){
            WaveData currentWave = allRounds[currentRoundIndex];
            StartCoroutine(SpawnWaveSequence(currentWave));
            currentRoundIndex++;
        }
        else{
            Debug.Log("Wygrałeś poziom!");
        }
    }

    private IEnumerator SpawnWaveSequence(WaveData wave){
        foreach (WaveGroup group in wave.waveGroup){
            for (int i = 0; i < group.count; i++){
                EnemyBase spawnedEnemy = enemyFactory.CreateEnemy(group.enemyPrefab, spawnPoint.position);
                enemiesAlive++;

                if (i < group.count - 1){
                    yield return new WaitForSeconds(group.spawnInterval);
                }
            }

            yield return new WaitForSeconds(group.delayBeforeNextGroup);
        }
    }

    public void OnEnemyRemoved(){
        enemiesAlive--;

        if (enemiesAlive <= 0){
            Debug.Log("Fala pokonana! Możesz odpalić kolejną.");
        }
    }
}