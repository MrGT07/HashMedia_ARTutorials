using UnityEngine;

[ExecuteInEditMode] //Used to test in edit mode

//Information banner always faces the camera
public class FaceCamera : MonoBehaviour
{
    private Transform _cam;
    private Vector3 _targetAngle = Vector3.zero;

    private void Start()
    {
        _cam = Camera.main.transform;
    }

    private void Update()
    {
        transform.LookAt(_cam);
        _setTarget();
    }

    private void _setTarget()
    {
        _targetAngle = transform.localEulerAngles;
        _targetAngle.x = 0;
        _targetAngle.z = 0;
        transform.localEulerAngles = _targetAngle;
    }
}
