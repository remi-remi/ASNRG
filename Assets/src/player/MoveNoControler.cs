using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveNoControler : MonoBehaviour
{
    public int playerSpeed = 5;
    public float shiftSpeedModi = 0.4f;
    private Rigidbody2D rb2D;
    private SpriteRenderer spriteRenderer;
    public bool invincibleFrame;
    public float invincibleTime = 2.0f; // Temps d'invincibilité en secondes
    [Range(0, 1)] public float invincibleAlpha = 0.5f; // Valeur de transparence entre 0 (complètement transparent) et 1 (opaque)
    public LivesDisplay livesDisplay;
    public float minX = -8.0f;
    public float maxX = 8.0f;
    public float minY = -4.0f;
    public float maxY = 4.0f;
    private bool isGameOver = false;


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb2D = GetComponent<Rigidbody2D>();
        livesDisplay = FindObjectOfType<LivesDisplay>();
    }

    void Update()
    {
        if (isGameOver) return;
        Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        // Vérifie si la touche Shift ou la gâchette gauche est enfoncée
        bool isShiftPressed = Input.GetKey(KeyCode.LeftShift);
        // Applique le modificateur de vitesse si Shift ou la gâchette gauche est enfoncée
        float speed = playerSpeed * (isShiftPressed ? shiftSpeedModi : 1);

        rb2D.velocity = movement * speed;

        // Restreint la position du joueur à l'intérieur de la zone de jeu
        Vector3 newPosition = transform.position;
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);
        transform.position = newPosition;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bullet") && !invincibleFrame)
        {
            // Code à exécuter lors de la collision avec un roid
            StartCoroutine(InvincibilityCoroutine());
            livesDisplay.looseOneLife();
        }
    }

    private IEnumerator InvincibilityCoroutine()
    {
        SetTransparency(invincibleAlpha);
        invincibleFrame = true;
        yield return new WaitForSeconds(invincibleTime);
        invincibleFrame = false;
        SetTransparency(1.0f);
    }

    private void SetTransparency(float alphaValue) // entre 0 et 1
    {
        Color color = spriteRenderer.color;
        color.a = alphaValue;
        spriteRenderer.color = color;
    }




// GAME OVER
    private void OnEnable()
    {
        GameManager.OnGameOver += OnGameOver;
    }

    private void OnGameOver()
    {
        isGameOver = true;
    }

    private void OnDisable()
    {
        GameManager.OnGameOver -= OnGameOver;
    }

}
