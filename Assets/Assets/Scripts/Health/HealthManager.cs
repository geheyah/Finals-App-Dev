using Kino;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [Header("Game Manager Script")]
    [SerializeField] GameManager gameManager;
    public static int health = 5;

    [Header("Glitch Effect")]
    [SerializeField] DigitalGlitch digitalGlitch;

    [SerializeField] private Image[] hearts;

    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;

    private void Update()
    {
        foreach(Image heartImg in hearts)
        {
            heartImg.sprite = emptyHeart;
        }

        for(int i = 0; i < health; i++)
        {
            hearts[i].sprite = fullHeart;
        }

        PlayerTakingDMG();
    }

    private void PlayerTakingDMG()
    {
        if(health <= 0)
        {
            digitalGlitch.intensity = 0.5f;
            gameManager.EndGame();
        }
    }
}
