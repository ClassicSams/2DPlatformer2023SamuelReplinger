using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public int currentHealth, maxHealth;

    public float invincibleLenght;
    private float invincibleCounter;

    private SpriteRenderer theSR;
    public GameObject death;


    public static PlayerHealthController sharedInstance;

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
        currentHealth = maxHealth;
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (invincibleCounter > 0)
        {
            invincibleCounter -= Time.deltaTime;

            if (invincibleCounter <= 0)
            {
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, 1f);
            }
        }
    }


    public void DealWithDamage()
    {
        if (invincibleCounter <= 0)
        {
            currentHealth--; // currentHealth -= 1; currentHealth = currentHealth - 1;

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                //gameObject.SetActive(false);
                Instantiate(death, transform.position, transform.rotation);
                AudioManager.sharedInstance.PlaySFX(8);
                LevelManager.sharedInstance.RespawnPlayer();
            }
            else
            {
                invincibleCounter = invincibleLenght;
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, .5f);
                AudioManager.sharedInstance.PlaySFX(10);
                PlayerController.sharedInstance.KnockBack();

            }


        }
        UIController.sharedInstance.UpdateHealthDisplay();

        
    }
    public void HealPlayer()
    {
        currentHealth++;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        UIController.sharedInstance.UpdateHealthDisplay();
    }



}
