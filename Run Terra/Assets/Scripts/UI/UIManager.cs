using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public enum Panels
    {
        TapToStart,
        Game,
        Win,
        Lose,
        Levels
    }

    [SerializeField] private TapToStartPanel _tapToStartPanel;
    [SerializeField] private GamePanel _gamePanel;
    [SerializeField] private LevelWinPanel _levelWinPanel;
    [SerializeField] private LevelLosePanel _levelLosePanel;
    [SerializeField] private LevelsPanel _levelsPanel;

    private LevelManager _levelManager;

    public LevelManager LevelManager { set { _levelManager = value; } }

    public TapToStartPanel TapToStartPanel => _tapToStartPanel;
    public GamePanel GamePanel => _gamePanel;
    public LevelWinPanel LevelWinPanel => _levelWinPanel;
    public LevelLosePanel LevelLosePanel => _levelLosePanel;

    public LevelsPanel LevelsPanel => _levelsPanel;


    public void ShowPanel(Panels showPanel)
    {
        _tapToStartPanel.Activate(false);
        _gamePanel.Activate(false);
        _levelWinPanel.Activate(false);
        _levelLosePanel.Activate(false);
        _levelsPanel.Activate(false);

        switch (showPanel)
        {
            case Panels.TapToStart:
                {
                    _tapToStartPanel.Activate(true);
                    break;
                }
            case Panels.Game:
                {
                    _gamePanel.Activate(true);
                    _gamePanel.SetTextLevel(_levelManager.CurrentIndex);
                    break;
                }
            case Panels.Win:
                {
                    _levelWinPanel.Activate(true);
                    _levelWinPanel.SetTextLevel(_levelManager.CurrentIndex);
                    break;
                }
            case Panels.Lose:
                {
                    _levelLosePanel.Activate(true);
                    _levelLosePanel.SetTextLevel(_levelManager.CurrentIndex);
                    break;
                }
            case Panels.Levels:
                {
                    _levelsPanel.Activate(true);
                    break;
                }
        }

    }
}
