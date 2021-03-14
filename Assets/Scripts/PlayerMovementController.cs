using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] float verticalCameraSpeed = 20f;
    [SerializeField] float horizontalCameraSpeed = 20f;
    [SerializeField] float cameraClampAngle = 90f;
    private float playerSpeed = 2.0f;
    [SerializeField] private float runSpeed = 5.0f;
    [SerializeField] private float walkSpeed = 2.0f;
    [SerializeField]private float jumpHeight = 1.0f;
    [SerializeField]private float gravityValue = -9.81f;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    [SerializeField] private Transform cameraFollowTarget;
    private PlayerInputManager inputManager;
    private CharacterController characterController;
    private Vector3 startingRotation;

    [SerializeField] private Animator animator;

    void Awake(){
        startingRotation = cameraFollowTarget.localRotation.eulerAngles;
        inputManager = PlayerInputManager.Instance;
        characterController = GetComponent<CharacterController>();

    }
    void Update()
    {
        //rotate
        Vector2 deltaInput = inputManager.GetMouseDelta();
        
        startingRotation.x += deltaInput.x * verticalCameraSpeed * Time.deltaTime;
        startingRotation.y += deltaInput.y * horizontalCameraSpeed * Time.deltaTime;
        startingRotation.y = Mathf.Clamp(startingRotation.y, -cameraClampAngle, cameraClampAngle);
        cameraFollowTarget.rotation = Quaternion.Euler(-startingRotation.y, startingRotation.x, 0f);

        //move
        groundedPlayer = characterController.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        if(inputManager.isSprinting() && groundedPlayer){
            playerSpeed = runSpeed;
        } else if(!inputManager.isSprinting() && groundedPlayer){
            playerSpeed = walkSpeed;
        }

        animator.SetFloat("playerSpeed", playerSpeed);

        Vector2 movement = inputManager.GetPlayerMovement();
        Vector3 move = new Vector3(movement.x, 0f, movement.y);
        move = cameraFollowTarget.forward * move.z + cameraFollowTarget.right * move.x;
        move.y = 0f;
        characterController.Move(move * playerSpeed * Time.deltaTime);

        if (inputManager.PlayerJumped() && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        characterController.Move(playerVelocity * Time.deltaTime);
    }
}
