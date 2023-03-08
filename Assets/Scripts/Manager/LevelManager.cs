using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public float waitToRespawn;

    public int gemCollected;

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
        PlayerController.sharedInstance.gameObject.SetActive(true);
        PlayerController.sharedInstance.transform.position = CheckpointController.sharedInstance.spawnPoint;
        PlayerHealthController.sharedInstance.currentHealth = PlayerHealthController.sharedInstance.maxHealth;
        UIController.sharedInstance.UpdateHealthDisplay();
    }
}
