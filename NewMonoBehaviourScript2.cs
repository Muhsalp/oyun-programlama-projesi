using UnityEngine;

public class NewMonoBehaviourScript2 : MonoBehaviour
{
    public Transform target;

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + new Vector3(0, 4, -8), Time.fixedDeltaTime * 10);
        transform.LookAt(target);
    }
}
