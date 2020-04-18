using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CoinController : MonoBehaviour
{
    #region
    public int _value = 1;
    public float _cooldownTime = 2f;
    private bool _isOnCooldown = false;
    #endregion

    // TODO - 1. add audio 
    //        2. add score script
    // On trigger handler.
    void OnTriggerEnter2D(Collider2D col)
    {

        // On trigger event with player.
        if (col.gameObject == PlayerLogic.Instance.gameObject && !_isOnCooldown)
        {
            CoinsText.Coins = CoinsText.Coins + _value;
            _isOnCooldown = true;
            Destroy(gameObject);
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(_cooldownTime);
        _isOnCooldown = false;
    }
}
