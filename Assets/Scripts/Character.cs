using UnityEngine;

public abstract class Character : MonoBehaviour
{

    private int health;

    public int Health
    {
        get => health;
        set
        {
            health = (value < 0) ? 0 : value;
            UpdateHealthBar(); // ✅ เรียกอัพเดตทุกครั้งที่เปลี่ยนค่า Health
        }
    }

    protected Animator anim;
    protected Rigidbody2D rb;

    [SerializeField] private HealthBar healthBarPrefab; // ✅ ใส่ Prefab ของ HealthBar จาก Inspector
    private HealthBar healthBarInstance;

    public void Initialize(int startHealth)
    {
        Health = startHealth;
        Debug.Log($"{this.name} is initialed Health : {this.Health}");

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

    public void TakeDamage (int damage)
    {
        Health -= damage;
        Debug.Log($"{this.name} take damage {damage}. current Heath : {Health}");

        IsDead();
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

    void Start()
    {
        
    }


    private void UpdateHealthBar()
    {
        if (healthBarInstance != null)
            healthBarInstance.UpdateHealthBar(Health, 100); // สมมติ MaxHealth = 100
    }
}
