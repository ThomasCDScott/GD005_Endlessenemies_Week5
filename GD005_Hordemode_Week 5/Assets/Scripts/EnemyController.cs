using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField] float speed = 4f;
    Rigidbody enemyRb;
    GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //player.transform.position - transform.position is a formula that follows the player. The way this works is it calculates the position of the player and follows along on the route it needs to take by using certain math.
        //E.G. if it was a vector2 player on (3,3) and enemy on (1,2). Calculation would be (3,3) - (1,2) = (3-1, 3-2) 

        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed);
    }
}
