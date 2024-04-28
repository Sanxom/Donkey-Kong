using UnityEngine;

public class Barrel : MonoBehaviour
{
    public float speed = 1;

    private Rigidbody2D _barrelRigidbody;

    private void Awake()
    {
        _barrelRigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            _barrelRigidbody.AddForce(collision.transform.right * speed, ForceMode2D.Impulse);
        }
    }
}