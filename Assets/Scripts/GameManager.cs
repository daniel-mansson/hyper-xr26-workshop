using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Asteroid asteroidPrefab;
    [SerializeField]
    private float spawnVelocity;

    private int levelNumber;
    public int asteroidCount = 0;

    private void Awake()
    {
        asteroidCount = 0;
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
        GUI.matrix = Matrix4x4.Scale(Vector3.one * 5f);

        GUILayout.Label("Level Number: " + levelNumber);
        GUILayout.Label("Asteroids: " + asteroidCount);
    }

    private void GoToNextLevel()
    {
        var camera = Camera.main;

        int asteroidsToSpawn = levelNumber + 3;
        for (int i = 0; i < asteroidsToSpawn; i++)
        {
            Vector2 position =  Random.insideUnitCircle.normalized * camera.orthographicSize;

            var asteroid = Instantiate(asteroidPrefab, position, Quaternion.identity);
            asteroid.Initialize(this);

            var asteroidBody = asteroid.GetComponent<Rigidbody2D>();
            asteroidBody.linearVelocity = Random.insideUnitCircle.normalized * spawnVelocity;
            asteroidBody.angularVelocity = Random.Range(-860f, 860f);
        }

        levelNumber++;
    }

    private bool IsAllAsteroidsDestroyed()
    {
        return asteroidCount == 0;
    }

    public void OnAsteroidCreated()
    {
        asteroidCount += 1;
    }

    public void OnAsteroidDestroyed()
    {
        asteroidCount -= 1;
    }
}
