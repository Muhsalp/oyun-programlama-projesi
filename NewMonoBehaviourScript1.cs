using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NewMonoBehaviourScript1 : MonoBehaviour
{
    public GameObject roadPrefab;
    public float segmentLength;
    public Transform player;
    private Queue<GameObject> roadSegments = new Queue<GameObject>();
    private float spawnZ = 0;

    void Start()
    {
        segmentLength = roadPrefab.transform.Find("Middle").GetComponent<Renderer>().bounds.size.z;
        
        for(int i=0; i<5; i++){
            SpawnSegment(false);
        }
    }

    void Update()
    {
        if(player.position.z-30f > spawnZ-(segmentLength*5)){
            SpawnSegment(true);
            RemoveOldSegment();
        }
    }

    void SpawnSegment(bool DisableLane){
        GameObject obj = Instantiate(roadPrefab, new Vector3(0, 0, spawnZ), roadPrefab.transform.rotation);
        roadSegments.Enqueue(obj);
        NewMonoBehaviourScript10 segmentScript = obj.GetComponent<NewMonoBehaviourScript10>();
        spawnZ += segmentLength;
        
        if(DisableLane && Random.value < 0.5f){
            StartCoroutine(SpawnCylinder(segmentScript, Random.value>0.5f?"Left":"Right"));
        }
    }

    void RemoveOldSegment(){
        Destroy(roadSegments.Dequeue());
    }
    
    IEnumerator SpawnCylinder(NewMonoBehaviourScript10 segmentScript, string laneName){
        yield return new WaitForSeconds(3);
        NewMonoBehaviourScript3 enemy = FindFirstObjectByType<NewMonoBehaviourScript3>();

        if(laneName=="Left"){
            enemy.SpawnCylinderAtPosition(segmentScript.leftLane.transform.position);
        }else if(laneName=="Right"){
            enemy.SpawnCylinderAtPosition(segmentScript.rightLane.transform.position);
        }

        StartCoroutine(DisableLaneAfterDelay(segmentScript, laneName));
    }

    IEnumerator DisableLaneAfterDelay(NewMonoBehaviourScript10 segmentScript, string laneName){
        yield return new WaitForSeconds(0.1f);
        segmentScript.DisableLane(laneName);
    }
}
