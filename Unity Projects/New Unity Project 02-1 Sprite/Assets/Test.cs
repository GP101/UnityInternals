using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    //public int _intDataValue = 0;
    public float _speed = .1f;
    SpriteRenderer _spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.color = Color.blue;
    }

    // Update is called once per frame
    void Update()
    {
        float offset = Time.deltaTime * _speed;
        Vector3 dir = new Vector3(offset, -offset, 0);
        transform.position = transform.position + dir;
    }
}
