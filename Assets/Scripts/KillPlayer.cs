using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{

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
        PlayerHealthController.sharedInstance.currentHealth = 0;
        LevelManager.sharedInstance.RespawnPlayer();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealthController.sharedInstance.currentHealth = 0;
            UIController.sharedInstance.UpdateHealthDisplay();
            LevelManager.sharedInstance.RespawnPlayer();
        }
    }
}
