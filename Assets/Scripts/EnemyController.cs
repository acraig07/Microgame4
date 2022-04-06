using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D _enemyRigidBody;
    public float _speed;
    public float _maxHealth;
    [SerializeField] float _health;

    Transform _target;
    int _currentWaypoint;
    GameController _cont;
    public float _rotationSpeed;
    float _distance;
    bool _canMove = true;

    public float _damage;

    public float _dropMoney;
    public GameObject _explosion;
    private void Awake()
    {
        _enemyRigidBody = GetComponent<Rigidbody2D>();
        _cont = FindObjectOfType<GameController>();
    }

    private void OnEnable()
    {
        _health = _maxHealth;

        _currentWaypoint = 0;
        _target = _cont._waypoints[_currentWaypoint];
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = _target.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), Time.deltaTime * _rotationSpeed);

        if(_canMove)
            _enemyRigidBody.AddForce(transform.up *_speed * Time.deltaTime);

        _distance = Vector2.Distance(transform.position, _target.position);

        if (_distance <= 0.05f)
        {
            if (_currentWaypoint < _cont._waypoints.Length -1)
            {
                _canMove = false;
                Invoke ("CanMove", 1f);
                _currentWaypoint++;
                _target = _cont._waypoints[_currentWaypoint];
            }
            else 
            {
                _cont.TakeDamage(_damage);
                Destroy(gameObject);
            }
        }
    }

    void CanMove()
    {
        _canMove = true;
    }
    public void TakeDamage(float damage)
    {
        _health -= _damage;

        if (_health <= 0)
        {
            Instantiate(_explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            _cont.GiveMoney(_dropMoney);
        }
        //Debug.Log("Enemy Take Damage");
    }
}
