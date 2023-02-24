using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Transform farBackground, middleBackground;

    private float lastXPos;
    private float lastYPos;
    public float minHeight, maxHeight;

    // Start is called before the first frame update
    void Start()
    {
        lastXPos = transform.position.x;
        lastYPos = transform.position.y;
    }

    // Update is called once per frame los LateUpdate se hacen despues de todos los updates, evitando problemas de tirones de la camara
    void LateUpdate()
    {
        //transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
        //float clampedY = Mathf.Clamp(transform.position.y, minHeight, maxHeight);
        //Actualizamos el movimiento de la  cámara usando las restricciones 
        //transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);

        transform.position = new Vector3(target.position.y, Mathf.Clamp(target.position.x, minHeight, maxHeight), transform.position.z);

        transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y, minHeight, maxHeight), transform.position.z);

        float amountToMoveY = transform.position.y - lastYPos; 

        float amountToMoveX = transform.position.x - lastXPos;

        farBackground.position = farBackground.position + new Vector3(amountToMoveY, 0f, 0f);
        middleBackground.position += new Vector3(0f, amountToMoveY *  0.5f, 0f);


        farBackground.position = farBackground.position + new Vector3(amountToMoveX, 0f, 0f);
        middleBackground.position += new Vector3(amountToMoveX * .5f, 0f,0f);

        lastYPos = transform.position.y;
        lastXPos = transform.position.x;
    }
}
