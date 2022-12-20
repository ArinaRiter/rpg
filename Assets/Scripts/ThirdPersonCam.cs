using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform orientation;
    [SerializeField] private Transform player;
    [SerializeField] private Transform playerObj;
    [SerializeField] private Rigidbody rb;

    public float rotationSpeed;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {
        Vector3 viewDir=player.position - new Vector3(transform.position.x,transform.position.y,transform.position.z);
        orientation.forward = viewDir.normalized;

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;
<<<<<<< Updated upstream

        if (inputDir != Vector3.zero)
        {
            playerObj.forward=Vector3.Slerp(playerObj.forward,inputDir.normalized,Time.deltaTime*rotationSpeed);
        }
=======
>>>>>>> Stashed changes

    }
}
