using UnityEngine;

public class Roid : MonoBehaviour
{
    private float randomSize;
    private float randomSpeed;
    private float randomRotation;
    private SpriteRenderer spriteRenderer;
    public float minX;
    public float maxX;
    public ScoreDisplay scoreDisplay;

    private void Awake()
    {
        randomSize = Random.Range(0.02f, 1.0f); // Taille aléatoire pour l'astéroïde
        randomSpeed = Random.Range(1.0f, 5.0f); // Vitesse aléatoire pour l'astéroïde
        randomRotation = Random.Range(-180.0f, 180.0f); // Rotation aléatoire pour l'astéroïde
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        // Appliquer une rotation aléatoire à l'astéroïde
        transform.rotation = Quaternion.Euler(0, 0, randomRotation);
        scoreDisplay = FindObjectOfType<ScoreDisplay>();
        GameManager.OnGameOver += HandleGameOver;
    }

    private void Update()
    {
        transform.position -= Vector3.up * randomSpeed * Time.deltaTime;

        if (transform.position.y < Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y - spriteRenderer.bounds.size.y)
        {

            // Repositionne l'astéroïde en haut de l'écran
            float newX = Random.Range(minX, maxX);
            float newY = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y + spriteRenderer.bounds.size.y;
            transform.position = new Vector3(newX, newY, transform.position.z);
            scoreDisplay.addScore(0.2f);
        }
    }

    private void OnDestroy()
    {
        GameManager.OnGameOver -= HandleGameOver;
    }

    private void HandleGameOver()
    {
        enabled = false;
    }

    public void SetupRandomSprite(Sprite[] roidSprites)
    {
        int randomIndex = Random.Range(0, roidSprites.Length);
        spriteRenderer.sprite = roidSprites[randomIndex];
    }


}
