using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    private PlayerControls controls;


    [SerializeField] private Camera spectateCamera;
    private Camera mainCamera;
    private Transform currentCamTransform;

    [SerializeField] private Look look;

    private float speed;
    [SerializeField] private float normalSpeed;
    [SerializeField] private float sprintSpeed;
    [SerializeField] private float smoothness;

    private Vector3 wayPoint;

    private void Start()
    {
        controls = new PlayerControls();
        controls.Camera.Enable();

        controls.Camera.SpeedUp.performed += ChangeSpeed;

        look.canRotateCamera = true;

        wayPoint = transform.position;
        currentCamTransform = transform;
    }

    private void OnDestroy()
    {
        controls.Camera.SpeedUp.performed -= ChangeSpeed;
    }

    private void Update()
    {
        Move();

        speed = normalSpeed;
    }

    private void Move()
    {
        Vector3 moveVec = controls.Camera.Move.ReadValue<Vector3>();
        Vector3 pos = transform.position;

        Vector3 input = currentCamTransform.forward * moveVec.z + currentCamTransform.right * moveVec.x + currentCamTransform.up * moveVec.y;

        wayPoint += input * speed * Time.deltaTime;
        transform.position = Vector3.Lerp(pos, wayPoint, smoothness * Time.deltaTime);
    }

    private void ChangeSpeed(InputAction.CallbackContext context)
        => speed = sprintSpeed;

}
