using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

    float speed = .05f;
    Rigidbody2D rb;
    float jumpForce = 4;
    bool onGround = false;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, .2f);
        if (hit.collider != null && (hit.transform.tag == "Ground" || hit.transform.tag == "Platform")) 
        {
            onGround = true;   
        }
        else
        {
            onGround = false;
        }

        float input = Input.GetAxis("Horizontal"); 
	    if(input != 0)
        {
            transform.Translate(input * speed, 0, 0);
        }

        if (Input.GetButtonDown("Jump") && onGround)
        {
            print("Jumping");
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        if (transform.position.y < -2f)
            Reset();
	}

    void Reset()
    {
        transform.position = new Vector3(-15, -1, 0);
        rb.velocity = Vector3.zero;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Platform")
            transform.parent = other.transform;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Platform")
            transform.parent = null;
    }
}
