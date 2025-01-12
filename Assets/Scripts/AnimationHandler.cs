using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private const string IsJumping = "isJumping";
    private const string IsRunning = "isRunning";

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void UpdateAnimation(bool isJumping, bool isRunning)
    {
        _animator.SetBool(IsJumping, isJumping);
        _animator.SetBool(IsRunning, isRunning);
    }
}