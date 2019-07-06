using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [System.Serializable]
    public class PlayerStats
    {
        public int maxHealth = 100;

        private int _currentHealth;
        public int currentHealth
        {
            get { return _currentHealth; }
            set { _currentHealth = Mathf.Clamp(value, 0, maxHealth); }
        }

        public void Init()
        {
            currentHealth = maxHealth;
        }
    }

    public PlayerStats playerStats = new PlayerStats();

    public int fallBoundry = -20;

    [SerializeField]
    private StatusIndicator sI;

    void Start()
    {
        playerStats.Init();

        if (sI == null)
        {
            Debug.LogError("No Status indicator on the player");
        }
        else
        {
            sI.SetHealth(playerStats.currentHealth, playerStats.maxHealth);
        }
    }

    void Update()
    {
        if (transform.position.y <= fallBoundry)
        {
            DamagePlayer(9999);
        }
    }

    public void DamagePlayer(int damage)
    {
        playerStats.currentHealth -= damage;
        if (playerStats.currentHealth <= 0)
        {
            GameMaster.KillPlayer(this);
        }

        sI.SetHealth(playerStats.currentHealth, playerStats.maxHealth);
    }
}
