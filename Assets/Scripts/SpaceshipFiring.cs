using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class SpaceshipFiring : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D bulletPrefab;
    [SerializeField]
    private float bulletVelocity;

    private Rigidbody2D body;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var bullet = Instantiate(bulletPrefab, body.position, transform.rotation);
            bullet.linearVelocity = body.GetRelativeVector(Vector2.right) * bulletVelocity;
        } 
    }
}
