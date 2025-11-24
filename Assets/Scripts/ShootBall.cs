using UnityEngine;

public class ShootBall : MonoBehaviour
{

    public float CastPower = 500f;
    public Rigidbody2D rb;
    public Vector3 Direction = new Vector3(0, 1, 0);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            rb.AddForce(Direction * CastPower);
        }
    }
}
