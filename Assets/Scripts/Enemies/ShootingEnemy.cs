using System.Collections;
using UnityEngine;

namespace Quest.Enemies
{
    public class ShootingEnemy : MonoBehaviour
    {
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private float spawnStep = 1f;
        [SerializeField] private float angularSpeed = .5f;
        private Transform player;

        private void Start()
        {
            player = FindObjectOfType<Quest.Player.PlayerMovement>().transform;
        }

        private void OnEnable()
        {
            StartCoroutine(Shoot());
        }

        private IEnumerator Shoot()
        {
            while (enabled)
            {
                Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
                yield return new WaitForSeconds(spawnStep);
            }
            yield return null;
        }

        private void OnDisable()
        {
            StopCoroutine(Shoot());
        }

        private void Update()
        {
            LookAtPlayer();
        }

        private void LookAtPlayer()
        {
            var direction = player.transform.position - transform.position;
            var rotation = Vector3.RotateTowards(transform.forward, direction, angularSpeed * Time.deltaTime, 0f);
            transform.rotation = Quaternion.LookRotation(rotation);
        }
    }
}
