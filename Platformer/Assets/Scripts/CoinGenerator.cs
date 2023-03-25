using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private Transform _coinMakePosition;

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
            Instantiate(_coin, _coinMakePosition.position, Quaternion.identity);
            _coinMakePosition.Translate(_moveStep, 0, 0);
            yield return waitForSeconds;
        }
    }
}
