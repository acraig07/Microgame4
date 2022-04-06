using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarController : BaseTower
{
 public override void Shoot()
    {
        Instantiate(_bullet, _bulletSpawnPosistions[0].transform.position, transform.rotation);
        _src.Play();
        Instantiate(_flash, _bulletSpawnPosistions[0].transform.position, transform.rotation);
        _cools = _shootSpeed;
        base.Shoot();
    }
}
