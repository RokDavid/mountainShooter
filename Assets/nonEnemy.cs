using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nonEnemy : MonoBehaviour
{
    [SerializeField] float health = 50f;
    public ParticleSystem fire;

    public float TakeDamage(float amount)
    {
        health -= amount;


        if (health < 20)
        {

            if (health < 0)
            {
                SetFire();
                Die();
            }
            

        }
        return amount;
    }


    void SetFire()
    {
        var location = gameObject.transform.position;
        Instantiate(fire);
        fire.Play();
        fire.transform.position = location;
    }

    void Die()
    {

        Destroy(gameObject);
    }
}
