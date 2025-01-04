using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeController2 : MonoBehaviour
{
    public float _velocity = 10.0f;
    public float _accel = 2.0f;
    private Vector3 _v = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        _v = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        float iv = Input.GetAxis("Vertical");
        float ih = Input.GetAxis("Horizontal");
        float dt = Time.deltaTime;
        Vector3 pos = gameObject.transform.position;
        Vector3 a = Vector3.zero;
        a = gameObject.transform.forward * _accel * iv;

        Matrix4x4 m = Matrix4x4.Rotate(Camera.main.transform.rotation);
        Matrix4x4 mRotInv = Matrix4x4.Rotate(gameObject.transform.rotation);
        a = m * mRotInv.inverse * a;
        a.y = 0;

        _v = _v + a * dt;

        gameObject.transform.position
            = pos + _v * dt + 0.5f * a * dt * dt;

        float degree = Mathf.Rad2Deg * (dt * ih);
        Quaternion qprime = Quaternion.AngleAxis(degree, Vector3.up);
        gameObject.transform.rotation =
            gameObject.transform.rotation * qprime;
    }
}
