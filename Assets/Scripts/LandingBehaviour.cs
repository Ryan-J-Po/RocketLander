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

    public Rigidbody _rigidBody;


    private void Start()
    {
        //_rigidBody = GetComponent<Rigidbody>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("A collision has occurred.");

        _rigidBody = GetComponent<Rigidbody>();
        _rigidBody.isKinematic = false;

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
                Debug.Log("Green Landing Pad Found."); 
                _score *= 2;      
            }

            if (_yellowPad)
            {
                Debug.Log("Yellow Landing Pad Found.");
                _score *= 3;
            }

            if (_redPad)
            {
                Debug.Log("Red Landing Pad Found.");
                _score *= 5;
            }
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Ground Found.");
            _score *= 1;
        }

    }
}
