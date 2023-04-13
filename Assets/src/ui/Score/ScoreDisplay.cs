using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public Text textFieldScore;
    public string scoreText;
    public float score;
    // Start is called before the first frame update
    void Start()
    {
        textFieldScore.text = scoreText;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void addScore(float toAdd)
    {
        textFieldScore.text = scoreText + Mathf.FloorToInt(score += toAdd);
    }

    public float GetCurrentScore()
    {
        return score;
    }
}
