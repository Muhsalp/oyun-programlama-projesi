using UnityEngine;

public class NewMonoBehaviourScript5 : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(Vector3.up * 180 * Time.deltaTime, Space.World);
    }
}
