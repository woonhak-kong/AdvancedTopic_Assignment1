using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IObserver
{
    public int HP;


    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.AddObserver(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Projectile")
        {
            HP--;
            if (HP <= 0)
            {
                FindObjectOfType<UIManager>().AddScore(10);
                GameManager.Instance.RemoveObserver(this);
                Destroy(gameObject);
            }
        }
        else if (other.tag == "Pulverizer")
        {
            //Game Over
            //GameManager.Instance.RemoveObserver(this);
            GameManager.Instance.GameOver();
            //Destroy(gameObject);
        }

    }

    public void Notify()
    {
        //GameManager.Instance.RemoveObserver(this);
        Destroy(this.gameObject);
    }
}
