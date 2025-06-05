using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] float speed;
    public Transform focalPoint;

    public bool hasPowerUp;
    public float powerupStrength = 15.0f;
    public GameObject PowerupIndicator;
    private Vector3 startPosition;
    public int lives = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {

        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 moveDirection = new Vector2(horizontalInput, verticalInput).normalized;
        focalPoint.position = transform.position;
        rb.AddForce((focalPoint.forward * moveDirection.y) + (focalPoint.right * moveDirection.x) * speed);
        PowerupIndicator.SetActive(true);

        PowerupIndicator.SetActive(hasPowerUp);
        PowerupIndicator.transform.position = transform.position;

        if(transform.position.y <-3)
        {
            transform.position = startPosition;
            rb.linearVelocity = Vector3.zero;
            lives--;
        }

        if (lives<= 0)
        {

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Powerup"))
        {
            hasPowerUp = true;
            StartCoroutine(PowerupCountdownRoutine());
            Destroy(other.gameObject);

        }

        if (other.CompareTag("Potion"))
        {
            Destroy(other.gameObject);
            lives++;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {   //this gives us access to make a power up that would push enemies away.
        if (collision.gameObject.CompareTag("Enemies") && hasPowerUp)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.transform.position - transform.position.normalized);
            enemyRb.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);

            Debug.Log("The player has collided with" + collision.gameObject.name);
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(5);
        hasPowerUp = false;
    }
}
