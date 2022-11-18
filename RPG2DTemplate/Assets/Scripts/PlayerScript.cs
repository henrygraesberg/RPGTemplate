using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private int playerHealth = 100;
    private float playerHealthPercentage = 1f;
    private float maxPlayerHealth;

    [SerializeField] private int playerLevel = 1;
    [SerializeField] private int playerXP = 0;
    [SerializeField] private float[] requriedXP = new float[99 /*Max level == requiredXP.length*/];
    private float nextLevelXP;
    private float playerXPPercentage = 1f;

    void Start()
    {
        maxPlayerHealth = playerHealth;

        DisplayPlayerHealth(); DisplayPlayerXP();
    }

    void Update()
    {
        
    }

    private void UpdateLevelRequirements()
    {
        requriedXP[0] = 250;

        for(int i = 1; i < 5; i++)
        {
            requriedXP[i] = requriedXP[i - 1] * 2;

            Debug.Log(requriedXP[i]);
        }

        for(int i = 5; i < 15; i++)
        {
            requriedXP[i] = requriedXP[i - 1] * 1.2f;

            Debug.Log(requriedXP[i]);
        }

        for(int i = 15; i < 50; i++)
        {
            requriedXP[i] = requriedXP[i - 1] * 1.05f;

            Debug.Log(requriedXP[i]);
        }

        for(int i = 50; i < requriedXP.Length; i++)
        {
            requriedXP[i] = requriedXP[i - 1] * 1.02f;

            Debug.Log(requriedXP[i]);
        }

        nextLevelXP = requriedXP[playerLevel - 1];
    }

    public int GetPlayerHealth => playerHealth;

    public void ReducePlayerHealth(int damageTaken)
    { 
        playerHealth -= damageTaken;

        DisplayPlayerHealth();
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
            playerXP += x - ((int)System.Math.Round(requriedXP[playerLevel - 2]) - oldXP);

            nextLevelXP = requriedXP[playerLevel - 1];
        }

        DisplayPlayerXP();
    }

    public void DisplayPlayerHealth() 
    {
        GameManager.instance.playerHPText.GetComponent<TextMeshProUGUI>().text = $"HP: {playerHealth}";

        playerHealthPercentage = playerHealth / maxPlayerHealth;

        Debug.Log(playerHealthPercentage);

        RectTransform HPBarRect = GameManager.instance.playerHPBar.GetComponent<RectTransform>();

        HPBarRect.localScale = new Vector2(playerHealthPercentage, HPBarRect.localScale.y);
    }

    public void DisplayPlayerXP() 
    {
        GameManager.instance.playerXPText.GetComponent<TextMeshProUGUI>().text = $"XP: {playerXP}/{nextLevelXP}";

        playerXPPercentage = playerXP / nextLevelXP;

        RectTransform XPBarRect = GameManager.instance.playerXPBar.GetComponent<RectTransform>();

        XPBarRect.localScale = new Vector2(playerXPPercentage, XPBarRect.localScale.y);
    }

    private void PlayerDeath()
    {
        //do playerDeath
    }
}
