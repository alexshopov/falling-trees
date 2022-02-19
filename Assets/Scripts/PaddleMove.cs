using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMove : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    public Vector2 movement;
    public GameHandler gameHandlerObj;
    public GameObject hitVfx;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (GameObject.FindWithTag("gameHandler") != null) {
            gameHandlerObj = GameObject.FindWithTag("gameHandler").GetComponent<GameHandler>();
        }
    }

    // Listen for player movement to move the object
    void FixedUpdate()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    // Makes objects with "tree" tag disappear on contact
    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "tree") {
            gameObject.GetComponent<AudioSource>().Play();

            GameObject boomFx = Instantiate(hitVfx, other.gameObject.transform.position, Quaternion.identity);
            StartCoroutine(DestroyVFX(boomFx));

            Destroy(other.gameObject);
            gameHandlerObj.AddScore(1);
        }
    }

    IEnumerator DestroyVFX(GameObject theEffect) {
        yield return new WaitForSeconds(0.5f);
        Destroy(theEffect);

        gameObject.GetComponent<AudioSource>().Stop();
    }
}
