using UnityEngine;

public class NewMonoBehaviourScript10 : MonoBehaviour
{
    public GameObject leftLane;
    public GameObject rightLane;

    public void DisableLane(string laneName){
        if(laneName == "Left"){
            leftLane.SetActive(false);
        }else if(laneName == "Right"){
            rightLane.SetActive(false);
        }
    }
}
