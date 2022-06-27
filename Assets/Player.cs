using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class Player : MonoBehaviour
{
    [SerializeField]
    CharacterController charaControl;
    [SerializeField]
    Vector3 playerVel;
    [SerializeField]
    private float playerSpeed = 2.0f;
    [SerializeField]
    private float drag = 1.0f;
    [SerializeField]
    private float lerpIn = 0.5f;
    [SerializeField]
    private float gravityValue = 9.78f;
    Vector2 moveInput = new Vector2();
    bool groundedPlayer = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    /// <summary>
    /// Recieve movement input from player input.
    /// </summary>
    public void OnMove(InputValue inputValue)
    {
        moveInput = inputValue.Get<Vector2>();
    }

    private void Update()
    {
        groundedPlayer = charaControl.isGrounded;
        if (groundedPlayer && playerVel.y < 0)
        {
            playerVel.y = 0f;
        }

        

        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        //charaControl.Move(move * Time.deltaTime * playerSpeed);

        playerVel += move * Time.deltaTime * playerSpeed;
        //Debug.Log(Vector3.Lerp(playerVel, new Vector3(0, 0), 0.001f));
        playerVel = Vector3.Lerp(playerVel, new Vector3(0, 0), 0.1f *Time.deltaTime);
        if (move == Vector3.zero)
        {
            //Vector3.Dot
            playerVel = Vector3.Lerp(playerVel, new Vector3(0, 0), Mathf.Lerp(0.1f * Time.deltaTime, 0.1f,0.5f));
        }

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = Vector3.RotateTowards(gameObject.transform.forward,move,10.0f * Mathf.Deg2Rad,10.0f);
        }

        // Changes the height position of the player..
        //if (Input.GetButtonDown("Jump") && groundedPlayer)
        //{
        //    playerVel.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        //}

        playerVel.y += gravityValue * Time.deltaTime;
        //Debug.Log(playerVel * Time.deltaTime);
        charaControl.Move(playerVel * Time.deltaTime);
    }
}
