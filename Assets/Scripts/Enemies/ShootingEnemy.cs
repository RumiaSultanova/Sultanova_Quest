using UnityEngine;

namespace Quest.Enemies
{
    public class ShootingEnemy : MonoBehaviour
    {
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private float spawnStep = 1f;
        [SerializeField] private float angularSpeed = .5f;
        private float nextSpawnTime;
        private Transform player;

        private void Start()
        {
            player = FindObjectOfType<Quest.Player.PlayerMovement>().transform;
        }

        private void Update()
        {
            LookAtPlayer();
            Shoot();
        }

        private void LookAtPlayer()
        {
            var direction = player.transform.position - transform.position;
            var rotation = Vector3.RotateTowards(transform.forward, direction, angularSpeed * Time.deltaTime, 0f);
            transform.rotation = Quaternion.LookRotation(rotation);
        }

        private void Shoot()
        {
            if (Time.time > nextSpawnTime)
            {
                Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
                nextSpawnTime = Time.time + spawnStep;
            }
        }
    }
}
