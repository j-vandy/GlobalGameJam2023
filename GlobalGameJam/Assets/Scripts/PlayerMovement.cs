using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Private Variables
    private Vector2 inputVector;
    private Vector2 movementVector;
    private Rigidbody2D p_rigidbody2D;
    private float xValue;
    private float elapsedTime = 0f;

    // Public Variables
    public float movementSpeed = 1;
    public bool isJumping = false;
    public static PlayerMovement instance;

    void Awake()
    {
        instance = this;
        transform.position = new Vector3(-7f, Random.Range(-2.3f, 2.3f), 0f);
    }

    // Start is called before the first frame update
    void Start()
    {
        p_rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        inputVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        // double speed swimming backwards
        // half speed swimming forward
        xValue = inputVector.x < 0 ? inputVector.x * 2f : inputVector.x * .5f;
        movementVector = new Vector2(xValue * movementSpeed, inputVector.y * movementSpeed);

        // check for spacebar hit
        if (Input.GetKeyDown("space") && isJumping == false && elapsedTime > 1f)
        {
            isJumping = true;
            elapsedTime = 0f;
        }

        // Maybe change the color so it's not blue tint or something
        // if jumping increase size then decrease size
        if (isJumping)
        {
            // have the scale increase for half a second
            if (elapsedTime < 1f)
            {
                transform.localScale += new Vector3(0.001f, 0.001f, 0.001f);
            }
            // have the scale decrease for half a second
            else if (elapsedTime < 2f)
            {
                transform.localScale -= new Vector3(0.001f, 0.001f, 0.001f);
            }
            // set isJumping to false
            else 
            {
                elapsedTime = 0;
                isJumping = false;
            }

            elapsedTime += Time.deltaTime;
        }

        elapsedTime += Time.deltaTime;
    }

    void FixedUpdate()
    {
        p_rigidbody2D.AddForce(movementVector);
    }
}
