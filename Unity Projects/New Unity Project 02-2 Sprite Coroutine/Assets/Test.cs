using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private float _timer = 0.0f;
    public float _speed = .1f;
    SpriteRenderer _spriteRenderer;
    //Transform _transform;
    //GameObject _gameObject;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.color = Color.blue;
        StartCoroutine(UpdateColor());
    }

    // Update is called once per frame
    void Update()
    {
        float offset = Time.deltaTime * _speed;
        Vector3 dir = new Vector3(offset, -offset, 0);
        transform.position = transform.position + dir;
    }

    IEnumerator UpdateColor()
    {
        while (_timer < 1.0f)
        {
            _timer += Time.deltaTime;
            yield return null;
        }
        _spriteRenderer.color = Color.red;
    }
}
