using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float _speed;
    Rigidbody2D _bulletRigidBody;
    public float _damage;

    private void Awake()
    {
        _bulletRigidBody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _bulletRigidBody.AddForce(transform.up * _speed);
        Invoke("Disable", 4f);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Disable()
    {
        Destroy(gameObject);
        //gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collison)
    {
        if(collison.gameObject.CompareTag("Enemy"))
        {
            collison.GetComponent<EnemyController>().TakeDamage(_damage);
        }
    }
    /*private void OnDisable()
    {
        CancelInvoke();
    }*/
}
