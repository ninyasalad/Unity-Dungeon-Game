using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    // Public Fields
    public int hitpoint = 10;
    public int maxHitpoint = 10;
    public float knockBackRecoverySpeed = 0.2f;

    // Immunity
    protected float immuneTime = 1f;
    protected float lastImmune;

    // KnockBack
    protected Vector3 knockBackDirection;

    // All Fighters can ReceiveDamage/Die
    protected virtual void ReceiveDamage(Damage dmg)
    {
        if (Time.time - lastImmune > immuneTime)
        {
            lastImmune = Time.time;
            hitpoint -= dmg.damageAmount;
            knockBackDirection = (transform.position - dmg.origin).normalized * dmg.knockBack;

            GameManager.instance.ShowText(dmg.damageAmount.ToString(), 25, Color.red, transform.position, Vector3.zero, 0.5f);

            if (hitpoint <= 0)
            {
                hitpoint = 0;
                Death();
            }
        }
    }

    protected virtual void Death()
    {

    }
}
