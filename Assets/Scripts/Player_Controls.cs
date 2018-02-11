using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controls : MonoBehaviour {

    bool debug = true;

    public Camera player_cam;
    public bool move_left = false;
    public bool move_right = false;
    public bool move_up = false;
    public bool move_down = false;

    public float x_pos = 0.0f;
    public float y_pos = 0.0f;
    public float movement_speed = 5.0f;

    // jumping variables
    public bool is_jumping = false;
    public bool is_falling = true;
    public float jump_y = 0.0f;
    public float max_ground_distance;
    public float prev_height = 0.0f;
    public float curr_height = 0.0f;
    public float max_height_diff;

    // Use this for initialization
    void Start () {
        // if no player cam is linked, then assign default one
		if (!player_cam)
        {
            Camera cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
            setCamera(cam);
        }
        max_ground_distance = 0.1f;
        max_height_diff = 0.001f;
    }
	
	// Update is called once per frame
	void Update () {
        // move left
        if (Input.GetKeyDown(KeyCode.A))
            move_left = true;
        if (Input.GetKeyUp(KeyCode.A))
            move_left = false;

        // move right
        if (Input.GetKeyDown(KeyCode.D))
            move_right = true;
        if (Input.GetKeyUp(KeyCode.D))
            move_right = false;

        // jump up
        if (Input.GetKeyDown(KeyCode.Space))
            is_jumping = true;
        if (Input.GetKeyUp(KeyCode.Space))
            is_jumping = false;

        is_falling = checkIsFalling();
        moveLeft();
        moveRight();
        jumpUp();
    }

    // handles when character lands on something
    private void FixedUpdate()
    {
        if (is_falling)
        {
            Vector2 feet_pos = new Vector2(transform.position.x, transform.position.y - 0.98f);
            RaycastHit2D hit = Physics2D.Raycast(feet_pos, Vector2.down, max_ground_distance);
            if (hit)
            {
                Debug.Log("Hit: " + hit.collider.name + ", distance: " + hit.distance);
                is_falling = false;
            }
        }

    }

    public void moveLeft()
    {
        if (move_left)
        {
            Vector2 new_pos = new Vector2(x_pos - 1.0f, y_pos) * movement_speed * Time.deltaTime;
            gameObject.transform.Translate(new_pos);
        }
    }

    public void moveRight()
    {
        if (move_right)
        {
            Vector2 new_pos = new Vector2(x_pos + 1.0f, y_pos) * movement_speed * Time.deltaTime;
            gameObject.transform.Translate(new_pos);
        }
    }

    public void moveUp()
    {

    }

    public void moveDown()
    {

    }

    public void jumpUp()
    {
        // adjust gravity if jumping
        if (is_jumping)
        {
            is_jumping = false;
            if (!is_falling)
                gameObject.GetComponent<Rigidbody2D>().gravityScale = -30;
        }
        // else, let gravity handle the falling
        else
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
    }

    public void setCamera(Camera cam)
    {
        player_cam = cam;
    }

    public bool checkIsFalling()
    {
        curr_height = transform.position.y;
        float height_diff = Mathf.Abs(curr_height - prev_height);
        if (height_diff <= max_height_diff)
            return false;

        prev_height = curr_height;
        return true;
    }
}
