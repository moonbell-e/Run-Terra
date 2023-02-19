using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Rendering;

public class Barrel : MonoBehaviour
{
    private readonly int HashAnimisDropping = Animator.StringToHash("isDropping");
    [SerializeField] private bool _isMoving;
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _parent;

    public Transform Parent => _parent;


    private void Update()
    {
        if (_isMoving)
            MoveBarrel();

    }

    public void BarrelDrop()
    {
        _animator.SetTrigger(HashAnimisDropping);
        DOTween.Sequence().AppendInterval(4.542f).OnComplete(() => { _animator.enabled = false; _isMoving = true; });
    }

    private void MoveBarrel()
    {
        _parent.transform.Translate(Vector3.back * Time.deltaTime * 3f);
    }
}
