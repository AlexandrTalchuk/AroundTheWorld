using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollisionDetector : MonoBehaviour
{
    
    private CarMovement _carMovement;
    
    private void Awake() {
        _carMovement = transform.parent.gameObject.GetComponent<CarMovement>();
    }
}
