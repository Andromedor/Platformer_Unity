﻿
using UnityEngine;


public class VerticalPila : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _range;
    private Vector2 _startPoint;
    private int _diraction = 1;
    // Start is called before the first frame update
    void Start()
    {
        _startPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y - _startPoint.y > _range && _diraction > 0)
        {
            _diraction *= -1;
        }
        else if( _startPoint.y - transform.position.y > _range && _diraction < 0)
        { 
            _diraction *= -1;
        }
        transform.Translate(0, _speed * _diraction * Time.deltaTime, 0);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(0.5f, _range*2, 0)); 
    }
}
