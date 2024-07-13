using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField] Transform _player;
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] float _interval = 1.0f;
    [SerializeField] float attackDistance = 5;
    private float nextFireTime = 0f;
    float _timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, _player.position);

        if (distanceToPlayer <= attackDistance && Time.time >= nextFireTime)
        {
            _timer += Time.deltaTime;
            if (_timer > _interval)
            {
                _timer -= _interval;

                Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
            }
        }
    }
}
