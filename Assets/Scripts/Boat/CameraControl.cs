using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    private InputField _field;

    [SerializeField]
    private float _cameraAngleSpeed;

    [SerializeField]
    private int _offsetY, _offsetZ;

    private float _cameraAngle;

    private void Update()
    {
        _cameraAngle += _field.TouchDist.x * _cameraAngleSpeed;

        Camera.main.transform.position = transform.position + Quaternion.AngleAxis(_cameraAngle, Vector3.up) * new Vector3(0,4,6);
        Camera.main.transform.rotation = Quaternion.LookRotation(transform.position + Vector3.up * 2f - Camera.main.transform.position, Vector3.up);
    }


}
