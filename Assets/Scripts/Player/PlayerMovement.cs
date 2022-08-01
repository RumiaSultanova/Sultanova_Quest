using UnityEngine;

namespace Quest.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speed = 3f;
        [SerializeField] private float runSpeed = 5f;
        [SerializeField] private float jumpForce = 5f;
        [SerializeField] private float angularSpeed = 100f;

        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";
        private const string Running = "Running";
        private const string MouseX = "Mouse X";
        private const string Ground = "Ground";

        private Vector3 direction;
        private Vector3 rotationDir;
        private bool isRunning;
        private bool isGround = true;

        private Rigidbody rb;
        
        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            direction.x = Input.GetAxis(Horizontal);
            direction.z = Input.GetAxis(Vertical);
            isRunning = Input.GetButton(Running);
            rotationDir.y = Input.GetAxis(MouseX) * angularSpeed * Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Space) && isGround)
            {
                rb.AddForce(jumpForce * transform.up, ForceMode.Impulse);
            }
            
            transform.position += direction * ((isRunning ? runSpeed : speed) * Time.deltaTime);
            transform.Rotate(rotationDir);
        }

        private void OnCollisionEnter(Collision collision)
        {
            isGround = collision.gameObject.CompareTag(Ground);
        }

        private void OnCollisionExit(Collision other)
        {
            isGround = !other.gameObject.CompareTag(Ground);
        }
    }
}