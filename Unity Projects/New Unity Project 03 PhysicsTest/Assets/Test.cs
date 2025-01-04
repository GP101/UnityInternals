using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private float _animTime = 0.0f;
    public int intDataValue = 0;
    // Start is called before the first frame update
    void Start()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();
        mr.materials[0].color = Color.red;
        //StartCoroutine("UpdatePosition");
        GameObject cam = GameObject.Find("Main Camera");
        Debug.Assert(cam != null);
        Debug.Log(string.Format("Game Object = {0}",cam.name));
    }

    // Update is called once per frame
    void Update()
    {
        if (_animTime < 3.0f)
        {
            _animTime += Time.deltaTime;
            transform.position += transform.forward * Time.deltaTime;
        }
    }

    IEnumerator UpdatePosition()
    {
        while (_animTime < 3.0f)
        {
            _animTime += Time.deltaTime;
            //Vector3 pos = transform.position;
            //pos.x += Time.deltaTime;// Time.deltaTime;
            //transform.position = pos;
            transform.position += transform.forward * Time.deltaTime;
            yield return null;
        }
    }
}
