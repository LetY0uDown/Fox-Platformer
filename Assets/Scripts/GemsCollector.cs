using UnityEngine;
using TMPro;

public class GemsCollector : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI gemsText;

    private int gems = 0;

    private void Start()
    {
        gemsText.text = $"Gems: {gems}";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gem"))
        {            
            gems++;
            gemsText.text = $"Gems: {gems}";

            var gem = collision.gameObject.GetComponent<Gem>();

            gem.PushGem();

            Destroy(collision.gameObject, 3f);
        }
    }
}
