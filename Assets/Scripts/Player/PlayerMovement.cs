using UnityEngine;

namespace Quest.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speed = 3f;
        [SerializeField] private float runSpeed = 5f;

        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";
        private const string Running = "Running";

        private Vector3 direction;
        private bool isRunning;
        
        private void Update()
        {
            direction.x = Input.GetAxis(Horizontal);
            direction.z = Input.GetAxis(Vertical);

            isRunning = Input.GetButton(Running);
            
            transform.position += direction * ((isRunning ? runSpeed : speed) * Time.deltaTime);
        }
    }
}