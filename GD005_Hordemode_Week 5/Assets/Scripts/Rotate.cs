using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Transform Player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(Player.position, Vector3.up, 50 * Time.deltaTime);
    }
}
