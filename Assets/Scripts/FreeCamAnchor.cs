using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FreeCamAnchor : MonoBehaviour
{
    [SerializeField] private float yMax, yMin, sensitivity, rotationMultiply;

    private Transform lookAt;
    private User user;
    private InputAction camRotation, drag;
    private bool dragging;

    private void OnEnable()
    {
        camRotation.Enable();
        drag.Enable();
    }

    private void OnDisable()
    {
        camRotation.Disable();
        drag.Disable();
    }

    private void Awake()
    {
        user = new User();

        camRotation = user.FreeCam.CamRotation;
        drag = user.FreeCam.Drag;

        drag.performed += OnDrag;
        drag.canceled += OffDrag;
    }

    private void OffDrag(InputAction.CallbackContext obj)
    {
        dragging = false;
    }

    private void OnDrag(InputAction.CallbackContext obj)
    {
        dragging = true;
    }

    private void Start()
    {
        lookAt = transform.parent;
    }

    private void Update()
    {
        transform.LookAt(lookAt, Vector3.up);

        if (dragging)
        {
            lookAt.rotation = Quaternion.Euler(0, lookAt.eulerAngles.y + camRotation.ReadValue<Vector2>().x * Time.deltaTime * sensitivity * rotationMultiply, 0);
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Clamp(transform.localPosition.y - camRotation.ReadValue<Vector2>().y * Time.deltaTime * sensitivity, yMin, yMax), transform.localPosition.z);
        }
    }
}
