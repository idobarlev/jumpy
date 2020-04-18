using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftRB : MonoBehaviour
{
    #region DM
    public float speed = 4.0f;
    public float speedIncreasingFactor = 1.02f;  // how much to inc speed.
    public float speedIncreasingTime = 6f;      // when to inc speed.
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    #endregion

    // Use this for initialization
    void Start()
    {
        // Increase rb object speed.
        if (speedIncreasingFactor != 0)
        {
            speed = (speed * Mathf.Pow(speedIncreasingFactor, (int)(Time.time / speedIncreasingTime)));
        }
       
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);
        //rb.velocity = new Vector2(-12, 0);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -screenBounds.x * 2)
        {
            Destroy(this.gameObject);
        }
    }
}
