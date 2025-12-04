using UnityEngine;

public class NewMonoBehaviourScript3 : MonoBehaviour
{
    public Transform player;
    public Transform enemy;
    public GameObject obstaclePrefab;
    public GameObject coinPrefab;
    public GameObject cylinderPrefab;
    private float timer = 0;

    void Update()
    {
        enemy.position = enemy.position + new Vector3(0, 0, Time.deltaTime * 10);
        timer += Time.deltaTime;
        
        if(timer >= 2){
            SpawnObstacle();
            SpawnCoinOnRoad();
            timer = 0;
        }
    }

    void SpawnObstacle(){
        GameObject obs = Instantiate(obstaclePrefab, enemy.position + new Vector3(0, 0, -5), Quaternion.identity);
        NewMonoBehaviourScript4 mover = obs.AddComponent<NewMonoBehaviourScript4>();
        mover.targetPosition = new Vector3((Random.Range(0, 3) - 1) * 3, 0.5f, enemy.position.z - 10);
    }

    void SpawnCoinOnRoad(){
        if(Random.value > 0.5f){
            Instantiate(coinPrefab, new Vector3((Random.Range(0, 3) - 1) * 3, 1.2f, player.position.z + 40), coinPrefab.transform.rotation);
        }
    }

    public void SpawnCylinderAtPosition(Vector3 position){
        Vector3 startPos = enemy.position + new Vector3(0, 0, -4);
        GameObject cyl = Instantiate(cylinderPrefab, startPos, cylinderPrefab.transform.rotation);
        NewMonoBehaviourScript11 mover = cyl.AddComponent<NewMonoBehaviourScript11>();
        mover.targetPosition = position*201 - startPos*200;
    }
}
