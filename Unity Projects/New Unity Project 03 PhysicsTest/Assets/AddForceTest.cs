using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceTest : MonoBehaviour
{
    public Rigidbody[] _rigidbody = new Rigidbody[4];
    public float _force = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Vector3 F = transform.forward * _force;
            float mass = _rigidbody[0].mass;
            Vector3 I = F * Time.fixedDeltaTime;
            Vector3 v = I / mass;
            Vector3 a = v / Time.fixedDeltaTime;
            _rigidbody[0].AddForce(F, ForceMode.Force);
            _rigidbody[1].AddForce(I, ForceMode.Impulse);
            _rigidbody[2].AddForce(v, ForceMode.VelocityChange);
            _rigidbody[3].AddForce(a, ForceMode.Acceleration);
        }
    }
}
