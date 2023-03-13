using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{

    public string levelScene;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadLevelSelect());
        AudioManager.sharedInstance.bgm.Stop();
        AudioManager.sharedInstance.PlaySFX(12);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator LoadLevelSelect()
    {
        yield return new WaitForSeconds(5);
        UIController.sharedInstance.FadeToBlack();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(levelScene);

    }



}
