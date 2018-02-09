using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controls : MonoBehaviour {

    public Camera player_cam;
    public bool move_left = false;
    public bool move_right = false;
    public bool move_up = false;
    public bool move_down = false;
    public bool is_jumping = false;

    public float x_pos = 0.0f;
    public float y_pos = 0.0f;
    public float movement_speed = 5.0f;

    // Use this for initialization
    void Start () {
        // if no player cam is linked, then assign default one
		if (!player_cam)
        {
            Camera cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
            setCamera(cam);
        }
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

        moveLeft();
        moveRight();

    }

    public void moveLeft()
    {
        if (move_left)
        {
            Vector2 new_pos = new Vector2(x_pos - 1.0f, y_pos) * movement_speed * Time.deltaTime;
            gameObject.transform.Translate(new_pos);
            player_cam.gameObject.transform.Translate(new_pos);
        }
    }

    public void moveRight()
    {
        if (move_right)
        {
            Vector2 new_pos = new Vector2(x_pos + 1.0f, y_pos) * movement_speed * Time.deltaTime;
            gameObject.transform.Translate(new_pos);
            player_cam.gameObject.transform.Translate(new_pos);
        }
    }

    public void moveUp()
    {

    }

    public void moveDown()
    {

    }

    public void setCamera(Camera cam)
    {
        player_cam = cam;
    }
}
