using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//        Debug.Log("reset");

public class Star : MonoBehaviour
{
    public float speed;
    public float minY; // Limite inférieure de l'écran
    public float maxY; // Limite supérieure de l'écran
    public float minX ; // Limite gauche de l'écran
    public float maxX; // Limite droite de l'écran

    void Start()
    {
        speed = Random.Range(0.5f, 2);
        GameManager.OnGameOver += HandleGameOver;
    }

    void Reset()
    {
        speed = Random.Range(0.5f, 2);
    }

    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
        if (transform.position.y <= minY)
        {
            float randomX = Random.Range(minX, maxX);
            transform.position = new Vector3(randomX, maxY, transform.position.z);
            Reset();
        }
    }

    private void HandleGameOver()
    {
        enabled = false;
    }

    void OnDestroy()
    {
        GameManager.OnGameOver -= HandleGameOver;
    }
}

