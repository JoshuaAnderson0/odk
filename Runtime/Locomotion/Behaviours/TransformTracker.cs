using UnityEngine;

namespace Locomotion.Behaviours
{
    public class TransformTracker : MonoBehaviour
    {
        [SerializeField] 
        private Transform _target;
        
        [SerializeField] 
        bool _trackRelativeTransform;

        public void Update()
        {
            if (_trackRelativeTransform)
            {
                transform.localPosition = _target.localPosition;
                transform.localRotation = _target.localRotation;
            }
            else
            {
                transform.position = _target.position;
                transform.rotation = _target.rotation;
            }
        }
    }
}