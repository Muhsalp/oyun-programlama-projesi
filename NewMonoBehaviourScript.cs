using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public LayerMask groundLayer;
    private int currentLane = 1;
    private Rigidbody rb;
    public static int score;
    public AudioSource coinSound;
    public AudioSource obstacleSound;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)){
            currentLane = Mathf.Clamp(currentLane - 1, 0, 2);
        }

        if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)){
            currentLane = Mathf.Clamp(currentLane + 1, 0, 2);
        }

        if(Physics.Raycast(transform.position, Vector3.down, 1.1f, groundLayer) && Input.GetKeyDown(KeyCode.Space)){
            rb.AddForce(Vector3.up * 7, ForceMode.Impulse);
        }

        if(transform.position.y < -5){
            SceneManager.LoadScene("MainMenu");
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(Vector3.forward * 10 * Time.fixedDeltaTime + Vector3.Lerp(rb.position, new Vector3((currentLane - 1) * 3, rb.position.y, rb.position.z), Time.fixedDeltaTime * 10));
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Coin")){
            score++;
            coinSound.Play();
            Destroy(other.gameObject);
        }else if(other.CompareTag("Obstacle")){
            obstacleSound.Play();
            SceneManager.LoadScene("MainMenu");
        }else if(other.CompareTag("Bullet")){
            obstacleSound.Play();
            Destroy(other.gameObject);
            SceneManager.LoadScene("MainMenu");
        }
    }
}
