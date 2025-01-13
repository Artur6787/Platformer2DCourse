using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public event Action<Vector2> OnMoveInput;
    public event Action OnJumpInput;

    public KeyCode moveLeftKey = KeyCode.A;
    public KeyCode moveRightKey = KeyCode.D;
    public KeyCode jumpKey = KeyCode.Space;

    private void Update()
    {
        Vector2 moveInput = Vector2.zero;

        if (Input.GetKey(moveLeftKey))
        {
            moveInput.x = -1;
        }
        else if (Input.GetKey(moveRightKey))
        {
            moveInput.x = 1;
        }

        OnMoveInput?.Invoke(moveInput);

        if (Input.GetKeyDown(jumpKey))
        {
            OnJumpInput?.Invoke();
        }
    }
}