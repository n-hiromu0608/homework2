using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] float _speed = 1f;
    [SerializeField] float _extinc = 0.3f;
    [SerializeField] float _gvScale = 0.3f;
    [SerializeField] float _scale = 10.0f;
    [SerializeField] float _jumppw = 1f;
    [SerializeField] GameObject _bulletPrehub;

    float _jumpY = 1f;
    float _jtime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float v = Input.GetAxis("Horizontal");
        this.transform.position += new Vector3(v, 0, 0) * Time.deltaTime * _speed;
        if(_jumpY < 0.001f)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                _jumpY = _jumppw;
                _jtime = 0.0f;
            }
        }
        else
        {
            _jtime += Time.deltaTime;
            _jumpY *= 1.0f - Time.deltaTime * _extinc;
            float y = this.transform.position.y;
            y = (_jumpY * _jtime - 9.8f * _jtime * _jtime * _gvScale) * _scale + -4.0f;

            if (y < -4.0f)
            {
                y = -4;
                _jtime = 0;
                _jumpY = 0;
            }

            this.transform.position = new Vector3(this.transform.position.x, y, this.transform.position.z);
        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            Instantiate(_bulletPrehub, transform.position, Quaternion.identity);
        }
    }
}
