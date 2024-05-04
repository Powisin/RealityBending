using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.EventSystems;


public class PlayerController : MonoBehaviour
{

    private Rigidbody _rb;

    #region Camera
    private Camera _cam;
    private CameraMovement _cm;
    private Vector3 camFwd;
    #endregion

    #region Movement
    [Range(1.0f, 10.0f)]
    public float walk_speed;
    [Range(1.0f, 10.0f)]
    public float backwards_walk_speed;
    [Range(1.0f, 10.0f)]
    public float strafe_speed;

    [Range(0.1f, 1.5f)]
    public float rotation_speed;

    [Range(2.0f, 10.0f)]
    public float jump_force;
    #endregion

    #region Animations
    //private MyTPCharacter tpc;
    private bool walking = false;
    private bool strafeLeft = false;
    private bool strafeRight = false;
    private bool backwards = false;
    private bool jump = false;
    #endregion

    [SerializeField] int fallLimit;
    private void Awake()
    {
        //tpc = FindObjectOfType<MyTPCharacter>();
        _cm = GetComponent<CameraMovement>();
        _cam = _cm.GetCamera();
        _rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        //gets the inputs
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        jump = Input.GetButtonDown("Jump");

        //calculate camera relative directions to move:
        camFwd = Vector3.Scale(_cam.transform.forward, new Vector3(1, 1, 1)).normalized;
        Vector3 camFlatFwd = Vector3.Scale(_cam.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 flatRight = new Vector3(_cam.transform.right.x, 0, _cam.transform.right.z);

        Vector3 m_CharForward = Vector3.Scale(camFlatFwd, new Vector3(1, 0, 1)).normalized;
        Vector3 m_CharRight = Vector3 .Scale(flatRight, new Vector3(1, 0, 1)).normalized;

        //draws a ray to show the direction the player is aiming at
        Debug.DrawLine(transform.position, transform.position + camFwd * 5f, Color.red);

        //move the pplayer (movement will be slightly different depending on the camera type)
        float w_speed;
        Vector3 move = Vector3.zero;
        if (_cm.type == CameraMovement.CAMERA_TYPE.FREE_LOOK)
        {
            w_speed = walk_speed;
            move = v * m_CharForward * w_speed + h * m_CharRight * walk_speed;
            _cam.transform.position += move * Time.deltaTime;

            //rotate body
          //tpc.transform.position = Quaternion.LookRotation(Vector3.RotateTowards(tpc.transform.forward, move, rotation_speed, 0.0f));
        }
        else if (_cm.type == CameraMovement.CAMERA_TYPE.LOCKED)
        {
            w_speed = (v > 0) ? walk_speed : backwards_walk_speed;
            move = v * m_CharForward * w_speed + h * m_CharRight * strafe_speed;
        }

        transform.position += move * Time.deltaTime; //move the actual player

        //jump
        if (jump) 
        {
            _rb.AddForce(Vector3.up * jump_force, ForceMode.Impulse);
        }

        //Update animations flangs
        if (_cm.type == CameraMovement.CAMERA_TYPE.FREE_LOOK)
        {
            walking = (h != 0 || v != 0);
        }
        else if (_cm.type == CameraMovement.CAMERA_TYPE.LOCKED) 
        {
            walking = (v > 0 && h == 0);
            backwards = (v < 0 && h == 0);
            strafeLeft = (h < 0);
            strafeRight = (h > 0);
        }
    }

    void Update()
    {
        FallRespawn();

        PlayerStateMachine();
        
        //animations
        /*tpc.GetFullBodyAnimator().SetBool("walking", walking);
        tpc.GetFullBodyAnimator().SetBool("sttrafeLeft", strafeLeft);
        tpc.GetFullBodyAnimator().SetBool("strafeRight", strafeRight);
        tpc.GetFullBodyAnimator().SetBool("backwards", backwards);
        tpc.GetFullBodyAnimator().SetBool("jump", jump);*/


    }
   

    void FallRespawn()
    {
        if (transform.position.y < fallLimit)
        {
            Destroy(gameObject);
        }
    }

    void PlayerStateMachine() 
    { }
}
