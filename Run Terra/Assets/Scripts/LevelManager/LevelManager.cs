using D_NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class LevelManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _levels;
    [Space(10)]
    [ReadOnly][SerializeField] private Level _currentLvl;
    [ReadOnly][SerializeField] private int _currentIndex;
    [SerializeField] private int _loadSpecificLevel = -1;
    private PlayerPrefsController _playerPrefsController;

    public PlayerPrefsController PlayerPrefsController => _playerPrefsController;
    public Level CurrentLevel => _currentLvl;

    private void Awake()
    {
        _playerPrefsController = GetComponent<PlayerPrefsController>();
    }

    public int CurrentIndex => _currentIndex + 1;

    public void NextLevel()
    {
        _currentIndex++;
        _playerPrefsController.AddCurrentLevel();
        LoadLevel(_currentIndex);
    }

    public void LoadCurrentLevel()
    {
        LoadLevel(_currentIndex);
    }

    public void LoadLevel(int index)
    {
        _currentIndex = index % _levels.Count;


        if (_loadSpecificLevel != -1)
        {
            Debug.LogWarning($"<color=yellow>Caution, alwaysLoadLevelId is not -1, so it will load always the same level! levelId: {_loadSpecificLevel}</color>");
            _currentIndex = _loadSpecificLevel;
        }

        if (_levels.Count == 0)
        {
            Debug.LogError("levels is empty!");
        }

        if (_currentLvl != null)
        {
            _currentLvl.DestroySelf();
        }

        _currentLvl = Instantiate(_levels[_currentIndex], transform.position, transform.rotation).GetComponent<Level>();
        _playerPrefsController.SetCurrentLevel(index);
    }

    public void DestroyCurrentLevel()
    {
        if (_currentLvl != null)
        {
            _currentLvl.DestroySelf();
        }

    }

    public void StartLevel()
    {
        if (_currentLvl != null)
        {
            _currentLvl.StartLevel();
        }
    }
}
