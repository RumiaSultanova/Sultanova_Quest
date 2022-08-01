using UnityEngine;

namespace Quest.Enemies
{
    public class SpawnEnemy : Enemy
    {
        [SerializeField] private Enemy enemyPrefab;
        [SerializeField] private float spawnStep = 1f;
        private const float LifeTime = .5f;

        private void OnEnable()
        {
            InvokeRepeating(nameof(Spawn), 0f, spawnStep);
        }

        private void Spawn()
        {
            var enemy = Instantiate(enemyPrefab, transform);
            Destroy(enemy.gameObject, LifeTime);
        }

        private void OnDisable()
        {
            CancelInvoke(nameof(Spawn));
        }
    }
}
