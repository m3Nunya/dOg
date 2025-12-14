using UnityEngine;
using TMPro;

public class Leve1QuestUI : MonoBehaviour
{
   public FoodManager foodManager;
    public TextMeshProUGUI foodText;

    void Update()
    {
        if (foodManager != null)
            foodText.text = "QUESTS > _______________ 'Find Food" + foodManager.food + "/ 3)'";
    }
}
