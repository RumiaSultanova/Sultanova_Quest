using UnityEngine;

namespace Quest
{
    public class HealthManager : MonoBehaviour
    {
        [SerializeField] private float maxHealth = 100f;
        [SerializeField] private float curHealth;

        private void Awake()
        {
            curHealth = maxHealth;
        }

        public void Hit(float damage)
        {
            curHealth -= damage;
            if (curHealth <= 0)
            {
                Time.timeScale = 0;
            }
        }
    }
}