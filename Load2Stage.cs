using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load2Stage : MonoBehaviour
{
    [SerializeField] GameObject fadeOut;

    void Start()
    {
        StartCoroutine(LoadLevel());   
    }


    IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(3);
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(2);

        int target = SceneLoader.Instance.targetSceneIndex;

        if (target == 0 || target == 1 || target == 4)
        {
            Debug.LogWarning("Cannot load the target scene: " + target);
            yield break;
        }

        SceneManager.LoadScene(target);
    }
}
