using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    private PlayerInput playerInput;
    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();

        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
    }

    private void Update()
    {
        if (Keyboard.current.tKey.wasPressedThisFrame)
        {
            playerInput.SwitchCurrentActionMap("UI");
        }
        if (Keyboard.current.yKey.wasPressedThisFrame)
        {
            playerInput.SwitchCurrentActionMap("Player");
        }
    }

    private void FixedUpdate()
    {
        Vector2 inputVector = playerInputActions.Player.Movement.ReadValue<Vector2>();
        float speed = 5f;
        playerRB.AddForce(new Vector3(inputVector.x, 0, inputVector.y) * speed, ForceMode.Force);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Jump! " + context.phase);
            playerRB.AddForce(Vector3.up * 5f, ForceMode.Impulse);
        }
    }

    public void Submit(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Submit " + context.phase);
        }  
    }
}
