using UnityEngine;

public class TouchesDrawer : MonoBehaviour
{

    public GameObject touchesHost;
    public GameObject touchPrefab;

    private TouchQueueHandler _touchQueueHandler;

    private Vector3[] _currentTouches;
    private Vector3 _currentTouchPosition;
    private Vector2 _prefabPosition;
    private int _touchIndex;

    void Start()
    {
        _touchQueueHandler = touchesHost.GetComponent<TouchQueueHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        _currentTouches = _touchQueueHandler.GetCurrentTouches();
        for (_touchIndex = 0; _touchIndex < _currentTouches.Length; _touchIndex++)
        {
            _currentTouchPosition = Camera.main.ScreenToWorldPoint(_currentTouches[_touchIndex]);
            _prefabPosition = new Vector2(
                _currentTouchPosition.x,
                _currentTouchPosition.y
            );

            Instantiate(touchPrefab, _prefabPosition, Quaternion.identity);
        }
    }

}
