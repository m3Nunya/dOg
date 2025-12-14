using UnityEngine;

public class LoadUI : MonoBehaviour
{
    public void LoadSlot(int slot)
    {
        SaveData data = SaveSystem.LoadGame(slot);

        if (data == null)
        {
            Debug.LogWarning("No valid save in slot " + slot);
            return;
        }

        SelectedSlot.slotToLoad = slot;
        SceneLoader.isLoadingSave = true;

        if (SceneLoader.Instance == null)
        {
            Debug.LogError("SceneLoader instance missing! Cannot load scene.");
            return;
        }

        SceneLoader.Instance.LoadSaveWithLoadingScreen(data);
    }
}
