using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerController _playerController;
    private void Awake()
    {
        _playerController.OnDiedEvent += LoseLevel;
        _playerController.OnFinishEvent += WinLevel;
        _playerController.OnCoinCollectEvent += GameManager.Instance.UpdateCoins;
    }

    public void StartLevel()
    {
        _playerMovement.IsRunning = true;
    }

    private void WinLevel()
    {
        GameManager.Instance.WinGame();
        _playerMovement.IsRunning = false;
    }

    private void LoseLevel()
    {
        _playerMovement.IsRunning = false;
        GameManager.Instance.LoseGame();
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        _playerController.OnDiedEvent -= LoseLevel;
        _playerController.OnCoinCollectEvent -= GameManager.Instance.UpdateCoins;
        _playerController.OnFinishEvent -= WinLevel;
    }
}
