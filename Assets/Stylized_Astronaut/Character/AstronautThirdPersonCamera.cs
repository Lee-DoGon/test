using UnityEngine;
using UnityEngine.InputSystem;

namespace AstronautThirdPersonCamera
{
    public class AstronautThirdPersonCamera : MonoBehaviour
    {
        private const float Y_ANGLE_MIN = 0.0f;
        private const float Y_ANGLE_MAX = 50.0f;

        [Header("References")]
        public Transform lookAt;
        public Transform camTransform;

        [Header("Camera Settings")]
        public float distance = 5.0f;
        public float sensitivityX = 20.0f;
        public float sensitivityY = 20.0f;

        private float currentX = 0.0f;
        private float currentY = 45.0f;

        private void Start()
        {
            camTransform = transform;
        }

        private void Update()
        {
            if (Mouse.current == null) return;

            Vector2 mouseDelta = Mouse.current.delta.ReadValue();

            currentX += mouseDelta.x * sensitivityX * Time.deltaTime;
            currentY -= mouseDelta.y * sensitivityY * Time.deltaTime;

            currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
        }

        private void LateUpdate()
        {
            if (lookAt == null) return;

            Vector3 dir = new Vector3(0, 0, -distance);
            Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);

            camTransform.position = lookAt.position + rotation * dir;
            camTransform.LookAt(lookAt.position);
        }
    }
}