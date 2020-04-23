using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class PlayerLogic : MonoSingleton<PlayerLogic>
{
    #region DM
    public int maxHealth;
    public int currentHealth;
    public HealthBar healthBar;
    public bool isPlayerOutBound;
    #endregion

    // Start is called before the first frame update
    void Start() {
        init();
    }

    // Set damage on hp bar & dec on character hp.
    public void TakeDamage(int damage) {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth < 1) {
            GameManager.Instance.GameOver();
        }
    }

    // Init player for game.
    public void init() {
        isPlayerOutBound = false;
        maxHealth = 100;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
}
