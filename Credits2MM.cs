using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Credits2MM : MonoBehaviour
{
    [SerializeField] GameObject fadeOut;
    [SerializeField] AudioSource buttonSelect;

    public void ReturnToMainMenu()
    {
        StartCoroutine(MMButton());
    }

    IEnumerator MMButton()
    {
        buttonSelect.Play();
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0);
    }   

}
