using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrustBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _thrustPower;

    [Tooltip("The current active camera. Used to get mouse position for rotation.")]
    [SerializeField]
    private Camera _camera;
    private Rigidbody _rigidBody;


    // Start is called before the first frame update
    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButton("Jump"))
        {
            //Mouse posiition on screen
            Vector3 mousePosInScreen = Camera.main.WorldToScreenPoint(transform.position);
            //Direction to mouse and normalize direction
            Vector3 directionToMouse = Input.mousePosition - mousePosInScreen;
            directionToMouse.Normalize();
            _rigidBody.AddForce(directionToMouse * _thrustPower, ForceMode.Impulse);
        }

    }
}
