using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    #region DM
    public float _cooldownTime = 5f;
    private bool _isOnCooldown = false;
    #endregion

    // On trigger handler.
    void OnTriggerEnter2D(Collider2D col) {

        // On trigger event with player.
        if (col.gameObject == PlayerLogic.Instance.gameObject && !_isOnCooldown) {
            GameManager.Instance.GameOver();
            _isOnCooldown = true;
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Cooldown() {
        yield return new WaitForSeconds(_cooldownTime);
        _isOnCooldown = false;
    }
}
