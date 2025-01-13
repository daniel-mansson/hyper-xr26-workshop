using UnityEngine;

public class DestroyInTime : MonoBehaviour
{
    [SerializeField]
    private float delayInSeconds;

    void Start()
    {
        Destroy(gameObject, delayInSeconds);
    }
}
