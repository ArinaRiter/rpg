using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Character : MonoBehaviour
{
    private CharacterController characterController;

    public float Speed = 5f;
    public float JumpForce = 1f;
    Vector3 movement=new Vector3(0,0,0);
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;

        characterController.Move(move * Time.deltaTime * Speed);
        if(movement.magnitude>=0.1f)
        {
            float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, targetAngle, 0);
            characterController.Move(movement * Speed * Time.deltaTime);
        }
        
    }
    
}
