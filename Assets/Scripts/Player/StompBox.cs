using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompBox : MonoBehaviour
{
    public GameObject collective;
    [Range(0, 100)] public float chanceToDrop;


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
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Hit Enemy");
            collision.gameObject.GetComponent<EnemyDeath>().EnemyDeathController();
            PlayerController.sharedInstance.Bounce();

            float dropSelect = Random.Range(0, 100f);
            if (dropSelect <= chanceToDrop)
            {
                Instantiate(collective, collision.transform.position, collision.transform.rotation);
            }
        }
    }

}
