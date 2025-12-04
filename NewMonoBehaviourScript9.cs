using UnityEngine;

public class NewMonoBehaviourScript9 : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    private float timer = 5;

    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0){
            Shoot();
            timer = Random.Range(0.1f, 5);
        }
    }

    void Shoot(){
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position + new Vector3(0, -4.5f, 0), Quaternion.identity);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.linearVelocity = Vector3.forward * -30;
    }
}
