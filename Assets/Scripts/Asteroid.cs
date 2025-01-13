using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private GameManager gameManager;

    public void Initialize(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }

    public void Initialize(Asteroid parent)
    {
        this.gameManager = parent.gameManager;
    }

    private void Start()
    {
        gameManager.OnAsteroidCreated();
    }

    private void OnDestroy()
    {
        gameManager.OnAsteroidDestroyed();
    }
}
