using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;

    private Transform[] _points;
    private int _currentPoint;
    private SpriteRenderer _sprite;
    private int facingDirection = 1;

    private void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }

        _sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        MoveAlongPath();
        Reflect();
    }

    private void MoveAlongPath()
    {
        Transform target = _points[_currentPoint];
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if (transform.position == target.position)
        {
            _currentPoint++;

            if (_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }
        }
    }    
    private void Reflect()
    {
        Vector3 directionToTarget = (_points[_currentPoint].position - transform.position).normalized;
        float angle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));

        if (directionToTarget.x > 0)
        {
            facingDirection = 1;
        }
        else if (directionToTarget.x < 0)
        {
            facingDirection = -1;
        }
    }
}