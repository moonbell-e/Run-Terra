using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapToStartPanel : BasePanel
{
    [SerializeField] private Button _tapToStartButton;

    public Button TapToStartButton => _tapToStartButton;
}
