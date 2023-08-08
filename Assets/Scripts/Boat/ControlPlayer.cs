using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlayer : MonoBehaviour
{
    public Rigidbody rig;
    public Transform mainCamera;
    public float jumpForce = 3.5f;
    public float walkingSpeed = 2f;
    public float runningSpeed = 6f;
    public float currentSpeed;
    private float animationInterpolation = 1f;
    public FixedJoystick joy;
    private float _vertical, _horizontal;
    public float multiplayer;

    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }
    void Boost()
    {
        currentSpeed = Mathf.Lerp(currentSpeed, runningSpeed, Time.deltaTime * 3);
    }
    void NotBoost()
    {
        currentSpeed = Mathf.Lerp(currentSpeed, walkingSpeed, Time.deltaTime * 3);
    }
    private void Update()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, mainCamera.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

        NotBoost();
        
    }

    void FixedUpdate()
    {
        _horizontal = Mathf.Lerp(_horizontal, joy.Horizontal, Time.deltaTime * multiplayer);
        _vertical = Mathf.Lerp(_vertical, joy.Vertical, Time.deltaTime * multiplayer);
        Vector3 camF = mainCamera.forward;
        Vector3 camR = mainCamera.right;
        camF.y = 0;
        camR.y = 0;

        Vector3 movingVector;
        movingVector = Vector3.ClampMagnitude(camF.normalized *  _vertical * -1 * currentSpeed + camR.normalized * _horizontal * -1 * currentSpeed, currentSpeed);

        rig.velocity = new Vector3(movingVector.x, rig.velocity.y, movingVector.z);
 
        rig.angularVelocity = Vector3.zero;
    }
}

