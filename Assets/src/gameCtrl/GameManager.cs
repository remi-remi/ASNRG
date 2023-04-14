using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public enum GameState
    {
        Playing,
        Paused,
        GameOver
    }

    public GameState CurrentState;

    // Ajoutez une référence publique à l'AudioSource
    public AudioSource backgroundMusic;

    private AudioSource airwolf2;
    private AudioSource gameOver;

    private void Awake()
    {
        if (Instance == null)   // singleton instance
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        CurrentState = GameState.Playing;
        AudioSource[] audioSources = GetComponents<AudioSource>();
        airwolf2 = audioSources[0];
        gameOver = audioSources[1];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        if (CurrentState == GameState.Playing)
        {
            CurrentState = GameState.Paused;
            Time.timeScale = 0f; // Arrêtez le temps dans le jeu
            backgroundMusic.Pause(); // Mettez en pause la musique
        }
        else if (CurrentState == GameState.Paused)
        {
            CurrentState = GameState.Playing;
            Time.timeScale = 1f; // Reprenez le temps dans le jeu
            backgroundMusic.Play(); // Jouez la musique
        }
    }
    public static event Action OnGameOver;

    public void GameOver()
    {
        if (CurrentState == GameState.Playing)
        {
            CurrentState = GameState.GameOver;

            //Time.timeScale = 0f; // Arrêtez le temps dans le jeu
            // Ajoutez ici tout autre code à exécuter lors du Game Over

            // Déclenchez l'événement OnGameOver
            OnGameOver?.Invoke();

            // Arrêtez la musique en cas de Game Over
            backgroundMusic.Stop();
            gameOver.Play();
        }
    }
}
