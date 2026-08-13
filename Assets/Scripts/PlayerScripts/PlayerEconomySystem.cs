using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEconomySystem : MonoBehaviour
{
    private int currentEconomy;
    private int coins = 50 ;

   public void AddCoins(int amount) {
        currentEconomy += coins;
        Debug.Log("Total Coins:"+currentEconomy);
    }
}
