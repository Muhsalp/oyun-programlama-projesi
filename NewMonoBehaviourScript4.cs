using UnityEngine;

public class NewMonoBehaviourScript4 : MonoBehaviour
{
    public Vector3 targetPosition;

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 5);
    }
}
