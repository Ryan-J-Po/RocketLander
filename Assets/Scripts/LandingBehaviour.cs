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

    private float _score = 1;


    private void Start()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {

        if (!collision.gameObject.CompareTag("LandingPad") || !collision.gameObject.CompareTag("Ground"))
        {
            return;
        }

        if (collision.gameObject.transform.rotation.z >= 45 || collision.gameObject.transform.rotation.z <= -45)
        {
            _crash = true;
            //Display GameOver
        }

        if (collision.gameObject.CompareTag("LandingPad"))
        {
            if (_greenPad)
            {
                _score *= 2;      
            }

            if (_yellowPad)
            {
                _score *= 3;
            }

            if (_redPad)
            {
                _score *= 5;
            }
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            _score *= 1;
        }

        //if (collision)
        //{
        //    gameObject.IsKinematic == true;
        //}
    }
}
