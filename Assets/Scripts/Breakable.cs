using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Breakable : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> spawnOnBreak;
    [SerializeField]
    private float spawnVelocity;

    private Rigidbody2D body;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Break();
    }

    private void Break()
    {
        foreach (GameObject prefab in spawnOnBreak)
        {
            var rotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
            var newObject = Instantiate(prefab, body.position, rotation);

            var newBody = newObject.GetComponent<Rigidbody2D>();
            if(newBody != null)
            {
                newBody.linearVelocity = Random.insideUnitCircle * spawnVelocity;
            }
        }

        Destroy(gameObject);
    }
}
