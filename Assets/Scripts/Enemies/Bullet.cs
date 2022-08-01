using UnityEngine;

namespace Quest.Enemies
{
    [RequireComponent(typeof(Rigidbody))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float speed = 50f;
        [SerializeField] private float damage = 5f;

        private Rigidbody rb;

        private string targetTag;
        
        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * speed, ForceMode.Impulse);
        }

        public void Init(string targetTag)
        {
            this.targetTag = targetTag;
        }
        
        private void OnCollisionEnter(Collision collision)
        {
            Hit(collision.gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            Hit(other.gameObject);
        }

        private void Hit(GameObject collisionGO)
        {
            if (collisionGO.CompareTag(targetTag) && collisionGO.TryGetComponent(out HealthManager health))
            {
                health.Hit(damage);
            }
            Destroy(gameObject);
        }
    }
}
