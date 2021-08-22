using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInputActions playerInputActions;
    private MeshRenderer playerRenderer;
    private float speed = 10f;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();

        playerRenderer = GetComponent<MeshRenderer>();
        if (SaveManager.Instance != null)
        {
            playerRenderer.material.color = SaveManager.Instance.playerColor;
        }
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
    }

    private void Update()
    {
        Vector2 inputVector = playerInputActions.Player.Movement.ReadValue<Vector2>();
        Vector3 movementDirection = new Vector3(inputVector.x, 0, inputVector.y);
        transform.Translate(movementDirection * speed * Time.deltaTime);
    }
}
