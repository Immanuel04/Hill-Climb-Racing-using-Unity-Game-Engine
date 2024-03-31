using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveCar : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _frontTireRB;
    [SerializeField] private Rigidbody2D _backTireRB;
    [SerializeField] private Rigidbody2D _carRb;
    [SerializeField] private float _speed = 150f;
    [SerializeField] private float _rotationSpeed = 300f;

    private float _moveInput;

    // Update is called once per frame
    private void Update()
    {
        _moveInput = Input.GetAxisRaw("Horizontal");
    }
    private void FixedUpdate()
    {
        _frontTireRB.AddTorque(-_moveInput * _speed * Time.fixedDeltaTime);
        _backTireRB.AddTorque(-_moveInput * _speed * Time.fixedDeltaTime);
        _carRb.AddTorque(_moveInput * _rotationSpeed * Time.fixedDeltaTime);
    }
}
