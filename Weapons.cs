using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : Collectable
{
    // Damage Struct
    public int damagePoint = 1;
    public float knockBack = 2.0f;

    // Upgrade System
    public int weaponLevel = 0;
    private SpriteRenderer spriteRenderer;

    // Swing
    private float cooldown = 0.5f;
    private float lastSwing;

    // Override from Collectable
    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Override
    protected override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time - lastSwing > cooldown)
            {
                lastSwing = Time.time;
                Swing();
            }
        }
    }

    // Override
    protected override void OnCollide(Collider2D coll)
    {
        // Filter that weapon can only collide on Fighter tag
        if (coll.tag == "Fighter")
        {
            // Filter out the name "Player" in Fighter tag, so the weapon won't hit yourself
            if (coll.name == "Player")
            {
                return;
            }
            // Create a new damage object, then we'll send it to the fighter we've hit
            Damage dmg = new Damage
            {
                damageAmount = damagePoint,
                origin = transform.position,
                knockBack = knockBack,
            };
            coll.SendMessage("ReceiveDamage", dmg);
        }
    }

    private void Swing()
    {
        Debug.Log("Swing");
    }
}
