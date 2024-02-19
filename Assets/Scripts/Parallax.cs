using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float _parallaxSpeed;

    private float _spriteWidth;
    private Vector3 _startPos;
    void Start()
    {
        _startPos = transform.position;
        _spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        transform.Translate(Vector3.left * _parallaxSpeed * Time.deltaTime);
        if (transform.position.x < _startPos.x - _spriteWidth)
        {
            transform.position = _startPos;
        }
    }
}
