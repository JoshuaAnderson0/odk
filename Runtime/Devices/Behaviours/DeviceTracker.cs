using UnityEngine;
using UnityEngine.InputSystem;

namespace Devices
{
    public class DeviceTracker : MonoBehaviour
    {
        [SerializeField]
        private InputActionAsset _deviceActions;

        private InputAction _positionAction;
        private InputAction _rotationAction;

        public void Awake()
        {
            _positionAction = _deviceActions.FindAction("Position");
            _rotationAction = _deviceActions.FindAction("Rotation");
        }

        public void OnEnable()
        {
            _deviceActions.Enable();
        }

        public void OnDisable()
        {
            _deviceActions.Disable();
        }

        public void Update()
        {
            transform.position = _positionAction.ReadValue<Vector3>();
            transform.rotation = _positionAction.ReadValue<Quaternion>();
        }
    }
}