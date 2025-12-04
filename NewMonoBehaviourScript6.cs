using UnityEngine;
using TMPro;

public class NewMonoBehaviourScript6 : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Update()
    {
        scoreText.text = NewMonoBehaviourScript.score.ToString();
    }
}
