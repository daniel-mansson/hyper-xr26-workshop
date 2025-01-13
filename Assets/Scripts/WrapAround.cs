using UnityEngine;

public class WrapAround : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        
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
