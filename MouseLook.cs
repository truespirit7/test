using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    // выпадающий список для настройки осей вращения
    public enum RotationAxes
    {
        
        X,
        Y,
        XandY
    }
    public RotationAxes _axes = RotationAxes.XandY;
    // чувствительность мыши
    public float _rotationSpeedHor = 5.0f;
    public float _rotationSpeedVer = 5.0f;
    // максимальный угол вращения по вертикали
    public float MaxVert = 45;
    public float MinVert = -45;
    // текущий угол вращения
    private float _rotationX = 0;
    private void Start()
    {
      Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
        {
            body.freezeRotation = true;
        }
    }
    private void Update()
    {
        if (_axes == RotationAxes.XandY) {
            _rotationX -= Input.GetAxis("Mouse Y") * _rotationSpeedVer;
            _rotationX = Mathf.Clamp(_rotationX, MinVert, MaxVert);
            float delta = Input.GetAxis("Mouse X") * _rotationSpeedVer;
            float rotationY = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
        else if (_axes == RotationAxes.X) {
            transform.Rotate(0, Input.GetAxis("Mouse X") * _rotationSpeedHor, 0);
        }
        else if (_axes == RotationAxes.Y) {

            // вычитаем значение из угла вращения
            _rotationX -= Input.GetAxis("Mouse Y") * _rotationSpeedVer;
            // ограничиваем угол вращения
            _rotationX = Mathf.Clamp(_rotationX, MinVert, MaxVert);
            float _rotationY = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0);
        }

    }
}
