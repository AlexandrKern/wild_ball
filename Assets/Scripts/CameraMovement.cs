using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _transwormWildBall;

    private Vector3 _offSet;

    void Start()
    {
        _offSet = transform.position - _transwormWildBall.position;
    }

    private void FixedUpdate()
    {
        transform.position = _offSet + _transwormWildBall.position;
    }
}
