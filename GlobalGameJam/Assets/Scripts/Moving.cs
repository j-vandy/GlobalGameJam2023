using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    // Private Variables
    private Rigidbody2D _rigidbody2D;
    private float speed;

    // Public Variables
    public bool isInWater;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
         speed = isInWater ? ScenesManager.instance.waterSpeed + Random.Range(-0.5f, 0.5f) : ScenesManager.instance.landSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector3(-1 * speed, _rigidbody2D.velocity.y, 0f);
    }
}
