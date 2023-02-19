using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using D_NaughtyAttributes.Test;

public class CarController : MonoBehaviour
{
    [SerializeField] private float _carSpeed;
    [SerializeField] private bool _isMovingFwd;
    [SerializeField] private Animator _monkeyAnim;
    [SerializeField] private Barrel[] _barrels;
    [SerializeField] private Transform _parent;

    private Animator _carAnimator;
    private readonly int HashAnimisCar = Animator.StringToHash("isCarShow");
    private readonly int HashAnimisDropping = Animator.StringToHash("isDropping");

    [SerializeField] private int i;

    private void Awake()
    {
        _carAnimator = GetComponent<Animator>();
    }

    private void Start()
    {
        InvokeRepeating("DropBarrels", 5f, 2f);
    }

    public void ShowCar()
    {
        _carAnimator.SetBool(HashAnimisCar, true);
        DOTween.Sequence().AppendInterval(2f).OnComplete(() => { _isMovingFwd = true; _carAnimator.enabled = false; });
    }

    private void Update()
    {
        if (_isMovingFwd)
        {
            MoveCar();
        }
    }

    private void MoveCar()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * _carSpeed);
    }

    private void DropBarrels()
    {
        if (i != 9)
        {
            _monkeyAnim.SetTrigger(HashAnimisDropping);
            _barrels[i].BarrelDrop();
            _barrels[i].Parent.transform.parent = _parent;
            i++;
        }
        else
        {
            _isMovingFwd = false;
            _carAnimator.SetBool(HashAnimisCar, false);
            _carAnimator.enabled = true;

        }
    }
}
