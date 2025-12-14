using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class CollectableFood : MonoBehaviour
{
    [SerializeField] AudioSource crunch;
    public int foodValue = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        FoodManager foodManager = other.GetComponent<FoodManager>();
        if (foodManager != null)
        {
            crunch.Play();
            foodManager.AddFood(foodValue);
            Destroy(gameObject);
        }
        else
        {
            Debug.LogWarning("Player has no FoodManager!");
        }
    }
}
