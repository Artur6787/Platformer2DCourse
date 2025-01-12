using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public event Action<Vector2> OnMoveInput;
    public event Action OnJumpInput;

    private void Update()
    {
        Vector2 moveInput = Vector2.zero;

        if (Input.GetKey(KeyCode.A))
        {
            moveInput.x = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveInput.x = 1;
        }

        if (moveInput != Vector2.zero)
        {
            OnMoveInput?.Invoke(moveInput);
        }
        else
        {
            OnMoveInput?.Invoke(Vector2.zero);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnJumpInput?.Invoke();
        }
    }
}