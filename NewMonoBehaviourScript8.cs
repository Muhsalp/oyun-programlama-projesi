using UnityEngine;

public class NewMonoBehaviourScript8 : MonoBehaviour
{
    private static NewMonoBehaviourScript8 instance;

    void Awake()
    {
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }
    }
}
