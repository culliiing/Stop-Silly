using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    CharacterController controller;
    Animator animator;
    [SerializeField] float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get the direction of movement, if any
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical);

        animator.SetBool("IsMoving", IsMoving(direction));

        // Move the player
        Move(direction);
    }

    void Move(Vector3 direction)
    {
        FaceDirection(direction);
        transform.position += direction * speed * Time.deltaTime;
        //controller.Move(direction * speed * Time.deltaTime);
    }

    void FaceDirection(Vector3 moveDirection)
    {
        Vector3 lookDirection = moveDirection + gameObject.transform.position;
        gameObject.transform.LookAt(lookDirection);
    }

    bool IsMoving(Vector3 direction)
    {
        // If direction is not zero, then we are moving
        if (direction != Vector3.zero)
            return true;

        return false;
    }
}
