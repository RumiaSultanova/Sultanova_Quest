using UnityEngine;

namespace Quest.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speed = 3f;
        [SerializeField] private float runSpeed = 5f;
        [SerializeField] private float angularSpeed = 100f;

        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";
        private const string Running = "Running";
        private const string MouseX = "Mouse X";

        private Vector3 direction;
        private Vector3 rotationDir;
        private bool isRunning;
        
        private void Update()
        {
            direction.x = Input.GetAxis(Horizontal);
            direction.z = Input.GetAxis(Vertical);
            isRunning = Input.GetButton(Running);

            rotationDir.y = Input.GetAxis(MouseX) * angularSpeed * Time.deltaTime;
            
            transform.position += direction * ((isRunning ? runSpeed : speed) * Time.deltaTime);
            transform.Rotate(rotationDir);
        }
    }
}