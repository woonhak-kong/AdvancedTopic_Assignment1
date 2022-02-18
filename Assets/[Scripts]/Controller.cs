using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.IsPlaying)
        {
#if UNITY_EDITOR

            if (Input.GetMouseButtonDown(0))
            {
                GameManager.Instance.FireProjectile(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            }

#endif

#if UNITY_ANDROID
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    GameManager.Instance.FireProjectile(Camera.main.ScreenToWorldPoint(touch.position));
                }
            }
#endif
        }

    }
}
