using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private void Start()
    {
        GameManager.AsteroidCount += 1;
    }

    private void OnDestroy()
    {
        GameManager.AsteroidCount -= 1;
    }
}
