using UnityEngine;

public class Ant : Enemy
{

    public Vector2 velocity;
    public Transform[] movePoints;
    
    void Start()
    {
        base.Initialize(20);
        DamageHit = 20;

        velocity = new Vector2(-1.0f, 0.0f);
    }

    public override void Behavior()
    {
        
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        
        if (velocity.x < 0 && rb.position.x <= movePoints[0].position.x)
        {
            Flip();
        }
        
        if (velocity.x > 0 && rb.position.x >= movePoints[1].position.x)
        {
            Flip();
        }
    }

    public void Flip()
    {
        velocity.x *= -1; //change direction of movement
                          //Flip the image
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void FixedUpdate()
    {
        Behavior();
    }

}
