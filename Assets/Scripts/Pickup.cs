using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{


    public bool isGem, isHeal;

    private bool isCollected;

    public GameObject pickupEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isCollected)
        {
            if (isGem)
            {
                LevelManager.sharedInstance.gemCollected++;
                isCollected = true;
                UIController.sharedInstance.UpdateGemCount();
                Instantiate(pickupEffect, transform.position, transform.rotation);
                Destroy(gameObject);
            }
           
        }
        if (isHeal)
        {
            if (PlayerHealthController.sharedInstance.currentHealth != PlayerHealthController.sharedInstance.maxHealth)
            {
                PlayerHealthController.sharedInstance.HealPlayer();
                isCollected = true;
                Destroy(gameObject);
            }
        }

    }


}
