using UnityEngine;

public class Gun : MonoBehaviour
{
   public Transform bulletSpawnPoint;

    public float damage = 10f;
    public float range = 100f;

    public Camera fpsCam;
    public ParticleSystem MuzzleFlash;
    public GameObject impactEffect;
    public float impactForce = 30f;
    public float fireRate = 5f;

    private float nextTimeToFire = 0f;


    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }    
    }


    void Shoot()
    {
        MuzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {

            Debug.Log(hit.transform.name);

            EnemyController target = hit.transform.GetComponent<EnemyController>();
            nonEnemy target2 = hit.transform.GetComponent<nonEnemy>();

            if (target2 != null)
            {
                target2.TakeDamage(damage);
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            if (target != null)
            {
                target.TakeDamage(damage);
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
            
            GameObject impactGO =  Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 1f);
        }

    }
}
