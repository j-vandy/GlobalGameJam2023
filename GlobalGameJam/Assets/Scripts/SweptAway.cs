using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SweptAway : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ScenesManager.instance.LoadScene(ScenesManager.Scene.SweptAway);
        }
    }
}
