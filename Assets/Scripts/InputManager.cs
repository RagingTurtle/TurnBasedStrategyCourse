using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    public static InputManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("InputManager error: " + transform + "-" + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public Vector2 GetMouseScreenPosition()
    {
        return Input.mousePosition;
    }

    public bool IsMouseButtonDown()
    {
        return Input.GetMouseButtonDown(0);
    }

    public Vector2 GetCameraMoveVector()
    {
        Vector3 inputMoveDir = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            inputMoveDir.y = +1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputMoveDir.y = -1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputMoveDir.x = -1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputMoveDir.x = +1f;
        }

        return inputMoveDir;
    }

    public float GetCameraRotateAmount()
    {
        float rotationAmount = 0f;
        if (Input.GetKey(KeyCode.Q))
        {
            rotationAmount = +1f;
        }
        if (Input.GetKey(KeyCode.E))
        {
            rotationAmount = -1f;
        }

        return rotationAmount;
    }

    public float GetCameraZoomAmount()
    {
        float zoomAmount = 0f;
        if (Input.mouseScrollDelta.y > 0f)
        {
            zoomAmount = -1f;
        }
        if (Input.mouseScrollDelta.y < 0f)
        {
            zoomAmount = +1f;
        }
        return zoomAmount;
    }
}
