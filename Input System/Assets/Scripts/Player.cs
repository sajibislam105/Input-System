using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private SwerveInputSystem _swerveInputSystem;
    private Rigidbody _rigidbody;
    [SerializeField] private float swerveSpeed = 0.5f;
    [SerializeField]private float playerMoveSpeed = 5f;
    [SerializeField] private float MaxSwerveAmount = 4f;
    private Vector3 previousPosition;
    private Vector3 lastValidPosition;

    // Start is called before the first frame update
    private void Awake()
    {
        _swerveInputSystem = GetComponent<SwerveInputSystem>();
        _rigidbody = GetComponent<Rigidbody>();
        previousPosition = _rigidbody.position;
    }

    private void Update()
    {
        float playerForwardMovement = playerMoveSpeed * Time.deltaTime;
        float _swerveAmount = _swerveInputSystem.MoveFactorX * swerveSpeed * Time.deltaTime;

        Vector3 movement = new Vector3(_swerveAmount, 0, playerForwardMovement);
        _rigidbody.MovePosition(_rigidbody.position + movement);
        _rigidbody.rotation = Quaternion.Euler(Vector3.zero);
        
        Vector3 currentPosition = _rigidbody.position;
        float distanceMoved = Mathf.Abs(currentPosition.x - previousPosition.x); //absolute so negative value is checked
        if (distanceMoved > MaxSwerveAmount )
        {
            _rigidbody.position = lastValidPosition;
        }
        else
        {
            lastValidPosition = _rigidbody.position;
        }
        
    }
}