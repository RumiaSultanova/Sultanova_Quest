using UnityEngine;

namespace Quest.Enemies
{
    public class SpawnEnemy : Enemy
    {
        [SerializeField] private Enemy enemyPrefab;
        [SerializeField] private float spawnStep = 1f;
        private const float LifeTime = .5f;

        private float nextSpawnTime;

        private void Update()
        {
            if (Time.time > nextSpawnTime)
            {
                var enemy = Instantiate(enemyPrefab, transform);
                nextSpawnTime = Time.time + spawnStep;
                Destroy(enemy.gameObject, LifeTime);
            }
        }
    }
}
