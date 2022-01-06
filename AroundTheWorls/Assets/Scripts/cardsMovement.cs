using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardsMovement : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 180f;

    private void Update()
    {
        transform.eulerAngles += new Vector3(0f, rotationSpeed * Time.deltaTime, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Car")
        {
            var carMovement = other.transform.gameObject.GetComponent<CarMovement>();
            if (!carMovement.IsCrashed())
            {
                AudioManager.PlaySounds("Card");
                gameObject.SetActive(false);
            
                GameManager._instance.cardsScoreCount++;
                GeneralScore._generalCard++;
                PlayerPrefs.SetInt("cardd", GeneralScore._generalCard);
            }
            Debug.Log("Кол-во карт: " + GeneralScore._generalCard);
        }

    }
}
