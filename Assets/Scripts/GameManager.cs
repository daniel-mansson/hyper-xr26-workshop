using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int AsteroidCount = 0;

    [SerializeField]
    private Rigidbody2D asteroidPrefab;
    [SerializeField]
    private float spawnVelocity;

    private int levelNumber;

    private void Awake()
    {
        AsteroidCount = 0;
    }

    void Update()
    {
        if (IsAllAsteroidsDestroyed())
        {
            GoToNextLevel();
        }

    }

    private void OnGUI()
    {
        GUILayout.Label("Level Number: " + levelNumber);
        GUILayout.Label("Asteroids: " + AsteroidCount);
    }

    private void GoToNextLevel()
    {
        var camera = Camera.main;

        int asteroidsToSpawn = levelNumber + 3;
        for (int i = 0; i < asteroidsToSpawn; i++)
        {
            Vector2 position =  Random.insideUnitCircle.normalized * camera.orthographicSize;

            var asteroidBody = Instantiate(asteroidPrefab, position, Quaternion.identity);
            asteroidBody.linearVelocity = Random.insideUnitCircle.normalized * spawnVelocity;
            asteroidBody.angularVelocity = Random.Range(-860f, 860f);
        }

        levelNumber++;
    }

    private bool IsAllAsteroidsDestroyed()
    {
        return AsteroidCount == 0;
    }
}
