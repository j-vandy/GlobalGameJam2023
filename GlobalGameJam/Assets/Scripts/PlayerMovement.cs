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
    private SpriteRenderer spriteRenderer;
    private Color white = Color.white;
    private BoxCollider2D _boxCollider2D;
    private bool isGrowing = false, isShrinking = false;

    // Public Variables
    public float movementSpeed = 1;
    [HideInInspector]
    public bool isJumping = false;
    public static PlayerMovement instance;
    public Color waterColor = new Color(73f, 102f, 126f);

    void Awake()
    {
        instance = this;
        transform.position = new Vector3(-7f, Random.Range(-2.3f, 2.3f), 0f);
    }

    // Start is called before the first frame update
    void Start()
    {
        p_rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = transform.GetChild(0).transform.gameObject.GetComponent<SpriteRenderer>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        spriteRenderer.color = waterColor;
    }

    // Update is called once per frame
    void Update()
    {
        inputVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        // double speed swimming backwards
        // half speed swimming forward
        xValue = inputVector.x < 0 ? inputVector.x * 2f : inputVector.x * .5f;
        if (transform.position.x > 7.999 && xValue > 0)
        {
            xValue = 0f;
        }
        if (transform.position.y > 2.75 && inputVector.y > 0)
        {

        }
        inputVector.y = transform.position.y > 2.75 && inputVector.y > 0 ? 0 : inputVector.y;
        inputVector.y = transform.position.y < -2.75 && inputVector.y < 0 ? 0 : inputVector.y;
        movementVector = new Vector2(xValue * movementSpeed, inputVector.y * movementSpeed);

        // check for spacebar hit
        if (Input.GetKeyDown("space") && isJumping == false && elapsedTime > 1f)
        {
            isJumping = true;
            elapsedTime = 0f;
            spriteRenderer.color = white;
            _boxCollider2D.enabled = false;
            isGrowing = true;
        }


        elapsedTime += Time.deltaTime;
    }

    void FixedUpdate()
    {
        p_rigidbody2D.AddForce(movementVector);

        // Maybe change the color so it's not blue tint or something
        // if jumping increase size then decrease size
        if (isJumping)
        {
            // have the scale increase for half a second
            if (isGrowing)
            {
                transform.localScale += new Vector3(0.001f, 0.001f, 0.001f);
                if (transform.localScale.x >= 0.07f)
                {
                    isGrowing = false;
                    isShrinking= true;
                }
            }
            // have the scale decrease for half a second
            else if (isShrinking)
            {
                transform.localScale -= new Vector3(0.001f, 0.001f, 0.001f);
                if (transform.localScale.x <= 0.05f)
                {
                    isShrinking= false;
                }
            }
            // set isJumping to false
            else
            {
                elapsedTime = 0;
                isJumping = false;
                spriteRenderer.color = waterColor;
                _boxCollider2D.enabled = true;
            }

            elapsedTime += Time.deltaTime;
        }


    }
}
