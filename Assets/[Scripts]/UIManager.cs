using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour, IObserver
{

    public Text Score;
    public Text GameOver;
    public Button RestartButton;

    

    private int _score = 0;


    // Start is called before the first frame update
    void Start()
    {
        AddScore(0);
        GameManager.Instance.AddObserver(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int val)
    {
        _score += val;
        Score.text = "Score " + _score.ToString();
    }

    public void Notify()
    {
        GameOver.gameObject.SetActive(true);
        RestartButton.gameObject.SetActive(true);
    }

    public void Restart()
    {
        //GameManager.Instance.RemoveObserver(this);
        SceneManager.LoadScene("PlayScene1");
    }
}
