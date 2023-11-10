using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    CharacterController controller;
    [SerializeField] float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Get the direction of movement
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical);

        // Rotate the player to face the direction of movement
        Vector3 lookDirection = direction + gameObject.transform.position;
        gameObject.transform.LookAt(lookDirection);

        // Move the player
        transform.position += direction * speed * Time.deltaTime;
        //controller.Move(direction * speed * Time.deltaTime);
    }
}
