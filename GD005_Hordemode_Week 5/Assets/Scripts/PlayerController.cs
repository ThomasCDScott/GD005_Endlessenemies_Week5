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
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Powerup"))
        {
            hasPowerUp = true;
            StartCoroutine(PowerupCountdownRoutine());
            Destroy(other.gameObject);

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
