using UnityEngine;
using System.Collections;

public class GameSaveManger : MonoBehaviour
{
    private Transform player;
    private Rigidbody2D playerRb;
    private Player playerScript;
    public int health;
    public int[] inventoryItems;
    public int food;

   void Start()
    {
        if (SelectedSlot.slotToLoad != -1)
        {
            LoadFromSlot(SelectedSlot.slotToLoad);
            SelectedSlot.slotToLoad = -1;
        }
    }

    public void SaveIntoSlot(int slot)
    {
        if (player == null)
            FindPlayer();

        if (player == null)
        {
            Debug.LogError("Cannot save: Player not found!");
            return;
        }

        SaveData data = new SaveData();

        data.level = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;

        data.playerPosition = new float[3] 
        { 
            player.position.x, 
            player.position.y, 
            player.position.z 
        };

        data.health = Mathf.Max(0, health);
        data.inventoryItems = (inventoryItems != null) ? (int[])inventoryItems.Clone() : new int[0];
        FoodManager fm = player.GetComponent<FoodManager>();
        data.food = fm != null ? fm.food : 0;

        try
        {
            SaveSystem.SaveGame(data, slot);
            Debug.Log("Saved game to slot " + slot);
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Failed to save game: " + ex.Message);
        }
    }

    public void LoadFromSlot(int slot)
    {
      StartCoroutine(LoadAfterSceneCoroutine());
    }
    
    public void NewGame()
    {
        if (SceneLoader.Instance == null)
        {
            Debug.LogError("SceneLoader.Instance is NULL — cannot start new game");
            return;
        }

        SceneLoader.isLoadingSave = false;

        int startSceneIndex = 2; // Make sure this exists in Build Settings
        if (startSceneIndex >= UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings)
        {
            Debug.LogError("Start scene index is invalid in Build Settings!");
            return;
        }

        SceneLoader.Instance.LoadSceneWithLoadingScreen(startSceneIndex);
    }

    IEnumerator LoadAfterScene(SaveData data)
    {
        if (player == null)
        {
            FindPlayer();
            if (player == null)
            {
                Debug.LogError("Player not found — cannot load position!");
                yield break;
            }
        }

        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D not found on player!");
            yield break;
        }

        Vector2 loadedPos = new Vector2(
            data.playerPosition.Length > 0 ? data.playerPosition[0] : player.position.x,
            data.playerPosition.Length > 1 ? data.playerPosition[1] : player.position.y
        );

        playerScript.allowMovement = false;

        yield return new WaitForEndOfFrame();
        yield return new WaitForFixedUpdate();

        rb.position = loadedPos;
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;

        Debug.Log("Player position applied: " + rb.position);

        playerScript.allowMovement = true;

        FoodManager fm = player.GetComponent<FoodManager>();
        if (fm != null)
        {
            fm.SetFoodSilently(data.food);
        }
    }


    void FindPlayer()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

        if (playerObj == null)
        {
            Debug.LogError("Player not found in scene!");
            return;
        }

        player = playerObj.transform;
        playerRb = playerObj.GetComponent<Rigidbody2D>();
        playerScript = playerObj.GetComponent<Player>();

        if (playerScript == null)
            Debug.LogError("Player script component not found on Player object!");
    }
    IEnumerator WaitForPlayer()
    {
        while (GameObject.FindGameObjectWithTag("Player") == null)
        {
            yield return null; // wait one frame
        }

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        player = playerObj.transform;
        playerRb = playerObj.GetComponent<Rigidbody2D>();
        playerScript = playerObj.GetComponent<Player>();

        if (playerScript == null)
            Debug.LogError("Player script component not found on Player object!");
    }

    IEnumerator LoadAfterSceneCoroutine()
    {
        yield return StartCoroutine(WaitForPlayer());
        StartCoroutine(LoadAfterScene(SaveSystem.LoadGame(SelectedSlot.slotToLoad)));
    }
}
