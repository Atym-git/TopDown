using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    private float _shootCd = 2;

    private Object _bulletPrefab;

    [SerializeField] private Transform _bulletRoot;

    private void Awake()
    {
        LoadResources();
    }
    private void Start()
    {
        _bulletRoot = transform.GetChild(0).transform;
        StartCoroutine(Delay());
    }

    private IEnumerator Delay()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(_shootCd);
        }
    }

    private void Shoot() => Instantiate(_bulletPrefab, _bulletRoot);

    private void OnDestroy() => StopCoroutine(Delay());

    private void LoadResources()
    {
        _bulletPrefab = Resources.Load("Prefabs/EnemyBullet");
    }
}
