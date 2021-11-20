using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAbility : MonoBehaviour, Iability
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _shootDelay;

    private float _time = float.MinValue;

    public void Execute()
    {
        if (Time.time < _shootDelay + _time) return;

        _time = Time.time;

        GameObject newBullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
    }
}
