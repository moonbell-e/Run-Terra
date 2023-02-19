using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private AnimatorController _animController;
    public event Action OnDiedEvent;
    public event Action OnFinishEvent;
    public event Action OnCoinCollectEvent;

    private void Awake()
    {
        _animController = GetComponent<AnimatorController>();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.TryGetComponent(out Obstacle obstacle))
        {
            _animController.Die();
            OnDiedEvent?.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Coin coin))
        {
            coin.gameObject.SetActive(false);
            OnCoinCollectEvent?.Invoke();
        }

        if (other.TryGetComponent(out WinTrigger winTrigger))
        {
            _animController.Win();
            OnFinishEvent?.Invoke();
        }
    }
}
