using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerAI : MonoBehaviour
{

    public LayerMask collisionMask;
    public LayerMask collisionHoriz;
    public static ControllerAI colAI;

    const float skinWidth = .015f;
    public int horizontalRayCount = 4;
    public int verticalRayCount = 4;

    float horizontalRaySpacing;
    float verticalRaySpacing;

    public CapsuleCollider2D Collider;
    RaycastOrigins raycastOrigins;
    public CollisionInfo collisions;

    void Awake()
    {
        if (colAI == null)
        {
            colAI = this;
        }
    }

    void Start()
    {
        //Collider = GetComponent<BoxCollider2D>();
        CalculateRaySpacing();
    }

    void VerticalCollisions(ref Vector3 velocity)
    {
        float directionY = Mathf.Sign(velocity.y);
        float rayLength = Mathf.Abs(velocity.y) + skinWidth;

        for (int i = 0; i < verticalRayCount; i++)
        {
            Vector2 rayOrigin = (directionY == -1) ? raycastOrigins.bottomLeft : raycastOrigins.topLeft;
            rayOrigin += Vector2.right * (verticalRaySpacing * i + velocity.x);
            RaycastHit2D hit2D = Physics2D.Raycast(rayOrigin, Vector2.up * directionY, rayLength, collisionMask | collisionHoriz);

            //Debug.DrawRay(rayOrigin, Vector2.up * directionY * rayLength, Color.red);

            if (hit2D)
            {
                velocity.y = (hit2D.distance - skinWidth) * directionY;
                rayLength = hit2D.distance;

                collisions.below = directionY == -1;
                collisions.above = directionY == 1;
            }
        }

    }

    void HorizontalCollisions(ref Vector3 velocity)
    {
        float directionX = Mathf.Sign(velocity.x);
        float rayLength = Mathf.Abs(velocity.x) + skinWidth;

        for (int i = 0; i < horizontalRayCount; i++)
        {
            Vector2 rayOrigin = (directionX == -1) ? raycastOrigins.bottomLeft : raycastOrigins.bottomRight;
            rayOrigin += Vector2.up * (horizontalRaySpacing * i);
            RaycastHit2D hit2D = Physics2D.Raycast(rayOrigin, Vector2.right * directionX, rayLength, collisionHoriz);

            //Debug.DrawRay(rayOrigin, Vector2.right * directionX * rayLength, Color.red);

            if (hit2D)
            {
                velocity.x = (hit2D.distance - skinWidth) * directionX;
                rayLength = hit2D.distance;

                collisions.left = directionX == -1;
                collisions.right = directionX == 1;
            }
        }

    }

    /* public void Move(Vector3 velocity)
     {
         collisions.Reset();
         UpdateRaycastOrigins();
         if (velocity.y != 0)
             VerticalCollisions(ref velocity);
         if (velocity.x != 0)
             HorizontalCollisions(ref velocity);

         transform.Translate(velocity);

     }*/


    void UpdateRaycastOrigins()
    {
        Bounds bounds = Collider.bounds;
        bounds.Expand(skinWidth * -2);

        raycastOrigins.bottomLeft = new Vector2(bounds.min.x, bounds.min.y);
        raycastOrigins.bottomRight = new Vector2(bounds.max.x, bounds.min.y);
        raycastOrigins.topLeft = new Vector2(bounds.min.x, bounds.max.y);
        raycastOrigins.topRight = new Vector2(bounds.max.x, bounds.max.y);
    }

    private void CalculateRaySpacing()
    {
        Bounds bounds = Collider.bounds;
        bounds.Expand(skinWidth * -2);

        horizontalRayCount = Mathf.Clamp(horizontalRayCount, 2, int.MaxValue);
        verticalRayCount = Mathf.Clamp(verticalRayCount, 2, int.MaxValue);

        horizontalRaySpacing = bounds.size.y / (horizontalRayCount - 1);
        verticalRaySpacing = bounds.size.x / (verticalRayCount - 1);
    }

    struct RaycastOrigins
    {
        public Vector2 topLeft, topRight;
        public Vector2 bottomLeft, bottomRight;

    }

    public struct CollisionInfo
    {
        public bool above, below;
        public bool left, right;

        public void Reset()
        {
            above = below = false;
            left = right = false;
        }
    }

}
