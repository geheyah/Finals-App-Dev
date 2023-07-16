using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  

public class HealthScript1 : MonoBehaviour
{
    //when using this method refer to health add "public HealthScript1 health;" on the player script to refer to the health variable
    public GameObject heart1,heart2,heart3;
    public int health = 3;

    void Update() {
        if(health==2){
            Destroy(heart1);
        }
        else if (health==1){
            Destroy(heart2);        
        }
        else if (health==0){
            Destroy(heart3);            
        }
    }
}
