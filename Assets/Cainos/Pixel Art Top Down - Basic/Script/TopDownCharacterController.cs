using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
    public class TopDownCharacterController : MonoBehaviour
    {
        public float speed;

        private Animator animator;

        float horizontal;
        float vertical;
        Rigidbody2D rigidbody2d;

        Vector2 lookDirection = new Vector2(1, 0);

        private void Start()
        {
            animator = GetComponent<Animator>();

            rigidbody2d = GetComponent<Rigidbody2D>();
        }


        private void Update()
        {

            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");

            Vector2 movement = new Vector2(horizontal, vertical);

            if (!Mathf.Approximately(movement.x, 0.0f) || !Mathf.Approximately(movement.y, 0.0f))
            {
                lookDirection.Set(movement.x, movement.y);
                lookDirection.Normalize();
            }

            Vector2 dir = Vector2.zero;
            if (Input.GetKey(KeyCode.A))
            {
                dir.x = -1;
                animator.SetInteger("Direction", 3);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                dir.x = 1;
                animator.SetInteger("Direction", 2);
            }

            if (Input.GetKey(KeyCode.W))
            {
                dir.y = 1;
                animator.SetInteger("Direction", 1);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                dir.y = -1;
                animator.SetInteger("Direction", 0);
            }

            dir.Normalize();
            animator.SetBool("IsMoving", dir.magnitude > 0);

            GetComponent<Rigidbody2D>().velocity = speed * dir;

            //Code to detect raycast hit and trigger dialog box
            if (Input.GetKeyDown(KeyCode.R))
            {
                RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("NPC"));
                if (hit.collider != null)
                {
                    enemymover character = hit.collider.GetComponent<enemymover>();
                    if (character != null)
                    {
                        character.DisplayDialog();
                    }
                }
            }
        }
    }
}
