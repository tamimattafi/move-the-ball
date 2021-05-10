using UnityEngine;

public class Stalker : MonoBehaviour
{
    public GameObject stalkedObject;

    private Transform _currentCameraTransform;
    private Vector3 _currentObjectPosition;
    // Update is called once per frame
    void Update()
    {
        _currentObjectPosition = stalkedObject.transform.position;
        _currentCameraTransform = transform;

        _currentCameraTransform.position = new Vector3(
            _currentObjectPosition.z,
            _currentObjectPosition.y,
            _currentCameraTransform.position.z
        );

        _currentCameraTransform.LookAt(stalkedObject.transform);
    }
}
