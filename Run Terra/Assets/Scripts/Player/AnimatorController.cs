using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorController : MonoBehaviour
{
    private Animator _animator;

    private readonly int HashAnimisRunning = Animator.StringToHash("isRunning");
    private readonly int HashAnimisJumping= Animator.StringToHash("isJumping");
    private readonly int HashAnimisRolling= Animator.StringToHash("isRolling");    
    private readonly int HashAnimisDying= Animator.StringToHash("isDying");
    private readonly int HashAnimisWinning = Animator.StringToHash("isWinning");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void StartRun()
    {
        _animator.SetTrigger(HashAnimisRunning);
    }

    public void Jump()
    {
        _animator.SetTrigger(HashAnimisJumping);
    }

    public void Die()
    {
        _animator.SetTrigger(HashAnimisDying);
    }

    public void Win()
    {
        _animator.SetTrigger(HashAnimisWinning);
    }

    public void Roll()
    {
        _animator.SetTrigger(HashAnimisRolling);
    }
}
