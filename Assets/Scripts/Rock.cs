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
        // เมื่อหินชนกับ object ประเภท Player ให้สร้างความเสียหาย
        if (obj is Player)
            obj.TakeDamage(this.damage);
    }

    void Start()
    {
        damage = 40;
        force = new Vector2(GetShootDirection() * 90, 400); // แรงแนวนอน + แนวตั้ง
        Move(); // ขว้างหินทันทีที่สร้าง
    }

}
