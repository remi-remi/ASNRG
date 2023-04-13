using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour
{
    public Sprite lifeIconSprite; // Le Sprite de l'icône de vie
    public int lives; // Le nombre de vies
    public float iconSpacing; // L'espacement entre les icônes de vie
    public float lifeIconSize;
    public float lifeIconTextSpacing;
    public int yRelativePosition;
    public GameManager gameManager;
    private List<Image> lifeIcons = new List<Image>();
    private AudioSource damageSound;
    private AudioSource endSound;

    private void Start()
    {
        UpdateLivesDisplay();
        AudioSource[] audioSources = GetComponents<AudioSource>();
        damageSound = audioSources[0];
        endSound = audioSources[1];
    }

    public void UpdateLivesDisplay()
    {
        // Supprime les icônes de vie existantes
        foreach (Image icon in lifeIcons)
        {
            Destroy(icon.gameObject);
        }
        lifeIcons.Clear();

        // Crée de nouvelles icônes de vie
        for (int i = 0; i < lives; i++)
        {
            GameObject newIconObject = new GameObject("LifeIcon_" + i);
            newIconObject.transform.SetParent(transform);

            Image newIcon = newIconObject.AddComponent<Image>();
            newIcon.sprite = lifeIconSprite;

            RectTransform rectTransform = newIconObject.GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(lifeIconSize, lifeIconSize);
            rectTransform.anchoredPosition = new Vector2(i * iconSpacing + lifeIconTextSpacing, yRelativePosition);
            lifeIcons.Add(newIcon);
        }
    }

    public void looseOneLife()
    {
        if (lives == 0)
        {
            endSound.Play();
            gameManager.GameOver();
        }
        else
        {
            damageSound.Play();
        }
        lives--;
        UpdateLivesDisplay();
        Debug.Log("lives: " + lives);
    }
}
