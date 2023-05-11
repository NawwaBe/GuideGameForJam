using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float player_horizontal_speed = 4f;
    [SerializeField] private float player_vertical_speed = 4f;

    private bool mode_up;
    private bool mode_down;
    private bool mode_left;
    private bool mode_right;
    private bool mode_move;
    private float x_speed;
    private float y_speed;
    private string player_rotation = string.Empty;

    private Rigidbody2D rb;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        CheckRotation();
        CheckInput();
        CheckAnim();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void CheckInput()
    {
        x_speed = Input.GetAxis("Horizontal");
        y_speed = Input.GetAxis("Vertical");
    }

    private void CheckRotation()
    {
        if (Input.GetAxis("Vertical") != 0)
        {
            if (Input.GetAxis("Vertical") > 0)
            {
                player_rotation = "up";
            }
            if (Input.GetAxis("Vertical") < 0)
            {
                player_rotation = "down";
            }
        }
        else
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                player_rotation = "right";
            }
            if (Input.GetAxis("Horizontal") < 0)
            {
                player_rotation = "left";
            }
        }
    }

    private void CheckAnim()
    {
        if (x_speed != 0 || y_speed != 0)
        {
            mode_move = true;
        }
        else
        {
            mode_move = false;
        }
        
        switch (player_rotation)
        {
            case "up":
                mode_up = true;
                mode_down = false;
                mode_left = false;
                mode_right= false;
                break;
            case "down":
                mode_up = false;
                mode_down = true;
                mode_left = false;
                mode_right = false;
                break;
            case "left":
                mode_up = false;
                mode_down = false;
                mode_left = true;
                mode_right = false;
                break;
            case "right":
                mode_up = false;
                mode_down = false;
                mode_left = false;
                mode_right = true;
                break;
        }

        anim.SetBool("up", mode_up);
        anim.SetBool("down", mode_down);
        anim.SetBool("left", mode_left);
        anim.SetBool("right", mode_right);
        anim.SetBool("on_move", mode_move);
    }

    private void Movement()
    {
        rb.velocity = new Vector2(player_horizontal_speed * x_speed, player_vertical_speed * y_speed);
    }
}
