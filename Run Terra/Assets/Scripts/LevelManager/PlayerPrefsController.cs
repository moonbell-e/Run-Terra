using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    private readonly string PrefsLevel = "Level";
    private int _currentIndex;


    public int CurrentIndex => _currentIndex;


    private void Awake()
    {
        LoadData();
    }

    private void OnDisable()
    {
        SaveLevelData();
    }

    public void SetCurrentLevel(int value)
    {
        _currentIndex = value;
        SaveLevelData();
    }

    public void AddCurrentLevel()
    {
        _currentIndex++;
        SaveLevelData();
    }

    private void LoadData()
    {
        _currentIndex = PlayerPrefs.GetInt(PrefsLevel, 0);
    }

    private void SaveLevelData()
    {
        PlayerPrefs.SetInt(PrefsLevel, _currentIndex);
    }
}
