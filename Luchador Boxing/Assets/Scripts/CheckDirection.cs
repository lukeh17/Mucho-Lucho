using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDirection : MonoBehaviour {

    //raycasts
    public float rayDistance;
    public RaycastHit2D hit;
    public float raycastMaxDistance = 20f;
    public float originOffset = 1f;
    public LayerMask layer;
    public LayerMask ground;

    private bool flipped = false;
    private bool flipped2 = false;

    private void FixedUpdate()
    {
        if (IsGrounded() && !flipped)
        {
            RaycastCheckUpdate(1);
        }

        if (IsGrounded() && !flipped2)
        {
            RaycastCheckUpdate2(-1);
        }
            
    }

    bool IsGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 2.0f;

        //Debug.DrawRay(position, direction, Color.green);
        RaycastHit2D hit2D = Physics2D.Raycast(position, direction, distance, ground);
        if (hit2D.collider != null)
        {
            return true;
        }

        return false;
    }

    private bool RaycastCheckUpdate(int x)
    {
        while (isActiveAndEnabled)
        {
            Vector2 direction = new Vector2(x, 0);
            RaycastHit2D hit = checkRayCast(direction);
           

            if (hit.collider)
            {
                //Debug.Log("Hit " + hit.collider.name + " Should change direction flipped");
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                flipped = true;
                flipped2 = false;
                return true;
            }

            if (!hit.collider)
            {
                
                return false;
            }

        }
        return false;
    }

    private bool RaycastCheckUpdate2(int x)
    {
        while (isActiveAndEnabled)
        {
            Vector2 direction = new Vector2(x, 0);
            RaycastHit2D hit = checkRayCast(direction);


            if (hit.collider)
            {
                //Debug.Log("Hit " + hit.collider.name + " Should change direction flipped2 " + hit.collider.tag);
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                flipped = false;
                flipped2 = true;
                return true;
            }

            if (!hit.collider)
            {

                return false;
            }

        }
        return false;
    }

    private RaycastHit2D checkRayCast(Vector2 direction)
    {
        float directionOriginOffset = originOffset * (direction.x > 0 ? 1 : -1);

        Vector2 startingPos = new Vector2(transform.position.x + directionOriginOffset, transform.position.y);

        Debug.DrawRay(startingPos, direction, Color.magenta);
        return Physics2D.Raycast(startingPos, direction, raycastMaxDistance, 1 << layer);
    }
}
