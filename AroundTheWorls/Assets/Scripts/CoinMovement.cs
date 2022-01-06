using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMovement : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 180f;
    GameManager gameManager;
   
    private void Update() 
    {
        transform.eulerAngles += new Vector3(0f, rotationSpeed * Time.deltaTime, 0f);
        
    }


    private void OnTriggerEnter(Collider other) 
    {        
        if(other.transform.tag == "Car")
        {
            
            var carMovement = other.transform.gameObject.GetComponent<CarMovement>();
           
            if (!carMovement.IsCrashed())
            {
               
                gameObject.SetActive(false);
                AudioManager.PlaySounds("Coin");
                GameManager._instance.scoreCount++;
                GeneralScore._generalScore++;
                PlayerPrefs.SetInt("coinss", GeneralScore._generalScore);

            }
            
            Debug.Log("Общий счёт: " + GeneralScore._generalScore);
            
            

        }

    }


}
