using UnityEngine;

public class Rock : Weapon
{
    
    public Rigidbody2D rb;    // แสดงใน Inspector เพื่อเชื่อม Rigidbody2D จาก Unity
    public Vector2 force;     // กำหนดแรงที่จะใช้ในการขว้างหิน

    public override void Move()
    {
        // ใช้ฟิสิกส์ใน Unity เพื่อเพิ่มแรงขว้างหิน
        rb.AddForce(force);
    }

    public override void OnHitWith(Character obj)
    {
        
        if (obj is Player)
        {
            obj.TakeDamage(this.damage);
            Destroy(gameObject);
        }
            
    }

    void Start()
    {
        damage = 40;
        force = new Vector2(GetShootDirection() * 90, 400);
        Move(); 
    }

}
