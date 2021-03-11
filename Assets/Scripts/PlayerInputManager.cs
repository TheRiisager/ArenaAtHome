using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    private static PlayerInputManager _instance;

    public static PlayerInputManager Instance{
        get{
            return _instance;
        }
    }
    private PlayerControls playerControls;

    private void Awake(){
        if (_instance != null && _instance != this){
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
        playerControls = new PlayerControls();
        Cursor.visible = false;
    }

    private void OnEnable(){
        playerControls.Enable();
    }

    private void OnDisable(){
        playerControls.Disable();
    }

    public Vector2 GetPlayerMovement()
    {
        return playerControls.Default.Move.ReadValue<Vector2>();
    }

    public Vector2 GetMouseDelta()
    {
        return playerControls.Default.Look.ReadValue<Vector2>();
    }

    public bool PlayerJumped()
    {
        Debug.Log("JUMP!");
        return playerControls.Default.Jump.triggered;
        
    }
}
