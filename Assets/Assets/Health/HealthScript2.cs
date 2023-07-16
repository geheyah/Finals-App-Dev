using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  

public class HealthScript2 : MonoBehaviour
{
    //when using this method refer to health add "public HealthScript2 health;" on the player script to refer to the health variable
    
    public int health = 3;
    public int maxhealth = 3;

    public Image Health;

    void Update() {
         Health.fillAmount = health / maxhealth;       
    }

}
