using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{

    public float waitToRespawn;

    public int gemCollected;

    public string levelToLoad;

    public static LevelManager sharedInstance;

    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RespawnPlayer()
    {
        StartCoroutine(RespawnPlayerCo());
    }

    //CORRUTINA PARA MOMENTOS EN LOS QUE VAMOS A TRABAJAR CON UNAS COSAS DE UN MOMENTO EN ESPECÍFICO
    public IEnumerator RespawnPlayerCo()
    {
        PlayerController.sharedInstance.gameObject.SetActive(false);
        yield return new WaitForSeconds(waitToRespawn);
        UIController.sharedInstance.FadeToBlack();
        yield return new WaitForSeconds(waitToRespawn);
        UIController.sharedInstance.FadeFromBlack();
        PlayerController.sharedInstance.gameObject.SetActive(true);
        PlayerController.sharedInstance.transform.position = CheckpointController.sharedInstance.spawnPoint;
        PlayerHealthController.sharedInstance.currentHealth = PlayerHealthController.sharedInstance.maxHealth;
        UIController.sharedInstance.UpdateHealthDisplay();
    }

    
    public void ExitLevel()
    {
        StartCoroutine(ExitLevelCo());
    }
    
    
    //Corrutina de terminar un nivel
    private IEnumerator ExitLevelCo()
    {
        //paramos inputs del jugador
        PlayerController.sharedInstance.stopInput = true;
        //Paramos el movimiento del jugador
        PlayerController.sharedInstance.StopPlayer();
        //
        AudioManager.sharedInstance.bgm.Stop();
        //reproducimos la musica
        AudioManager.sharedInstance.levelEndMusic.Play();
        //Cartel nivel final
        UIController.sharedInstance.levelCompleteText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        UIController.sharedInstance.FadeToBlack();
        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene(levelToLoad);

    }


}
