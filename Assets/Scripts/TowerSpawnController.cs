using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawnController : MonoBehaviour
{
    GameController _cont;

    SpriteRenderer _rend;

    private void Awake()
    {
        _cont = FindObjectOfType<GameController>();
        _rend = GetComponent<SpriteRenderer>();
    }
    private void OnMouseDown()
    {
        if (_cont._money >= _cont._currentTowerCost)
        {
            //Debug.Log("Spawn Tower");
            _cont.GiveMoney(-_cont._currentTowerCost);
            Instantiate(_cont._tower, transform.position, transform.rotation);
            gameObject.SetActive(false);
        }
    }

    private void OnMouseOver()
    {
        if (_cont._money >= _cont._currentTowerCost)
        {
            _rend.color = Color.green;
        }
        else
            _rend.color = Color.red;
    }

    private void OnMouseExit()
    {
        _rend.color = Color.white;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
