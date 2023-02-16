using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterMovement : MonoBehaviour
{
    private CharacterController characterController;

    private float ySpeed; //a
    private float originalStepOffset;

    public float Speed = 5f;
    public float sprintSpeed = 8f;
    public float JumpForce = 1f;
    public float jumpSpeed; //a

    public KeyCode sprintKey = KeyCode.LeftShift;
    public KeyCode jumpKey = KeyCode.Space;

    [SerializeField] float rotationSmoothTime;
    [SerializeField] private Camera _camera;
    float currentAngle;
    float currentAngleVelocity;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        originalStepOffset = characterController.stepOffset;
    }

    void FixedUpdate()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 moveDirection = _camera.transform.TransformDirection(move);
        move = moveDirection;

        ySpeed += Physics.gravity.y * Time.deltaTime;//a
        if (characterController.isGrounded)//a
        {
            characterController.stepOffset = originalStepOffset;
            ySpeed = -0.5f;//a
            if (Input.GetKey(jumpKey))
            {
                ySpeed = jumpSpeed;
            }
            //if (Input.GetButtonDown("Jump"))//a
            //{
            //    ySpeed = jumpSpeed;
            //}
        }
        else//a
        {
            characterController.stepOffset = 0;
        }

        float magnitude = Mathf.Clamp01(moveDirection.magnitude) * Speed;//b
        //Vector3 velocity = move * Speed;//a
        Vector3 Velocity = moveDirection * magnitude;//b
        Velocity.y = ySpeed;
        characterController.Move(Velocity * Time.deltaTime);
        if (move.magnitude >= 0.1f)
        {
            if (Input.GetKey(sprintKey))
            {

                Speed = sprintSpeed;
            }
            else
            {
                Speed = 5f;
            }
            float targetAngle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg;
            currentAngle = Mathf.SmoothDampAngle(currentAngle, targetAngle, ref currentAngleVelocity, rotationSmoothTime);
            transform.rotation = Quaternion.Euler(0, currentAngle, 0);



        }


    }

}
