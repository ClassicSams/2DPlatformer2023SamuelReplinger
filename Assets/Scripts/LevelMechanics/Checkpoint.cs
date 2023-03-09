using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    private SpriteRenderer theSR;

    public Sprite cpOn, cpOff;

    public bool isActive;

    // Start is called before the first frame update
    void Start()
    {
        theSR = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && theSR.sprite == cpOff)
        {
            CheckpointController.sharedInstance.DeactivateCheckpoints();
            theSR.sprite = cpOn;
            AudioManager.sharedInstance.PlaySFX(11);         
            CheckpointController.sharedInstance.SetSpawnPoint(transform.position);
        }
    }
    public void ResetCheckpoint()
    {
        theSR.sprite = cpOff;
    }
}
