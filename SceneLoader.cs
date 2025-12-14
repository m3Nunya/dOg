using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance;
    public int targetSceneIndex;
    public SaveData pendingLoadData;
    public int currentSaveSlot = -1;
    public static bool isLoadingSave = false;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        if (isLoadingSave)
            Debug.Log("SceneLoader initialized while loading save.");
        else
            Debug.Log("SceneLoader Awake normal");
    }


    public void SelectSlot(int slot)
    {
        SceneLoader.Instance.currentSaveSlot = slot;
        Debug.Log("Selected Save Slot: " + slot);
    }

    public void SelectSlotAndLoad(int slot)
    {
        SceneLoader.Instance.currentSaveSlot = slot;
        Debug.Log("Selected Save Slot for Loading: " + slot);

        SaveData data = SaveSystem.LoadGame(slot);
        if (data != null)
        {
           SceneLoader.Instance.LoadSaveWithLoadingScreen(data);
        }
        else
        {
            Debug.LogWarning("No save data found in slot " + slot);
            SceneLoader.Instance.LoadSceneWithLoadingScreen(2);
        }
    }
    
    public void LoadSceneWithLoadingScreen(int sceneIndex)
    {
        targetSceneIndex = sceneIndex;
        pendingLoadData = null;
        SceneManager.LoadScene(1);
    }

    public void LoadSaveWithLoadingScreen(SaveData data)
    {
        targetSceneIndex = data.level;
        pendingLoadData = data;
        SceneManager.LoadScene(1);
    }
}
