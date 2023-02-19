using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : BasePanel
{
    [SerializeField] private Button _homeButton;
    [SerializeField] private Text _levelText;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _coinsText;
    [SerializeField] private Transform _playerPos;

    public Button HomeButton => _homeButton;


    public void SetTextLevel(int level)
    {
        _levelText.text = $"LEVEL {level}";
    }

    public void UpdateCoinsText(int value)
    {
        _coinsText.text = value.ToString();
    }

    private void Update()
    {
        _scoreText.text = ((int)(_playerPos.position.z / 2) + 2).ToString();
    }
}
