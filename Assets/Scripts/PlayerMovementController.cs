using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] float verticalCameraSpeed = 20f;
    [SerializeField] float horizontalCameraSpeed = 20f;
    [SerializeField] float cameraClampAngle = 90f;
    [SerializeField] float playerSpeed = 5f;
    [SerializeField] private Transform cameraFollowTarget;
    private PlayerInputManager inputManager;
    private CharacterController characterController;
    private Vector3 startingRotation;

    void Awake(){
        startingRotation = cameraFollowTarget.localRotation.eulerAngles;
        inputManager = PlayerInputManager.Instance;
        characterController = GetComponent<CharacterController>();
        Debug.Log(startingRotation);
    }
    void Update()
    {
        //rotate
        Vector2 deltaInput = inputManager.GetMouseDelta();
        
        startingRotation.x += deltaInput.x * verticalCameraSpeed * Time.deltaTime;
        startingRotation.y += deltaInput.y * horizontalCameraSpeed * Time.deltaTime;
        startingRotation.y = Mathf.Clamp(startingRotation.y, -cameraClampAngle, cameraClampAngle);
        cameraFollowTarget.rotation = Quaternion.Euler(-startingRotation.y, startingRotation.x, 0f);
        Debug.Log(startingRotation);

        //move
        Vector2 movement = inputManager.GetPlayerMovement();
        Vector3 move = new Vector3(movement.x, 0f, movement.y);
        move.y = 0f;
        characterController.Move(move * playerSpeed * Time.deltaTime);
    }
}
