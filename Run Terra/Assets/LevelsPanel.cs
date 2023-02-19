using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsPanel : BasePanel
{
    [SerializeField] private Button[] _levelButtons;

    public Button[] LevelButtons => _levelButtons;

    public void ActivateLevel(int index)
    {
        _levelButtons[index].interactable = true;
    }
}
