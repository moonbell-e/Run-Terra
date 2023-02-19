using UnityEngine;



public class SynchPosition : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [Space(10)]
    [SerializeField] private bool _x;
    [SerializeField] private bool _y;
    [SerializeField] private bool _z;
    [SerializeField] private float _offsetX;
    [SerializeField] private float _offsetY;
    [SerializeField] private float _offsetZ;
    private Vector3 _temp;
    private Vector3 _startPos;

    public float OffsetZ
    {
        get
        {
            return _offsetZ;
        }
        set
        {
            _offsetZ = value;
        }
    }    
    
    public bool isZ
    {
        get
        {
            return _z;
        }
        set
        {
            _z = value;
        }
    }

    private void Awake()
    {
        _startPos = transform.position; 
    }


    private void Update()
    {
        if (_target == null)
            return;

        UpdatePos();
    }

    public void SetTarget(Transform target)
    {
        _target = target;
        InitState();
    }
    
    public void ResetOffsets()
    {
        _offsetX = 0f;
        _offsetY = 0f;
    }

    private void InitState()
    {
        _offsetX = transform.position.x - _target.position.x;
        _offsetY = transform.position.y - _target.position.y;
        _offsetZ = transform.position.z - _target.position.z;
    }

    public void ResetPos()
    {
        transform.position = _startPos;
        ResetOffsets();
    }

    private void UpdatePos()
    {
        _temp = transform.position;

        if (_x)
            _temp.x = _target.position.x + _offsetX;
        if (_y)
            _temp.y = _target.position.y + _offsetY;
        if (_z)
            _temp.z = _target.position.z + _offsetZ;

        transform.position = _temp;
    }
}

