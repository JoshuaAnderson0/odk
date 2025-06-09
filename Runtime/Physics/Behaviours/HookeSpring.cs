using UnityEngine;

namespace Physics.Behaviours
{
    public class HookeSpring : MonoBehaviour
    {
        [SerializeField]
        private Transform _target;
        
        [SerializeField]
        private Rigidbody _connectedRigidbody;

        [SerializeField]
        private float _climbForce = 1000f;
        
        [SerializeField]
        private float _climbDrag = 500f;
        
        private bool _isColliding;
        private Vector3 _previousPosition;

        public void Start()
        {
            _previousPosition = transform.position;
        }
        
        public void FixedUpdate()
        {
            if (_isColliding)
            {
                ApplySpring();
            }
        }

        private void ApplySpring()
        {
            Vector3 displacementFromResting = transform.position - _target.position;
            Vector3 force = displacementFromResting * _climbForce;
            float drag = GetDrag();
         
            _connectedRigidbody.AddForce(force, ForceMode.Acceleration);
            _connectedRigidbody.AddForce(-_connectedRigidbody.linearVelocity * (drag * _climbDrag), ForceMode.Acceleration);
        }

        private float GetDrag()
        {
            Vector3 velocity = (_target.localPosition - _previousPosition) / Time.deltaTime;
            float drag = 1 / velocity.magnitude + 0.01f;
            drag = drag > 1 ? 1 : drag;
            drag = drag < 0.03f ? 0.03f : drag;

            _previousPosition = transform.position;
            
            return drag;
        }

        void OnCollisionEnter(Collision collision)
        {
            _isColliding = true;
        }

        void OnCollisionExit(Collision collision)
        {
            _isColliding = false;
        }
    }
}