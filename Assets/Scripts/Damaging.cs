using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damaging : MonoBehaviour
{
    #region DM
    public int _damage;
    public float _cooldownTime = 1f;
    private bool _isOnCooldown = false;
    #endregion

    // On trigger handler.
    void OnTriggerEnter2D(Collider2D col)
    {

        // On trigger event with player.
        if (col.gameObject == PlayerLogic.Instance.gameObject && !_isOnCooldown)
        {
            PlayerLogic.Instance.TakeDamage(_damage);
            _isOnCooldown = true;
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(_cooldownTime);
        _isOnCooldown = false;
    }
}
