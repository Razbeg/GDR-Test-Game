using UnityEngine;


[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
public class PlayerCollector : MonoBehaviour
{
    public int CoinsCollected => coinsCollected;
    [SerializeField] private int coinsCollected = 0;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            coinsCollected++;
            collision.gameObject.SetActive(false);
            UIControiller.SetCoinsText(coinsCollected);

            if (GameController.IsAllCoinsCollected(coinsCollected))
                GameController.Win();
        }

        if (collision.CompareTag("Spike"))
            Die();
    }


    private void Die()
    {
        GameController.Lose();
        gameObject.SetActive(false);
    }
}
