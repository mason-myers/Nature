using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : Menu
{
    [Title("Menu Navigation")][SerializeField] private SaveSlotsMenu saveSlots;
    
    [Title("Menu Buttons")][SerializeField] private Button newGameButton;
    [SerializeField] private Button continueGameButton;
    [SerializeField] private Button loadGameButton;
    
    private GameData data;

    private void Start()
    {
        if (!DataPersistenceManager.Instance.HasGameData())
        {
            continueGameButton.interactable = false;
            loadGameButton.interactable = false;
        }
    }

    public void OnNewGameClicked()
    {
        DeactivateMenu();
        saveSlots.ActivateMenu(false);
    }

    public void OnLoadGameClicked()
    {
        saveSlots.ActivateMenu(true);
        DeactivateMenu();
    }

    public void OnContinueGameClicked()
    {
        DisableMenuButtons();
        
        DataPersistenceManager.Instance.SaveGame();
        
        SceneManager.LoadSceneAsync(data.currentScene);
    }

    private void DisableMenuButtons()
    {
        newGameButton.interactable = false;
        continueGameButton.interactable = false;
    }

    public void ActivateMenu()
    {
        gameObject.SetActive(true);
    }

    public void DeactivateMenu()
    {
        gameObject.SetActive(false);
    }
}