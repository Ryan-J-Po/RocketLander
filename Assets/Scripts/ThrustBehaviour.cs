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
        Debug.Log(Input.mousePosition);

        if (Input.GetButton("Jump"))
        {
            
            //Mouse posiition on screen
            Vector3 mousePosInScreen = Camera.main.WorldToScreenPoint(transform.position);
            //Direction to mouse and normalize direction
            Vector3 directionToMouse = Input.mousePosition - mousePosInScreen;
            directionToMouse.Normalize();

            //Create a rotation from the player's forward to the look direction
            Quaternion rotation = Quaternion.LookRotation(directionToMouse);
            //Set the rotation to be the new rotation found
            directionToMouse.z = 0;
            transform.rotation *= Quaternion.FromToRotation(transform.up, directionToMouse);
            //Rocket thrusted towards the direction of mouse on screen when jumping.
            _rigidBody.AddForce(directionToMouse * _thrustPower, ForceMode.Impulse);
        }

        

    }
}
