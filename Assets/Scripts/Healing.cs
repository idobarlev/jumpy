﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour
{
    #region DM
    public int _heal = 10;
    public float _cooldownTime = 2f;
    private bool _isOnCooldown = false;
    #endregion

    // On trigger handler.
    void OnTriggerEnter2D(Collider2D col)
    {

        // On trigger event with player.
        if (col.gameObject == PlayerLogic.Instance.gameObject && !_isOnCooldown)
        {
            PlayerLogic.Instance.TakeDamage(-_heal);
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
