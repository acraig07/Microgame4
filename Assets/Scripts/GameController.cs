using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public BaseTower _tower;
    public BaseTower [] _towers;
    //public float _cost;

    public Transform[] _waypoints;

    public float _maxHealth;
    [SerializeField] float _health;
    
    public Image _healthImage;
    public float _lerpSpeed;

    [HideInInspector] public float _currentTowerCost;
    public float _money;
    public Text _moneyText;

    public float _timeBetweenSpawnLow;
    public float _timeBetweenSpawnHigh;
    float _cools;
    public GameObject _spwanPosistion;
    public GameObject[] _enemies;
    public bool _gameOver;
    public GameObject _gameOverUI;
    private void Awake()
    {
        _health = _maxHealth;
        _healthImage.fillAmount = _health/_maxHealth;
        //_healthImage.fillAmount = Mathf.Lerp(_healthImage.fillAmount, _health/_maxHealth, _lerpSpeed * Time.deltaTime);
        UpdateTower(0);
        _gameOver = false;
    }

    public void UpdateTower(int i)
    {
        _tower = _towers[i];
        _currentTowerCost = _towers[i]._cost;
    }

    void SpawnEnemy()
    {
        Instantiate(_enemies[Random.Range(0, _enemies.Length)], _spwanPosistion.transform.position, Quaternion.Euler(0,0,-90));
        _cools = Random.Range(_timeBetweenSpawnLow, _timeBetweenSpawnHigh);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _healthImage.fillAmount = _health/_maxHealth;
        _moneyText.text = "MONEY: " + _money.ToString();

        if (!_gameOver)
        {
            if (_cools > 0)
                _cools -= Time.deltaTime;
            else
                SpawnEnemy();
        }
        if (_gameOver && Input.anyKeyDown)
        {
            _gameOver = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Time.timeScale = 1f;
        }
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        if (_health <= 0 )
        {
            _gameOver = true;
            _gameOverUI.SetActive(true);
            Time.timeScale = 0f;
        }
        //_healthImage.fillAmount = _health/_maxHealth;
        //_healthImage.fillAmount = Mathf.Lerp(_healthImage.fillAmount, _health/_maxHealth, _lerpSpeed * Time.deltaTime);
    }

    public void GiveMoney(float amt)
    {
        _money += amt;
    }
}
