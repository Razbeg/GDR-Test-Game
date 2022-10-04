using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private static GameController instance = null;
    public static GameController self
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<GameController>();
            return instance;
        }
    }


    public static int CoinsToCollect => self.coinsToCollect;
    [SerializeField] private int coinsToCollect = 1;


    public static bool IsFinished => self.isFinished;
    private bool isFinished = false;


    private void Start() => isFinished = false;

    private void Update()
    {
        if (isFinished && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            Restart();
    }


    public static bool IsAllCoinsCollected(int count) => self.coinsToCollect <= count;

    public static void Win()
    {
        UIControiller.ToggleSWinText(true);
        self.isFinished = true;
    }

    public static void Lose()
    {
        UIControiller.ToggleLoseText(true);
        self.isFinished = true;
    }

    public static void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}
