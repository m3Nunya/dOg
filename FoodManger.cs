using UnityEngine;

public class FoodManager : MonoBehaviour
{
    public int food = 0;
    public int foodToWin = 3;

    private bool hasTriggeredLoad = false;

    public void AddFood(int amount)
    {
        if (amount <= 0) return;

        food += amount;
        Debug.Log("Food: " + food);

        CheckFoodGoal();
    }

    void CheckFoodGoal()
    {
        if (hasTriggeredLoad)
            return;

        if (food >= foodToWin)
        {
            hasTriggeredLoad = true;

            Debug.Log("Food goal reached → Loading Scene 1, then Scene 5");

            Time.timeScale = 1f;

            // Use SceneLoader to go through Scene 1
            SceneLoader.Instance.LoadSceneWithLoadingScreen(5);
        }
    }

    // Used by save loading (prevents instant scene jump)
    public void SetFoodSilently(int amount)
    {
        food = Mathf.Max(0, amount);
    }
}
