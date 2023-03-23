using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    public Coin _coin;
    public Transform CoinMakePosition;
    private float _waitingTime = 1;
    private float _moveStep = 2;
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
        WaitForSeconds waitForSeconds = new WaitForSeconds(_waitingTime);

        for (int i = 0; i < CoinCount; i++)
        {
            Instantiate(_coin, CoinMakePosition.position,Quaternion.identity);
            CoinMakePosition.Translate(_moveStep,0,0);
            yield return waitForSeconds;
        }
    } 
}
