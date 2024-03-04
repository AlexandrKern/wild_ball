using UnityEngine;

namespace Scripts
{
    public class MovementInputData : MonoBehaviour
    {
        private Vector3 _movement;

        private float _horizontal;
        private float _vertical;

        private WildBall _wildBall;

        private void Awake()
        {
            _wildBall = GetComponent<WildBall>();
        }

        void Update()
        {
           DataInitialization();
        }

        private void FixedUpdate()
        {
            _wildBall.BallMovement(_movement);
        }

        private void DataInitialization()
        {
            _horizontal = Input.GetAxis(GlobalString.HORIZONTAL_AXIS);
            _vertical = Input.GetAxis(GlobalString.VERTICAL_AXIS);

            _movement = new Vector3(_horizontal, 0, _vertical);
        }
    }
}
