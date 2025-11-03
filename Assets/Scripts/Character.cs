using UnityEngine;
using UnityEngine.UI;

public abstract class Character : MonoBehaviour
{
    private int health;
    private int maxHealth;

    public int Health
    {
        get => health;
        set
        {
            health = (value < 0) ? 0 : value;
            UpdateHealthBar();
        }
    }

    protected Animator anim;
    protected Rigidbody2D rb;

    [SerializeField] private HealthBar healthBarPrefab; 
    private HealthBar healthBarInstance;


    public void Initialize(int startHealth)
    {
        maxHealth = startHealth;
        Health = startHealth;
        Debug.Log($"{this.name} initialized with Health : {this.Health}/{this.maxHealth}");

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        
        if (healthBarPrefab != null)
        {
            var canvas = GameObject.Find("WorldCanvas");
            healthBarInstance = Instantiate(healthBarPrefab, canvas.transform);
            healthBarInstance.SetTarget(this.transform);
            UpdateHealthBar();
        }
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        Debug.Log($"{this.name} take damage {damage}. current Heath : {Health}/{maxHealth}");

        if (IsDead())
        {
            if (healthBarInstance != null)
                Destroy(healthBarInstance.gameObject);
        }
    }

    public bool IsDead()
    {
        if (Health <= 0)
        {
            Destroy(this.gameObject);
            Debug.Log($"{this.name} is dead and destroyed!");
            return true;
        }
        else return false;
    }

    private void UpdateHealthBar()
    {
        if (healthBarInstance != null)
            healthBarInstance.UpdateHealthBar(Health, maxHealth);
    }
}
