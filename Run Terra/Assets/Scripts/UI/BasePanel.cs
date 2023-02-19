using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePanel : MonoBehaviour
{
    private CanvasGroup _canvasGroup;
    private Animator _animator;

    private readonly int HashIsShow = Animator.StringToHash("isShow");

    private bool defaultInteractable;
    private bool defaultBlocksRaycasts;

    private void Awake()
    {
        _canvasGroup = this.GetComponent<CanvasGroup>();
        _animator = this.GetComponent<Animator>();
        defaultInteractable = _canvasGroup.interactable;
        defaultBlocksRaycasts = _canvasGroup.blocksRaycasts;
    }

    public virtual void Activate(bool isActive)
    {
        _canvasGroup.interactable = isActive ? defaultInteractable : isActive;
        _canvasGroup.blocksRaycasts = isActive ? defaultBlocksRaycasts : isActive;
        _animator.SetBool(HashIsShow, isActive);
    }
}
