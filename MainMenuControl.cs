using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuControl : MonoBehaviour
{
    [SerializeField] GameObject fadeOut;
    [SerializeField] GameObject studioText;
    [SerializeField] GameObject InvisBigButton;
    [SerializeField] GameObject animCam;
    [SerializeField] GameObject mainCam;
    [SerializeField] GameObject menuControls;
    [SerializeField] AudioSource buttonSelect;
    public static bool hasClicked;
    [SerializeField] GameObject staticCam;
    [SerializeField] GameObject fadeIn;
    
    void Start()
    {
        StartCoroutine(FadeInTurnOff());
        if (hasClicked == true)
        {;
            staticCam.SetActive(true);
            animCam.SetActive(false);
            menuControls.SetActive(true);
            studioText.SetActive(false);
            InvisBigButton.SetActive(false);
            
        }
    }

    public void MenuBeginButton()
    {
        StartCoroutine(AnimCam());
    }

    public void StartGame()
    {
        StartCoroutine(StartButton());
    }

    public void SeeCredits()
    {
        StartCoroutine(CreditsButton());
    }

    IEnumerator CreditsButton()
    {
        buttonSelect.Play();
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(3);
    }  

    IEnumerator StartButton()
    {
        buttonSelect.Play();
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(4);
    }   

    IEnumerator AnimCam()
    {
        Animator anim = animCam.GetComponent<Animator>();
    if (anim != null)
        anim.Play("AnimMenuCam");
    else
        Debug.LogWarning("Animator missing on animCam!");

        studioText.SetActive(false);
        InvisBigButton.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        fadeIn.SetActive(false);
        mainCam.SetActive(true);
        animCam.SetActive(false);
        menuControls.SetActive(true);
        hasClicked = true;
    }

    IEnumerator FadeInTurnOff()
    {
        yield return new WaitForSeconds(1);
        fadeIn.SetActive(false);
    }

}
