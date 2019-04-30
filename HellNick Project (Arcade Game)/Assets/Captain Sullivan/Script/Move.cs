using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    [Header("PLAYER MOVEMENT")]
    [Space(5)]
    [Header("Characters MoveDirection")]
    public Vector2 moveDirection;
    public CharacterController charController;

    [Header("Character Variables")]
    [Range(0, 50)]
    public float speed; // Speed is currently 10f
    [Range(0, 20)]
    public float gravity; // Gravity is currently 10f
    [Range(0, 20)]
    public float jumpSpeed; // Jumpspeed is currently 10f


    void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Control();
    }

    void Control ()
    {
        if (charController.isGrounded)
        { 
            moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            moveDirection = transform.TransformDirection(moveDirection);

            moveDirection *= speed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }

        }
        else
        {
            if (Input.GetButton("Down"))
            {
                moveDirection.y -= jumpSpeed;
            }

            if (Input.GetButton("Right"))
            {
                moveDirection.x = speed;
            }

            if (Input.GetButton("Left"))
            {
                moveDirection.x = -speed;

            }
        }

        moveDirection.y -= gravity * Time.deltaTime;
        charController.Move(moveDirection * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {

    }

}
