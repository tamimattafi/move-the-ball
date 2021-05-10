using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TouchQueueHandler : MonoBehaviour
{
    private Queue<Vector3> _touchPositionsQueue;
    private Touch _currentTouch;

    void Awake()
    {
        _touchPositionsQueue = new Queue<Vector3>();
    }

    public Vector3 DequeueNextTouchPosition()
    {
        return _touchPositionsQueue.Dequeue();
    }

    public bool HasTouches()
    {
        return _touchPositionsQueue.Count > 0;
    }

    public Vector3[] GetCurrentTouches()
    {
        return _touchPositionsQueue.ToArray();
    }

    void Update()
    {
        if (Input.touchCount <= 0) return;
        _currentTouch = Input.GetTouch(0);

        if (_currentTouch.phase != TouchPhase.Began) return;
        _touchPositionsQueue.Enqueue(_currentTouch.position);
    }
}
