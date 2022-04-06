using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
public class BaseTower : MonoBehaviour
{
    public float _shootSpeed;
    public float _rotationSpeed;
    public Transform _target;
    public float _attackrange;

    public Transform _child;

    protected float _cools;
    public GameObject _bullet;
    public float _cost;

    public GameObject _flash;
    protected AudioSource _src;

    public GameObject [] _bulletSpawnPosistions;

    private void Awake()
    {
        _src = GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        GetComponent<CircleCollider2D>().radius = _attackrange;
        _cools = _shootSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collison)
    {
        if (collison.gameObject.CompareTag("Enemy") && _target == null)
            _target = collison.transform;
    }

     private void OnTriggerStay2D(Collider2D collison)
    {
        if (collison.gameObject.CompareTag("Enemy") && _target == null)
            _target = collison.transform;
    }

     private void OnTriggerExit2D(Collider2D collison)
    {
        if (collison.gameObject.CompareTag("Enemy") && _target == collison.transform)
            _target = null;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_target != null)
        {
            Vector3 dir = _target.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg -90;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), Time.deltaTime *_rotationSpeed);

            if (_cools > 0)
                _cools -= Time.deltaTime;
            else 
                Shoot();

            //Debug.Log(_target.gameObject);
        }
    }

    public virtual void Shoot()
    {
        
    }

    void LateUpdate()
    {
        _child.transform.rotation = Quaternion.identity;
    }
}