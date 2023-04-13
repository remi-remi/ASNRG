using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoidManager : MonoBehaviour
{
    public GameObject roidPrefab;
    public float spawnRate = 5.0f;
    public float minX = -6.0f;
    public float maxX = 6.0f;
    public float offsetY = 1.0f;
    public int maxRoid = 300;
    public int totalRoid = 0;
    public Sprite[] roidSprites;

    private float timeSinceLastSpawn;
    private bool isGameOver = false;

    private void Awake()
    {
        roidSprites = Resources.LoadAll<Sprite>("roid");
    }

    private void OnEnable()
    {
        GameManager.OnGameOver += HandleGameOver;
    }

    private void OnDisable()
    {
        GameManager.OnGameOver -= HandleGameOver;
    }

    private void Update()
    {
        if (isGameOver) return;

        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnRate & maxRoid > totalRoid)
        {
            SpawnRoid();
            timeSinceLastSpawn = 0f;
            totalRoid++;
        }
    }

    private void SpawnRoid()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(minX, maxX), Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y + offsetY, 0);
        GameObject newRoid = Instantiate(roidPrefab, spawnPosition, Quaternion.identity);
        newRoid.GetComponent<Roid>().SetupRandomSprite(roidSprites);
    }

    private void HandleGameOver()
    {
        isGameOver = true;
    }
}
