using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverDisplay : MonoBehaviour
{
    public GameObject gameOverBg;
    public GameObject gameOverTxt;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.OnGameOver += ShowGameOverDisplay;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDestroy()
    {
        GameManager.OnGameOver -= ShowGameOverDisplay;
    }

    void ShowGameOverDisplay()
    {
        gameOverBg.SetActive(true);
        gameOverTxt.SetActive(true);
    }
}


