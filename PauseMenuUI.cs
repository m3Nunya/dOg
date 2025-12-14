using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuUI : MonoBehaviour
{
    public GameObject pauseMenuPanel;
    public GameObject pauseMenu;
    
    private bool isPaused = false;

    public GameSaveManger saveManager;

    public void SaveSlot1()
{
    saveManager.SaveIntoSlot(1);
    RefreshSlotUI1();
}

void RefreshSlotUI1()
{
    SlotUI[] slots = FindObjectsByType<SlotUI>(FindObjectsSortMode.None);
    foreach (var slot in slots)
        slot.RefreshSlot();
}

public void SaveSlot2()
{
    saveManager.SaveIntoSlot(1);
    RefreshSlotUI2();
}

void RefreshSlotUI2()
{
    SlotUI[] slots = FindObjectsByType<SlotUI>(FindObjectsSortMode.None);
    foreach (var slot in slots)
        slot.RefreshSlot();
}

public void SaveSlot3()
{
    saveManager.SaveIntoSlot(1);
    RefreshSlotUI3();
}

void RefreshSlotUI3()
{
    SlotUI[] slots = FindObjectsByType<SlotUI>(FindObjectsSortMode.None);
    foreach (var slot in slots)
        slot.RefreshSlot();
}


    public void PauseGame()
    {
        pauseMenuPanel.SetActive(true);
        Time.timeScale = 0f; 
        isPaused = true;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f; 
        isPaused = false;
    }
    

    public void LoadMainMenu()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(0); 
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    
     
}
