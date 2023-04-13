using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [Tooltip("The variable that will be used to determine and display the player's score at the Game Over Screen.")]
    private float _score = 100;

    [SerializeField]
    private Rigidbody _rigidBody;

    [SerializeField]
    private GameOverBehaviour gameOverBehaviour;


    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("A collision has occurred, Non-Specific");

        if (collision.gameObject.transform.rotation.z >= 45 || collision.gameObject.transform.rotation.z <= -45)
        {
            _rigidBody.isKinematic = true;
            _crash = true;
            if (_crash)
            {
                gameOverBehaviour.Setup(0);
            }
        }

        if (collision.gameObject.CompareTag("LandingPad"))
        {
            Debug.Log("Landing Pad Collision Detected.");
            _rigidBody.isKinematic = true;
            _score *= 2;
            gameOverBehaviour.Setup(_score);

            //if (_greenPad)
            //{
            //    Debug.Log("Green Landing Pad Found.");
            //    _score *= 2;
            //    gameOverBehaviour.Setup(_score);
            //}

            //if (_yellowPad)
            //{
            //    Debug.Log("Yellow Landing Pad Found.");
            //    _score *= 3;
            //    gameOverBehaviour.Setup(_score);
            //}

            //if (_redPad)
            //{
            //    Debug.Log("Red Landing Pad Found.");
            //    _score *= 5;
            //    gameOverBehaviour.Setup(_score);
            //}
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Ground Found.");
            _rigidBody.isKinematic = true;
            _score *= 1;
            gameOverBehaviour.Setup(_score);
        }

        
    }
}
