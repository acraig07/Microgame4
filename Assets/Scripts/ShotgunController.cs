using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunController : BaseTower
{
    // Start is called before the first frame update
    public override void Shoot()
    {
        for (int j = 0; j < _bulletSpawnPosistions.Length; j++)
            for (int i = 0; i < 5; i++)
                Instantiate(_bullet, _bulletSpawnPosistions[j].transform.position, transform.rotation * Quaternion.Euler(0, 0, (i*5) - 15f));
        _src.Play();
        Instantiate(_flash, _bulletSpawnPosistions[0].transform.position, transform.rotation);
        _cools = _shootSpeed;
        base.Shoot();
    }
}
