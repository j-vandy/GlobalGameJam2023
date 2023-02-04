using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Private Variables
    private Vector2 inputVector;
    private Vector2 movementVector;
    private Rigidbody2D rigidbody2D;
    private float xValue;

    // Public Variables
    public float movementSpeed = 1;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        inputVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        // double speed swimming backwards
        // half speed swimming forward
        xValue = inputVector.x < 0 ? inputVector.x * 2f : inputVector.x * .5f;
        movementVector = new Vector2(xValue * movementSpeed, inputVector.y * movementSpeed);
    }

    void FixedUpdate()
    {
        rigidbody2D.AddForce(movementVector);
    }
}
