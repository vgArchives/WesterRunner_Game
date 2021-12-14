using UnityEngine;

public sealed class SwipeDetection : MonoBehaviour
{
    public delegate void SwipeUpAction();
    public static event SwipeUpAction OnSwipeUp;
    
    public delegate void SwipeLeftAction();
    public static event SwipeLeftAction OnSwipeLeft;

    public delegate void SwipeRightAction();
    public static event SwipeRightAction OnSwipeRight;

    [SerializeField] private float _minimumDistance = 0.2f;
    [SerializeField] private float _maximumTime = 1f;
    [SerializeField] private float _directionThreshold = 0.9f;

    private TouchManager touchManager;

    private Vector2 startPosition;
    private float startTime;
    private Vector2 endPosition;
    private float endTime;

    public void Initialize(float minimumDistance,  float maximumTime, float directionThreshold) 
    {
        _minimumDistance = minimumDistance;
        _maximumTime = maximumTime;
        _directionThreshold = directionThreshold;

        Awake();
    }

    private void Awake()
    {
        touchManager = TouchManager.Instance;
    }

    private void OnEnable() 
    {
        touchManager.OnStartTouch += SwipeStart;
        touchManager.OnEndTouch += SwipeEnd;
    }

    private void OnDisable() 
    {
        touchManager.OnStartTouch -= SwipeStart;
        touchManager.OnEndTouch -= SwipeEnd;
    }

    private void SwipeStart(Vector2 position,  float time) 
    {
        startPosition = position;
        startTime = time;
    }

    private void SwipeEnd(Vector2 position,  float time) 
    {
        endPosition = position;
        endTime = time;

        DetectSwipe();
    }

    private void DetectSwipe() 
    {
        if(Vector3.Distance(startPosition, endPosition) >= _minimumDistance && (endTime - startTime) <= _maximumTime)
        {
            Debug.DrawLine(startPosition, endPosition, Color.blue, 5f);

            Vector3 direction = endPosition - startPosition;
            Vector2 direction2D = new Vector2(direction.x, direction.y).normalized;
            SwipeDirection(direction2D);
        }
    }

    private void SwipeDirection(Vector2 direction) 
    {
        if(Vector2.Dot(Vector2.up, direction) > _directionThreshold)
        {
            OnSwipeUp?.Invoke();
        }

        else if(Vector2.Dot(Vector2.left, direction) > _directionThreshold)
        {
            OnSwipeLeft?.Invoke();
        }
        
        else if(Vector2.Dot(Vector2.right, direction) > _directionThreshold)
        {
            OnSwipeRight?.Invoke();
        }
    }
}
