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
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 100;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Set damage on hp bar & dec on character hp.
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
