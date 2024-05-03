using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 5;

    [SerializeField] private float _gravity;
    [SerializeField] private float _fallVelocity;
    [SerializeField] private float _jumpForce;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public Transform cam;


    private void Awake()
    {
        _gravity = 9.81f; //gravedad normal -9.81 aprox
        _jumpForce = 15f;
    }


    void Update()
    {
        SetGravity();
        Jump();
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f) 
        {

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            

            controller.Move(moveDir.normalized * speed * Time.deltaTime);

            
        }

        
    }
    public void SetGravity() 
    {
        if (controller.isGrounded) 
        {
            _fallVelocity = -_gravity * Time.deltaTime;
        }
        else 
        {
            _fallVelocity -= _gravity * Time.deltaTime;
        }
        
    }

    private void Jump() 
    {
        if (controller.isGrounded && Input.GetKey(KeyCode.Space)) 
        {
            _fallVelocity = _jumpForce;
        }

    }
}
