using System;
using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    Player player;
    [SerializeField] Bullet bulletPrefab;
    [SerializeField] Transform bulletSpawnPoint; 
    [SerializeField, Range(0,100)] float shootDistance = 20;
    [SerializeField, Range(0.1f, 5f)] float secondsBetweenShoots = 0.5f;
    [SerializeField] float shootForce = 1000;
    [SerializeField] float health = 50f;
    public AudioSource audio;

    void Awake() {
        player = FindObjectOfType<Player>();
        StartCoroutine(ShootCoroutine());
    }

    IEnumerator ShootCoroutine() {
        CreateContainerForBullets();
        while (true) {
            yield return new WaitForSeconds(secondsBetweenShoots);
            if (IsPlayerCloseEnough())
                Shoot();
        }
    }

    static void CreateContainerForBullets() {
        if (GameObject.Find("/Bullets") == null) {
            var bulltes = Instantiate(new GameObject());
            bulltes.transform.name = "Bullets";
        }
    }

    void Shoot() {
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity, GameObject.Find("/Bullets").transform);
        
        var playerDirection = (player.transform.position - bulletSpawnPoint.position).normalized;
        bullet.GetComponent<Rigidbody>().AddForce(playerDirection * shootForce, ForceMode.VelocityChange);
    }

    bool IsPlayerCloseEnough() {
        return Vector3.Distance(player.transform.position, transform.position) < shootDistance;
    }

    void Update() {
        transform.LookAt(player.transform.position);
    }

    void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(transform.position, shootDistance);
    }
    

    public float TakeDamage(float amount)
    {
        health -= amount;
        

        if (health < 0)
        {
            audio.Play();
            Die();
            
        }
        return amount;
    }



    void Die()
    {
        
        Destroy(gameObject);
    }

}