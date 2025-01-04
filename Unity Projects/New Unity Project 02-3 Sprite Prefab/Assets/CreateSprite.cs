using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSprite : MonoBehaviour
{
    public GameObject _spriteObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            GameObject.Instantiate(_spriteObject, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }
}
