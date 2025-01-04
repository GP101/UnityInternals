using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGuiTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform tr in transform)
        {
            Debug.Log(string.Format("name={0}", tr.name));
        }
        //Time.timeScale = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnGUI()
    {
        GUI.Button(new Rect(0, 0, 100, 32), "Hello");
    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal*contact.separation, Color.magenta, 2);
        }
    }
}
