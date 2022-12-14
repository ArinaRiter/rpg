using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Character : MonoBehaviour
{
    private CharacterController characterController;

    public float Speed = 5f;
    public float JumpForce = 1f;

    [SerializeField] float rotationSmoothTime;
    float currentAngle;
    float currentAngleVelocity;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        characterController.Move(move * Speed);
        if(move.magnitude>=0.1f)
        {
            float targetAngle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg;
            currentAngle = Mathf.SmoothDampAngle(currentAngle, targetAngle, ref currentAngleVelocity, rotationSmoothTime);
            transform.rotation = Quaternion.Euler(0, currentAngle, 0);

        }
        
    }
    
}
