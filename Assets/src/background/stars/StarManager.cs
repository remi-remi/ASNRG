using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarManager : MonoBehaviour
{
    public GameObject starPrefab;
    public int numberOfStars = 100;
    public float minY = -6.0f;
    public float maxY = 6.0f;
    public float minX = -8.0f;
    public float maxX = 8.0f;

    void Start()
    {
        for (int i = 0; i < numberOfStars; i++)
        {
            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);
            Vector3 starPosition = new Vector3(randomX, randomY, 0);
            GameObject starInstance = Instantiate(starPrefab, starPosition, Quaternion.identity);
            starInstance.transform.SetParent(transform);
        }
    }
}
