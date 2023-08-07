using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlayer : MonoBehaviour
{
    public float speedMove;
    public float boostPower;

    private float currentSpeed;

    private float gravityForce;
    private Vector3 moveVector;

    private CharacterController ch_controller;

    public Joystick joy;

    public Transform cameraTransform;

    public float cameraSensitivity;
    public float moveInputDeadZone;

    private int rightfingerId;
    private float halfScreenWidth;


    private Vector2 lookInput;
    private float cameraPitch;

    public Transform player;



    void Start()
    {
        ch_controller = GetComponent<CharacterController>();

        rightfingerId = -1;

        halfScreenWidth = Screen.width / 2;

    }

    private void FixedUpdate()
    {
        MovePlayer();
        GamingGravity();
        MoveCamera();

        if (rightfingerId != -1)
        {
            LookAroud();
        }
    }

    void Update()
    {
        GetTouchinput();
    }

    private void GetTouchinput()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch t = Input.GetTouch(i);

            switch (t.phase)
            {
                case TouchPhase.Began:
                    if (t.position.x > halfScreenWidth && rightfingerId == -1)
                    {
                        rightfingerId = t.fingerId;
                    }
                    break;
                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    if (t.fingerId == rightfingerId)
                    {
                        rightfingerId = -1;
                    }
                    break;
                case TouchPhase.Moved:
                    if (t.fingerId == rightfingerId)
                    {
                        lookInput = t.deltaPosition * cameraSensitivity * Time.deltaTime;
                    }
                    break;
                case TouchPhase.Stationary:
                    if (t.fingerId == rightfingerId)
                    {
                        lookInput = Vector2.zero;
                    }
                    break;
            }
        }
    }

    private void LookAroud()
    {
        cameraPitch = Mathf.Clamp(cameraPitch - lookInput.y, -90f, 90f);
        cameraTransform.localRotation = Quaternion.Euler(cameraPitch, 0, 0);

        transform.Rotate(transform.up, lookInput.x);
    }

    private void MovePlayer()
    {
        moveVector = Vector3.zero;
        moveVector.x = joy.Horizontal * -1;
        moveVector.z = joy.Vertical * -1;

        moveVector.y = gravityForce;

        moveVector = transform.right * moveVector.x + cameraTransform.forward * moveVector.z + transform.up * moveVector.y;

        ch_controller.Move(moveVector * currentSpeed * Time.deltaTime);
    }

    private void GamingGravity()
    {
        if (!ch_controller.isGrounded)
        {
            gravityForce -= 10f * Time.deltaTime;
        }
        else
            gravityForce = -1f;
    }

    public void OnClickBoost()
    {
        currentSpeed = boostPower;
    }

    public void OffClickBoost()
    {
        currentSpeed = speedMove;
    }

    private void MoveCamera()
    {
        cameraTransform.position = player.transform.position + new Vector3(0, 1, -3);
    }
}
