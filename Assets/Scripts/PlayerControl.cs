using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float player_horizontal_speed = 4f;
    [SerializeField] private float player_vertical_speed = 4f;

    [Header("Weapon Points")]
    [SerializeField] private Transform w_point_up;
    [SerializeField] private Transform w_point_down;
    [SerializeField] private Transform w_point_side;
    [SerializeField] private Transform weapon_point;
    [SerializeField] private Transform sword_point;
    [SerializeField] private Transform arba_point;
    [SerializeField] private SpriteRenderer weapon;
    [SerializeField] private SpriteRenderer sword;
    [SerializeField] private SpriteRenderer arba;

    public int x = 1;

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
        if (Input.GetAxis("Horizontal") != 0)
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                player_rotation = "right";
                weapon_point.position = w_point_side.position;
                weapon.sortingOrder = 11;
                sword_point.position = w_point_side.position;
                sword.sortingOrder = 11;
                arba_point.position = w_point_side.position;
                arba.sortingOrder = 11;
            }
            if (Input.GetAxis("Horizontal") < 0)
            {
                player_rotation = "left";
                weapon_point.position = w_point_side.position;
                weapon.sortingOrder = 9;
                sword_point.position = w_point_side.position;
                sword.sortingOrder = 9;
                arba_point.position = w_point_side.position;
                arba.sortingOrder = 9;
            }
        }
        else
        {
            if (Input.GetAxis("Vertical") > 0)
            {
                player_rotation = "up";
                weapon_point.position = w_point_up.position;
                weapon.sortingOrder = 9;
                sword_point.position = w_point_up.position;
                sword.sortingOrder = 9;
                arba_point.position = w_point_up.position;
                arba.sortingOrder = 9;
            }
            if (Input.GetAxis("Vertical") < 0)
            {
                player_rotation = "down";
                weapon_point.position = w_point_down.position;
                weapon.sortingOrder = 11;
                sword_point.position = w_point_down.position;
                sword.sortingOrder = 11;
                arba_point.position = w_point_down.position;
                arba.sortingOrder = 11;
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
        rb.velocity = new Vector2(player_horizontal_speed * x_speed * x, player_vertical_speed * y_speed* x);
    }
}
