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
    public float JumpForce = 1f;
    public float jumpSpeed; //a

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
            if (Input.GetButtonDown("Jump"))//a
            {
                ySpeed = jumpSpeed;
            }
        }
        else//a
        {
            characterController.stepOffset = 0;
        }

        Vector3 velocity = move * Speed;//a
        velocity.y = ySpeed;
        characterController.Move(velocity * Time.deltaTime);
        if (move.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg;
            currentAngle = Mathf.SmoothDampAngle(currentAngle, targetAngle, ref currentAngleVelocity, rotationSmoothTime);
            transform.rotation = Quaternion.Euler(0, currentAngle, 0);

        }

    }

}
