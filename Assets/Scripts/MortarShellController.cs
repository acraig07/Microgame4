using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarShellController : MonoBehaviour
{
    public float _speed;
    Rigidbody2D _bulletRigidBody;
    public float _damage;
    public float _radius;
    public LayerMask _enemyMask;

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
            Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, _radius, _enemyMask);
            foreach (Collider2D col in hit)
                col.GetComponent<EnemyController>().TakeDamage(_damage);
        }
    }
    /*private void OnDisable()
    {
        CancelInvoke();
    }*/

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
