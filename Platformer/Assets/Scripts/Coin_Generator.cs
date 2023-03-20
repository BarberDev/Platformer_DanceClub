using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Generator : MonoBehaviour
{
    public Coin _coin;

    public Transform CoinMakePosition;

    private int CoinCount = 9;

    private void Start()
    {
        MakeCoins();
    }

    private void MakeCoins() 
    {
        StartCoroutine(CoinSpown());
    }

    IEnumerator CoinSpown() 
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(1);

        for (int i = 0; i < CoinCount; i++)
        {
            Instantiate(_coin, CoinMakePosition.position,Quaternion.identity);
            CoinMakePosition.Translate(2,0,0);
            yield return waitForSeconds;
        }
    } 
}
