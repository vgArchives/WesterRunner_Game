using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder (-1)]
public sealed class TouchManager : Singleton<TouchManager>
{
    public delegate void StartTouchAction(Vector2 position, float time);
    public event StartTouchAction OnStartTouch;

    public delegate void EndTouchAction(Vector2 position, float time);
    public event EndTouchAction OnEndTouch;

    [SerializeField] private Camera _swipeCamera;

    private PlayerInputs playerInputs;

    public Camera SwipeCamera { get => _swipeCamera; }

    public void Initialize(Camera swipeCamera)
    {
        _swipeCamera = swipeCamera;

        Awake();
    }

    private void Awake() 
    {
        playerInputs = new PlayerInputs();  
    }

    private void OnEnable() 
    {
        playerInputs.Enable();
    }
    
    private void OnDisable() 
    {
        playerInputs.Disable();    
    }

    private void Start() 
    {
        playerInputs.Inputs.TouchPress.started += ctx => StartTouch(ctx);
        playerInputs.Inputs.TouchPress.canceled += ctx => EndTouch(ctx);    
    }

    private void StartTouch(InputAction.CallbackContext context)
    {
        OnStartTouch?.Invoke(Utils.ScreenToWorld(SwipeCamera, playerInputs.Inputs.TouchPosition.ReadValue<Vector2>()), (float) context.startTime);
    }

    private void EndTouch(InputAction.CallbackContext context)
    {
        OnEndTouch?.Invoke(Utils.ScreenToWorld(SwipeCamera, playerInputs.Inputs.TouchPosition.ReadValue<Vector2>()), (float) context.time);
    }
}

public class Utils 
{
    public static Vector3 ScreenToWorld(Camera camera, Vector3 position) 
    {
        position.z = camera.nearClipPlane;
        return camera.ScreenToWorldPoint(position);
    }
}
