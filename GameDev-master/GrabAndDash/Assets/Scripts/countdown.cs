using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class countdown : MonoBehaviour {

    [SerializeField] private Text uiText;
    [SerializeField] public float mainTimer;

    public float timer;
    private bool canCount = true;
    private bool doOnce = false;
    public string levelToLoad;

    void Start()
    {
        timer = mainTimer;
    }

    void Update()
    {
        if(timer >= 0.0f && canCount)
        {
            timer -= Time.deltaTime;
            uiText.text = timer.ToString("F");
        }

        else if(timer <= 0.0f && !doOnce)
        {
            canCount = false;
            doOnce = true;
            uiText.text = "0.00";
            timer = 0.0f;
            SceneManager.LoadScene(levelToLoad);
        }

    }


}
