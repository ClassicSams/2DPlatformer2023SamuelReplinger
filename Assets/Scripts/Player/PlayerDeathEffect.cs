using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathEffect : MonoBehaviour
{

    private SpriteRenderer theDeathEffectSR;
    // Start is called before the first frame update
    void Start()
    {
        theDeathEffectSR = GetComponent<SpriteRenderer>();

        if (PlayerController.sharedInstance.isLeft)
        {
            theDeathEffectSR.flipX = false;
        }
        else if (!PlayerController.sharedInstance.isLeft)
        {
            theDeathEffectSR.flipX = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
