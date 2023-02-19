using D_NaughtyAttributes;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    [SerializeField] private LevelManager _levelManager;
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private AudioController _audioController;
    [SerializeField] private ParticleSystem _complexConfetti;
    [SerializeField] private float _winDelay;



    [ReadOnly][SerializeField] private int _coinsValue;

    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        _uiManager.LevelManager = _levelManager;
    }


    private void Start()
    {
        _uiManager.ShowPanel(UIManager.Panels.TapToStart);
        AddListenersToUI();
    }


    private void StartGame(int index)
    {
        _uiManager.ShowPanel(UIManager.Panels.Game);
        _uiManager.GamePanel.SetTextLevel(index + 1);
        _levelManager.LoadLevel(index);
        _levelManager.StartLevel();
    }

    public void WinGame()
    {
        _audioController.Play("Win");
        _complexConfetti.Play();
        DOTween.Sequence().AppendInterval(_winDelay).OnComplete(() => { _uiManager.ShowPanel(UIManager.Panels.Win); });
    }

    public void LoseGame()
    {
        _audioController.Play("Loss");
        _uiManager.ShowPanel(UIManager.Panels.Lose);
    }

    private void ShowLevelsPanel()
    {
        _uiManager.ShowPanel(UIManager.Panels.Levels);
        _levelManager.DestroyCurrentLevel();
    }

    private void RestartGame()
    {
        _uiManager.ShowPanel(UIManager.Panels.Game);
        _levelManager.LoadCurrentLevel();
        StartGame(_levelManager.PlayerPrefsController.CurrentIndex);
    }

    private void AddListenersToUI()
    {
        _uiManager.TapToStartPanel.TapToStartButton.onClick.AddListener(() =>
        {
            _uiManager.ShowPanel(UIManager.Panels.Levels);
        });

        _uiManager.LevelsPanel.LevelButtons[0].onClick.AddListener(() =>
        {
            StartGame(0);
        }); 
        _uiManager.LevelsPanel.LevelButtons[1].onClick.AddListener(() =>
        {
            StartGame(1);
        }); 
        _uiManager.LevelsPanel.LevelButtons[2].onClick.AddListener(() =>
        {
            StartGame(2);
        });

        _uiManager.LevelWinPanel.NextLevelButton.onClick.AddListener(() =>
        {
            _levelManager.NextLevel();
            _uiManager.GamePanel.SetTextLevel(_levelManager.CurrentIndex);
            _uiManager.LevelsPanel.ActivateLevel(_levelManager.PlayerPrefsController.CurrentIndex);
            StartGame(_levelManager.PlayerPrefsController.CurrentIndex);
        });

        _uiManager.GamePanel.HomeButton.onClick.AddListener(() =>
        {
            ShowLevelsPanel();
        });

        _uiManager.LevelLosePanel.RetryButton.onClick.AddListener(() =>
        {
            RestartGame();
        });
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void SwitchSound()
    {
        AudioListener.pause = !AudioListener.pause;
    }

    public void UpdateCoins()
    {
        _coinsValue++;
        _uiManager.GamePanel.UpdateCoinsText(_coinsValue);
        _audioController.Play("Coin");
    }
}
