using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int HP;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Projectile")
        {
            Debug.Log("Trigger!! with" + other.name);
            HP--;
            if (HP <= 0)
            {
                Destroy(gameObject);
            }
        }
        else if (other.tag == "Pulverizer")
        {
            Destroy(gameObject);
        }

    }
}