using UnityEngine;

public class Gun : MonoBehaviour
{
   public Transform bulletSpawnPoint;

    public float damage = 10f;
    public float range = 100f;

    public Camera fpsCam;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }    
    }


    void Shoot()
    {

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {

            Debug.Log(hit.transform.name);

            EnemyController   target = hit.transform.GetComponent<EnemyController>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }

    }
}
