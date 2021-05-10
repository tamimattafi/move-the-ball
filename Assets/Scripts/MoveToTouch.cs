using UnityEngine;
using UnityEngine.UI;

public class MoveToTouch : MonoBehaviour
{

    public GameObject touchesHost;
    public Slider speedController;

    private TouchQueueHandler _touchQueueHandler;
    private Rigidbody2D _objectRigidBody;
    private Vector3 _newTouchPosition, _currentTouchPosition, _currentObjectPosition, _targetPosition;
    private bool _isMoving;
    private float _distanceToTouchPosition, _previousDistanceToTouchPosition;

    // Start is called before the first frame update
    void Start()
    {
        _touchQueueHandler = touchesHost.GetComponent<TouchQueueHandler>();
        _objectRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _currentObjectPosition = transform.position;

        if (_isMoving)
        {
            _distanceToTouchPosition = (_currentTouchPosition - _currentObjectPosition).magnitude;
        }
        else if (_touchQueueHandler.HasTouches())
        {
            _distanceToTouchPosition = 0;
            _previousDistanceToTouchPosition = 0;
            _isMoving = true;

            _newTouchPosition = _touchQueueHandler.DequeueNextTouchPosition();
            _currentTouchPosition = Camera.main.ScreenToWorldPoint(_newTouchPosition);
            _targetPosition = (_currentTouchPosition - _currentObjectPosition).normalized;

            _objectRigidBody.velocity = new Vector2(
                _targetPosition.x * speedController.value,
                _targetPosition.y * speedController.value
            );
        }

        if (_distanceToTouchPosition > _previousDistanceToTouchPosition)
        {
            _isMoving = false;
            _objectRigidBody.velocity = Vector2.zero;
        }

        if (_isMoving)
        {
            _previousDistanceToTouchPosition = (_currentTouchPosition - _currentObjectPosition).magnitude;
        }

    }

}
