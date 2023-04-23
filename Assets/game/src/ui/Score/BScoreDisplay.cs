using UnityEngine;
using UnityEngine.UI;

public class BScoreDisplay : MonoBehaviour
{
    public Text bestScoreText;
    public ScoreDisplay scoreManager; // Ajoutez une référence publique à votre script de gestion des scores

    private float bestScore;

    private void OnEnable()
    {
        GameManager.OnGameOver += GameOver;
    }

    private void OnDisable()
    {
        GameManager.OnGameOver -= GameOver;
    }

    // Start is called before the first frame update
    void Start()
    {
        LoadBestScore();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void GameOver()
    {
        // Comparez le score actuel au meilleur score et mettez à jour si nécessaire
        float currentScore = scoreManager.GetCurrentScore();
        if (currentScore > bestScore)
        {
            DisplayBestScore();
            SaveBestScore(Mathf.RoundToInt(currentScore));
        }
    }

    public void SaveBestScore(float score)
    {
        bestScore = score;
        PlayerPrefs.SetInt("BestScore", (int)bestScore);
        DisplayBestScore();
    }

    public void LoadBestScore()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        //bestScore = 3; // DEBUG
        DisplayBestScore();
    }

    private void DisplayBestScore()
    {
        if (bestScoreText != null)
        {
            int roundedBestScore = Mathf.RoundToInt(bestScore);
            bestScoreText.text = "Best Score: " + roundedBestScore.ToString();
        }
    }
}
