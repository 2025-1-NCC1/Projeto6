using UnityEngine;

public class Moviment : MonoBehaviour
{

    float MovX;
    float MovY;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovX = Input.GetAxisRaw("Vertical");
        MovY = Input.GetAxisRaw("Horizontal");
        if (transform.position.x > -1000 && transform.position.x < 1000 && transform.position.z > -1000 && transform.position.z < 1000)
        {
            transform.Translate(MovX, 0, -MovY);
        }
    }
}
