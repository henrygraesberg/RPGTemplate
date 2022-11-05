using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] int playerHealth = 100;
    [SerializeField] int playerLevel = 1;

    [SerializeField] int playerXP = 55;
    [SerializeField] int[] requriedXP;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public int GetPlayerHealth => playerHealth;

    public void ReducePlayerHealth(int damageTaken)
    { 
        playerHealth -= damageTaken;

        GameManager.instance.playerHPText.GetComponent<TextMeshProUGUI>().text = $"HP: {playerHealth}";

        
    }

    public int GetPlayerLevel => playerLevel;

    public void AddPlayerXP(int x) 
    {
        int oldXP = playerXP;

        playerXP += x;

        if(playerXP >= requriedXP[playerLevel])
        {
            playerLevel++;
            
            playerXP = 0;
            playerXP += x - (requriedXP[playerLevel - 1] - oldXP);
        }

        
    }

    private void PlayerDeath()
    {
        //do playerDeath
    }
}
