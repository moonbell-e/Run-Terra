using D_NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpForce = 2f;
    [SerializeField] private float _gravity;
    [ReadOnly][SerializeField] private bool _isRunning = false;

    private AnimatorController _animController;

    public bool IsRunning
    {
        get
        {
            return _isRunning;
        }
        set
        {
            _isRunning = value;
        }
    }

    private CharacterController _characterController;
    private CapsuleCollider _capsuleCollider;

    private Vector3 _movePos;


    private float _laneNumber = 1;
    private int _laneDistance = 2;
    private SynchPosition _synchPosition;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _synchPosition = FindObjectOfType<SynchPosition>();
        _synchPosition.ResetPos();
        _animController = GetComponent<AnimatorController>();
        _synchPosition.SetTarget(transform);
        _capsuleCollider = GetComponent<CapsuleCollider>();
    }

    private void Update()
    {
        SwipeReceiveMove();

        if (_isRunning)
            MoveHorizontal();
    }

    private void FixedUpdate()
    {
        if (_isRunning)
            MoveForward();
    }

    private void MoveForward()
    {
        _animController.StartRun();
        _movePos.z = _moveSpeed;
        _movePos.y += _gravity * Time.fixedDeltaTime * _jumpForce;
        _characterController.Move(_movePos * Time.fixedDeltaTime);
    }

    private void MoveHorizontal()
    {
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (_laneNumber == 0)
            targetPosition += Vector3.left * _laneDistance;
        else if (_laneNumber == 2)
            targetPosition += Vector3.right * _laneDistance;

        if (transform.position == targetPosition)
            return;
        Vector3 diff = targetPosition - transform.position;
        Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
        if (moveDir.sqrMagnitude < diff.sqrMagnitude)
            _characterController.Move(moveDir);
        else
            _characterController.Move(diff);
    }

    private void SwipeReceiveMove()
    {

        if (SwipeController.swipeRight)
        {
            if (_laneNumber < 2)
                _laneNumber++;
        }

        if (SwipeController.swipeLeft)
        {
            if (_laneNumber > 0)
                _laneNumber--;
        }
        if (SwipeController.swipeUp)
        {
            if (_characterController.isGrounded)
                StartCoroutine(Jump());
        }

        if (SwipeController.swipeDown)
        {
            StartCoroutine(Slide());
        }
    }


    private IEnumerator Slide()
    {
        _characterController.center = new Vector3(0.03f, 0.4f, 0.13f);
        _characterController.height = 0.51f;
        _animController.Roll();

        yield return new WaitForSeconds(0.5f);

        _characterController.center = new Vector3(0.03f, 0.95f, 0.13f);
        _characterController.height = 2.21f;
    }

    private IEnumerator Jump()
    {
        _movePos.y = _jumpForce * 5f;
        _animController.Jump();
        yield return new WaitForSeconds(0.5f);
    }
}
