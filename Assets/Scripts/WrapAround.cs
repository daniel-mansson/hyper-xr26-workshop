using UnityEngine;

public class WrapAround : MonoBehaviour
{
    private Camera mainCamera;
    private Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
    }

    void FixedUpdate()
    {
        // GetRightPosition()   <<<   body.position
        var currentToRightSide = GetRightPosition() - body.position;
        if (currentToRightSide.x < 0f)
        {
            var newPosition = GetLeftPosition();
            newPosition.y = body.position.y;
            body.position = newPosition;
        }

        var currentToLeftSide = GetLeftPosition() - body.position;
        if (currentToLeftSide.x > 0f)
        {
            var newPosition = GetRightPosition();
            newPosition.y = body.position.y;
            body.position = newPosition;
        }
    }

    private void OnDrawGizmos()
    {
        mainCamera = Camera.main;

        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(mainCamera.transform.position, 0.5f);

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(GetTopPosition(), 0.5f);
        Gizmos.DrawSphere(GetBottomPosition(), 0.5f);

        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(GetRightPosition(), 0.5f);
        Gizmos.DrawSphere(GetLeftPosition(), 0.5f);
    }

    private Vector2 GetTopPosition()
    {
        return mainCamera.transform.position + mainCamera.transform.up * mainCamera.orthographicSize;
    }

    private Vector2 GetBottomPosition()
    {
        return mainCamera.transform.position - mainCamera.transform.up * mainCamera.orthographicSize;
    }

    private Vector2 GetRightPosition()
    {
        return mainCamera.transform.position +
            mainCamera.transform.right * mainCamera.orthographicSize * mainCamera.aspect;
    }

    private Vector2 GetLeftPosition()
    {
        return mainCamera.transform.position -
            mainCamera.transform.right * mainCamera.orthographicSize * mainCamera.aspect;
    }
}
