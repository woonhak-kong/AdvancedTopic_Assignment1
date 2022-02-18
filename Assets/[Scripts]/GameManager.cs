using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public interface IObserver
{
    void Notify();
}

public class GameManager : MonoBehaviour
{

    public List<GameObject> EnemyPrefabs;
    public GameObject Projectile;

    public Transform SpawingPositionLeft;
    public Transform SpawingPositionRight;

    public bool IsPlaying;

    private List<IObserver> _observers = new List<IObserver>();


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
        else
        {
            _instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        IsPlaying = true;
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

        while (IsPlaying)
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

    public void AddObserver(IObserver ob)
    {
        _observers.Add(ob);
    }

    public void RemoveObserver(IObserver ob)
    {
        _observers.Remove(ob);
    }

    public void RemoveAllObserver()
    {
        _observers.Clear();
    }

    private void NotifyObservers()
    {
        foreach (IObserver ob in _observers)
        {
            ob.Notify();
        }
    }
    public void GameOver()
    {
        IsPlaying = false;
        NotifyObservers();
        RemoveAllObserver();
    }

}
