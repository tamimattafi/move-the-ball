using UnityEngine;

public class TouchesDrawer : MonoBehaviour
{

    public GameObject touchesHost;
    private TouchQueueHandler _touchQueueHandler;

    private LineRenderer _lineRenderer;
    private Vector3[] _currentTouches;
    private int _touchIndex;

    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _touchQueueHandler = touchesHost.GetComponent<TouchQueueHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        _currentTouches = _touchQueueHandler.GetCurrentTouches();
        _lineRenderer.positionCount = _currentTouches.Length;

        for (_touchIndex = 0; _touchIndex < _currentTouches.Length; _touchIndex++)
        {
            _lineRenderer.SetPosition(_touchIndex, _currentTouches[_touchIndex]);
        }
    }

}
