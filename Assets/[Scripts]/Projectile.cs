using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject ProjectileExplosion;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject explosion = Instantiate(ProjectileExplosion);
        explosion.transform.position = transform.position;
        Destroy(this.gameObject);
    }

}
