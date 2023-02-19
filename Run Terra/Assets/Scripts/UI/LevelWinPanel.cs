using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelWinPanel : BasePanel
{
    [SerializeField] private Button _nextLvlButton;
    [SerializeField] private Text _levelCompletedText;

    public Button NextLevelButton => _nextLvlButton;

    public void SetTextLevel(int level)
    {
        _levelCompletedText.text = $"LEVEL {level} COMPLETED";
    }
}
