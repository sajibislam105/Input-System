using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private SwerveInputSystem _swerveInputSystem;
    private Rigidbody _rigidbody;
    [SerializeField] private float swerveSpeed = 0.5f;
    [SerializeField]private float playerMoveSpeed = 10f;
    private float _swerveAmount = 1f;

    // Start is called before the first frame update
    private void Awake()
    {
        _swerveInputSystem = GetComponent<SwerveInputSystem>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 movement = new Vector3(0, 0f, 1) * ( playerMoveSpeed * Time.deltaTime);
        _rigidbody.MovePosition(transform.position + movement);
        
        float swerve = _swerveInputSystem.MoveFactorX * swerveSpeed * Time.deltaTime;
        swerve = Mathf.Clamp(swerve, -_swerveAmount, _swerveAmount);
        transform.Translate(swerve,0,0);
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }
}