using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.EventSystems;


public class PlayerController : MonoBehaviour
{

    private Rigidbody _rb;
    private Animator anim;
    private Vector3 moveInput;

    [Header("Editor References")]
    [SerializeField] GameObject playerModel;
    [SerializeField] GameObject videoBoss;

    #region Camera
    private Camera _cam;
    private CameraMovement _cm;
    private Vector3 camFwd;
    #endregion

    #region Movement
    [Header("Movement Stats")]
    [Range(1.0f, 1.0f)]
    public float walk_speed;
    [Range(1.0f, 1.0f)]
    public float backwards_walk_speed;
    [Range(1.0f, 10.0f)]
    public float strafe_speed;

    [Range(0.1f, 1.5f)]
    public float rotation_speed;

    [Range(2.0f, 8.0f)]
    public float jump_force;

    [Header("GroundCheck Configuration")]
    [SerializeField] GameObject groundCheck;
    [SerializeField] float groundCheckRange;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] bool isGrounded;
    private RaycastHit groundHit;
    #endregion
    
    #region Animations
    
    private bool walking = false;
    private bool strafeLeft = false;
    private bool strafeRight = false;
    private bool backwards = false;
    private bool jump = false;
    #endregion

    [Header("Triger Pared Para pasar de fase")]
    [SerializeField] GameObject[] pared;
    [SerializeField] GameObject[] triggerPhase;
    [SerializeField] GameObject spawner;

    [SerializeField] int fallLimit;
    private void Awake()
    {
        
        _cm = GetComponent<CameraMovement>();
        _cam = _cm.GetCamera();
        _rb = GetComponent<Rigidbody>();
        anim = playerModel.GetComponent<Animator>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.z = Input.GetAxis("Vertical");
        jump = Input.GetButtonDown("Jump");
        isGrounded = Physics.Raycast(groundCheck.transform.position, Vector3.down, groundCheckRange, groundLayer);
        anim.SetBool("IsJumping", !isGrounded);
        if (moveInput.x != 0 || moveInput.z != 0) { anim.SetBool("IsWalking", true); }
        else { anim.SetBool("IsWalking", false); }

        //FallRespawn();

        PlayerStateMachine();

        //animations
        /*tpc.GetFullBodyAnimator().SetBool("walking", walking);
        tpc.GetFullBodyAnimator().SetBool("sttrafeLeft", strafeLeft);
        tpc.GetFullBodyAnimator().SetBool("strafeRight", strafeRight);
        tpc.GetFullBodyAnimator().SetBool("backwards", backwards);
        tpc.GetFullBodyAnimator().SetBool("jump", jump);*/


    }

    private void FixedUpdate()
    {
        Jump();
        

        //calculate camera relative directions to move:
        camFwd = Vector3.Scale(_cam.transform.forward, new Vector3(1, 1, 1)).normalized;
        Vector3 camFlatFwd = Vector3.Scale(_cam.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 flatRight = new Vector3(_cam.transform.right.x, 0, _cam.transform.right.z);

        Vector3 m_CharForward = Vector3.Scale(camFlatFwd, new Vector3(1, 0, 1)).normalized;
        Vector3 m_CharRight = Vector3 .Scale(flatRight, new Vector3(1, 0, 1)).normalized;

        //draws a ray to show the direction the player is aiming at
        Debug.DrawLine(transform.position, transform.position + camFwd * 5f, Color.red);

        //move the player (movement will be slightly different depending on the camera type)
        float w_speed;
        Vector3 move = Vector3.zero;
        if (_cm.type == CameraMovement.CAMERA_TYPE.FREE_LOOK)
        {
            w_speed = walk_speed;
            move = moveInput.z * m_CharForward * w_speed + moveInput.x * m_CharRight * walk_speed;
            _cam.transform.position += move * Time.deltaTime;

            //rotate body
          //tpc.transform.position = Quaternion.LookRotation(Vector3.RotateTowards(tpc.transform.forward, move, rotation_speed, 0.0f));
        }
        else if (_cm.type == CameraMovement.CAMERA_TYPE.LOCKED)
        {
            w_speed = (moveInput.z > 0) ? walk_speed : backwards_walk_speed;
            move = moveInput.z * m_CharForward * w_speed + moveInput.x * m_CharRight * strafe_speed;
            
        }
        transform.position += move * Time.deltaTime; //move the actual player

        
        //Update animations flangs
        if (_cm.type == CameraMovement.CAMERA_TYPE.FREE_LOOK)
        {
            walking = (moveInput.x != 0 || moveInput.z != 0);
        }
        else if (_cm.type == CameraMovement.CAMERA_TYPE.LOCKED) 
        {
            walking = (moveInput.z > 0 && moveInput.x == 0);
            backwards = (moveInput.z < 0 && moveInput.x == 0);
            strafeLeft = (moveInput.x < 0);
            strafeRight = (moveInput.x > 0);
        }
    }

    void Jump()
    {
        if (jump && isGrounded)
        {
            _rb.AddForce(Vector3.up * jump_force, ForceMode.Impulse);
        }
    }

    
   

    /*void FallRespawn()
    {
        if (transform.position.y < fallLimit)
        {
            Destroy(gameObject);
        }
    }*/

    void PlayerStateMachine() 
    { }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BreakingDoor0")) { Destroy(pared[0]); }
        if (other.gameObject.CompareTag("Prueba1")){ triggerPhase[1].SetActive(true); spawner.SetActive(true); }
        if (other.gameObject.CompareTag("BreakingDoor1")){Destroy(pared[1]);}
        if (other.gameObject.CompareTag("Prueba2")) { triggerPhase[2].SetActive(true); }
        if (other.gameObject.CompareTag("BreakingDoor2")) { Destroy(pared[2]); }
        if (other.gameObject.CompareTag("Video")) { videoBoss.SetActive(true); Cursor.lockState = CursorLockMode.None;}
    }
}
