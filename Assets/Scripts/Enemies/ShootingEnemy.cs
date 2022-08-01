using System;
using System.Collections;
using UnityEngine;

namespace Quest.Enemies
{
    public class ShootingEnemy : MonoBehaviour
    {
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private Transform spawnPoint;
        private Transform player;

        [SerializeField] private float spawnStep = 1f;
        [SerializeField] private float angularSpeed = .5f;
        [SerializeField] private float shootDistance = 10f;

        private int playerLayerMask;
        
        private void Awake()
        {
            player = FindObjectOfType<Quest.Player.PlayerMovement>().transform;
            playerLayerMask = 1 << player.gameObject.layer;
        }

        private void OnEnable()
        {
            StartCoroutine(ShootRepeat());
        }

        private IEnumerator ShootRepeat()
        {
            while (enabled)
            {
                Shoot();
                yield return new WaitForSeconds(spawnStep);
            }
            yield return null;
        }

        private void Shoot()
        {
            Debug.DrawRay(spawnPoint.position, spawnPoint.forward, Color.red, shootDistance);
            if (Physics.Raycast(spawnPoint.position, spawnPoint.forward, out var hit, shootDistance,
                    playerLayerMask))
            {
                var bullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
                bullet.Init(player.tag);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(spawnPoint.position, spawnPoint.forward);
        }

        private void OnDisable()
        {
            StopCoroutine(ShootRepeat());
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
