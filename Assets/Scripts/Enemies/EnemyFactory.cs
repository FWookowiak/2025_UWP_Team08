using UnityEngine;

public class EnemyFactory : MonoBehaviour {
    public Transform enemiesContainer; 

    // Główna metoda tworząca wroga
    public EnemyBase CreateEnemy(GameObject enemyPrefab, Vector3 spawnPosition){
        GameObject newEnemyObj = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        
        if (enemiesContainer != null){
            newEnemyObj.transform.SetParent(enemiesContainer);
        }
        EnemyBase enemyComponent = newEnemyObj.GetComponent<EnemyBase>();
        if (enemyComponent == null){
            Debug.LogError($"BŁĄD: Prefab {enemyPrefab.name} nie posiada skryptu dziedziczącego po EnemyBase!");
        }


        return enemyComponent;
    }
}
