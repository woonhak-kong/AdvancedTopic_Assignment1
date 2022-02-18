using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public List<GameObject> EnemyPrefabs;
    public GameObject Projectile;

    public Transform SpawingPositionLeft;
    public Transform SpawingPositionRight;

    private bool _isPlaying;


    // Singleton
    private static GameManager _instance = null;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                return null;
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(this);
        }
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        _isPlaying = true;
        StartCoroutine(StartSpaw());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator StartSpaw()
    {
        int typeOfEnemy = 0;
        float positionCoefficient = 0.0f;

        float previousCoefficient = 0;

        while (_isPlaying)
        {
            // select type of enemy
            typeOfEnemy = Random.Range(0, 3);
            GameObject newEnemy = Instantiate(EnemyPrefabs[typeOfEnemy]);

            // select position for enemy
            do
            {
                positionCoefficient = Random.Range(0.0f, 1.0f);
            }
            while (Mathf.Abs(previousCoefficient - positionCoefficient) < 0.2f);
            Vector3 newPosition = Vector3.Lerp(SpawingPositionLeft.position, SpawingPositionRight.position, positionCoefficient);
            newEnemy.transform.position = newPosition;


            previousCoefficient = positionCoefficient;
            yield return new WaitForSeconds(1.0f);
        }
        yield return null;
    }


    public void FireProjectile(Vector3 pos)
    {
        GameObject projectile = Instantiate(Projectile);
        Vector3 projectilePosition = new Vector3(pos.x, -5.5f, 0);
        projectile.transform.position = projectilePosition;

    }


}
