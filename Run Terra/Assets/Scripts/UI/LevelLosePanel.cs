using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelLosePanel : BasePanel
{
    [SerializeField] private Button _retryButton;
    [SerializeField] private Text _levelFailedText;
    [SerializeField] private TextMeshProUGUI _recordText;
    [SerializeField] private TextMeshProUGUI _scoreText;

    public Button RetryButton => _retryButton;

    public void SetTextLevel(int level)
    {
        _levelFailedText.text = $"LEVEL {level} FAILED";
        _recordText.text = _scoreText.text;
    } 
}
