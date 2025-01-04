using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
#pragma warning disable 8601, 8602, 8618
    class Test : MonoBehavior
    {
        double _timer = 0;
        double _speed = 50;
        SpriteRenderer _spriteRenderer;

        public void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _spriteRenderer.color = Color.Blue;
            StartCoroutine(UpdateColor());
        }

        public void Update()
        {
            float offset = (float)(Time.deltaTime * _speed);
            Vector3 dir = new Vector3(offset, offset, 0);
            transform.position = transform.position + dir;
        }

        IEnumerator UpdateColor()
        {
            while (_timer < 1.0)
            {
                _timer += Time.deltaTime;
                yield return null;
            }
            _spriteRenderer.color = Color.Red;
        }
    }
}
