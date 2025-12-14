using UnityEngine;
using UnityEngine.Events;

[DisallowMultipleComponent]
public class Health : MonoBehaviour
{
[SerializeField] private int m_currentHealth;
[SerializeField] private int m_maxHealth = 100;

    public UnityEvent<int,int> onHealthChange; // (currentHealth, maxHealth)
    public UnityEvent onHealthDepleted;
    
    private void Awake()
    {
        m_currentHealth = Mathf.Clamp(m_currentHealth, 0, m_maxHealth);
    }

    private void OnValidate()
    {
        m_maxHealth = Mathf.Max(m_maxHealth, 1);
        m_currentHealth = Mathf.Clamp(m_currentHealth, 0, m_maxHealth);
    }

    public void TakeDamage(int amount)
    {
        if (amount <= 0)
            {
                return;
            }
        m_currentHealth = Mathf.Max(m_currentHealth - amount, 0);
        onHealthChange?.Invoke(m_currentHealth, m_maxHealth);
        if (m_currentHealth <= 0)
        {
            onHealthDepleted?.Invoke();
        }
    }
    public void Heal(int amount)
    {
        if (amount <= 0)
            {
                return;
            }
        m_currentHealth = Mathf.Min(m_currentHealth + amount, m_maxHealth);
        onHealthChange?.Invoke(m_currentHealth, m_maxHealth);
    }
}