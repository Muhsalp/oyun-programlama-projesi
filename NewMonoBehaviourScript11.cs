using UnityEngine;

public class NewMonoBehaviourScript11 : MonoBehaviour
{
    public Vector3 targetPosition;

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime / 20);

        if(Vector3.Distance(transform.position, targetPosition) < 100){
            Destroy(gameObject);
        }
    }
}
