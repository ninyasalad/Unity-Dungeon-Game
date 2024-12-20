using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// abstract means this class can only be inherented, and cannot be used.
public abstract class Mover : Fighter
{
    protected BoxCollider2D boxCollider;
    protected Vector3 moveDelta;
    protected RaycastHit2D hit;
    protected float ySpeed = 0.75f;
    protected float xSpeed = 1.0f;

    protected virtual void Start()
    {
        // This function runs at the begin of the game.Run once, "Start" is the same function as "Awake"
        boxCollider = GetComponent<BoxCollider2D>();
    }

    protected virtual void UpdateMotor(Vector3 input)
    {
        // Reset moveDelta
        moveDelta = new Vector3(input.x * xSpeed, input.y * ySpeed, 0);

        // Swap sprite direction, wether you're going to right or left (Sprite = element)
        if (moveDelta.x > 0)
            transform.localScale = Vector3.one;
        else if (moveDelta.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        // Make sure we can move in this direction , by casting a box there first, if the  box return null, we're free to move.
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Human", "Blocking"));
        if (hit.collider == null)
        {
            //Make sprite moves
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Human", "Blocking"));
        if (hit.collider == null)
        {
            //Make sprite moves
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }
    }
}
