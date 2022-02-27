using UnityEngine;

public class Gem : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D gem_rb;

    [SerializeField]
    private BoxCollider2D gem_bc;

    [SerializeField]
    private float gem_push_force = 6f;

    public void PushGem()
    {
        gem_bc.enabled = false;

        gem_rb.bodyType = RigidbodyType2D.Dynamic;
        gem_rb.AddForce(Vector2.up * gem_push_force, ForceMode2D.Impulse);
    }
}
