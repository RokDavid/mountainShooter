using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nonEnemy : MonoBehaviour
{


    [SerializeField] float health = 50f;
    public ParticleSystem fire;
    public GameObject GameObject;
    

    public float TakeDamage(float amount)
    {
        health -= amount;


        if (health < 20)
        {
            Explode();

            if (health < 0)
            {
                Die();
            }
            

        }
        return amount;
    }


    
    void Explode()
    {
        float xA = gameObject.transform.position.x;
        float yA = gameObject.transform.position.x;
        float zA = gameObject.transform.position.x;

        fire.transform.position = new Vector3(xA, yA, zA);
        Instantiate(fire);
        
    
    }


    void Die()
    {
        Destroy(gameObject);
    }
}
