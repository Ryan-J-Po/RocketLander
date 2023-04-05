using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingBehaviour : MonoBehaviour
{
    [SerializeField]
    private bool _greenPad;
    [SerializeField]
    private bool _yellowPad;
    [SerializeField]
    private bool _redPad;
    [SerializeField]
    private bool _ground;

    private bool _crash = false;


    private void Start()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.transform.rotation.z >= 45 || collision.gameObject.transform.rotation.z <= -45)
        {
            _crash = true;
        }

        if (!collision.gameObject.CompareTag("LandingPad") || !collision.gameObject.CompareTag("Ground"))
        {
            return;
        }

        if (collision.gameObject.CompareTag("LandingPad"))
        {
            if (_greenPad)
            {
                   
            }

            if (_yellowPad)
            {

            }

            if (_redPad)
            {

            }
        }
    }
}
