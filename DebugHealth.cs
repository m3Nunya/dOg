using UnityEngine;
[RequireComponent(typeof(Health))]

public class DebugHealth : MonoBehaviour
{
   public void LogHealthChange(int currentHealth, int maxHealth)
    {
        Debug.Log(currentHealth + "/" + maxHealth);
    }

    public void LogHealthDepleted()
    {
        Debug.Log("Health depleted!");
    }
}
