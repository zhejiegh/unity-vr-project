using UnityEngine;
using System.Collections.Generic; // Nécessaire pour utiliser les Listes

public class BallManager : MonoBehaviour
{
    [Header("Configuration")]
    public GameObject ballPrefab;
    public Transform spawnPoint;

    [Header("Réglages")]
    public int maxBalls = 3;
    public float spawnDistance = 0.5f;

    private List<GameObject> activeBalls = new List<GameObject>();
    private GameObject lastSpawnedBall;

    void Start()
    {
        SpawnNewBall();
    }

    void Update()
    {
        // On vérifie si la dernière balle créée a été déplacée (prise en main)
        if (lastSpawnedBall == null || Vector3.Distance(lastSpawnedBall.transform.position, spawnPoint.position) > spawnDistance)
        {
            SpawnNewBall();
        }
    }

    void SpawnNewBall()
    {
        // Créer la nouvelle balle
        GameObject newBall = Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity);
        lastSpawnedBall = newBall;
        activeBalls.Add(newBall);

        // Si on dépasse le nombre max, on détruit la plus ancienne
        if (activeBalls.Count > maxBalls)
        {
            GameObject ballToDestroy = activeBalls[0];
            activeBalls.RemoveAt(0);
            Destroy(ballToDestroy);
        }
    }
}