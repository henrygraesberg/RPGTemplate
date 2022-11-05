using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject player;

    public GameObject playerXPText;
    public GameObject playerXPBar;

    public GameObject playerLevelText;

    public GameObject playerHPText;
    public GameObject playerHPBar;
    
    void Start()
    {
        if(instance != null)
        {
            Destroy(this);
        }
        instance = this;
    }
}
