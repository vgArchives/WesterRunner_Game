using UnityEngine;

public sealed class PlayerController : MonoBehaviour
{
    public delegate void MoveAction();
    public static event MoveAction OnSideMove;
   
    public delegate void JumpAction();
    public static event JumpAction OnJump;
    
    public delegate void DeathAction();
    public static event DeathAction OnDeath;
    
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _groundedRadius = 0.3f;
    [SerializeField] private float _sideMoveSpeed = 25f;   
    [SerializeField] private float _laneDistance = 3.0f;
    [SerializeField] private float _jumpHeight = 2f;
    [SerializeField] private float _gravity = -40f;

    private PlayerInputs playerInputs;

    private Animator animator;
    private CharacterController controller;
    
    private float verticalVelocity;
    private bool grounded = true;
    private int laneIndex = 1;

    public LayerMask GroundLayer { get => _groundLayer; }
    public float GroundedRadius { get => _groundedRadius; }
    public float SideMoveSpeed { get => _sideMoveSpeed; }
    public float LaneDistance { get => _laneDistance; }
    public float JumpHeight { get => _jumpHeight; }
    public float Gravity1 { get => _gravity; }

    public void Initialize(LayerMask groundLayer, float groundedRadius, float sideMoveSpeed, float laneDistance, float jumpHeight, float gravity)
    {
        _groundLayer = groundLayer;
        _groundedRadius = groundedRadius;
        _sideMoveSpeed = sideMoveSpeed;
        _laneDistance = laneDistance;
        _jumpHeight = jumpHeight;
        _gravity = gravity;

        Awake();
    }

    private void Awake() 
    {
        playerInputs = new PlayerInputs();    

        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    private void OnEnable() 
    {
        playerInputs.Enable();  

        playerInputs.Inputs.Jump.performed += _ => JumpInput();
        playerInputs.Inputs.Move.performed += _ => MoveInput();
        
        SwipeDetection.OnSwipeLeft += SwipeLeft;
        SwipeDetection.OnSwipeRight += SwipeRight; 
        SwipeDetection.OnSwipeUp += SwipeUp; 
    }

    private void OnDisable() 
    {
        playerInputs.Disable();    

        SwipeDetection.OnSwipeLeft -= SwipeLeft;
        SwipeDetection.OnSwipeRight -= SwipeRight; 
        SwipeDetection.OnSwipeUp -= SwipeUp; 
    }

    private void Update()
    {
        Gravity();
        GroundedCheck();
        Move();
    }

    private void Move()
    {
        Vector3 targetPosition = Vector3.zero;
        
        if(laneIndex == 0)
        {
            targetPosition += Vector3.left * LaneDistance;
        }
        else if(laneIndex == 2)
        {
            targetPosition += Vector3.right * LaneDistance;
        }

        Vector3 moveVector = Vector3.zero;

        moveVector.x = (targetPosition - transform.position).normalized.x * SideMoveSpeed;
        moveVector.y = verticalVelocity;
        moveVector.z = 0.0f;;

        controller.Move(moveVector * Time.deltaTime);
    }

    private void GroundedCheck()
    {
        Vector3 spherePosition = new Vector3(transform.position.x,  transform.position.y, transform.position.z);
        grounded =  Physics.CheckSphere(spherePosition, GroundedRadius, GroundLayer);
    }

    private void Gravity()
    {
        if(grounded && verticalVelocity < 0.0f)
        {
            verticalVelocity = -2f;
        }

        verticalVelocity += Gravity1 * Time.deltaTime;
    }

    private void MoveInput()
    {
        float moveInput = playerInputs.Inputs.Move.ReadValue<float>();

        laneIndex += (int) moveInput;
        laneIndex = Mathf.Clamp(laneIndex, 0, 2);

        OnSideMove?.Invoke();
    }

    private void SwipeLeft() 
    {
        laneIndex --;
        laneIndex = Mathf.Clamp(laneIndex, 0, 2);

        OnSideMove?.Invoke();
    }

    private void SwipeRight() 
    {
        laneIndex ++;
        laneIndex = Mathf.Clamp(laneIndex, 0, 2);

        OnSideMove?.Invoke();
    }

    private void SwipeUp() 
    {
        JumpInput();
    }

    private void JumpInput()
    {
        if(grounded)
        {
            verticalVelocity = Mathf.Sqrt(JumpHeight * -2f * Gravity1);
            controller.Move(new Vector3(0f, verticalVelocity * Time.deltaTime, 0f));

            animator.SetTrigger("Jump");
            OnJump?.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Obstacle"))
        {
            OnDeath?.Invoke();
        } 
    }
}
