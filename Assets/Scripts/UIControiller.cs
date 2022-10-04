using TMPro;
using UnityEngine;

public class UIControiller : MonoBehaviour
{
    private static UIControiller instance = null;
    public static UIControiller self
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<UIControiller>();
            return instance;
        }
    }


    [SerializeField] private TextMeshProUGUI startText = null;
    [SerializeField] private TextMeshProUGUI winText = null;
    [SerializeField] private TextMeshProUGUI loseText = null;
    [SerializeField] private TextMeshProUGUI coinsText = null;


    private void Start()
    {
        ToggleStartText(true);
        ToggleSWinText(false);
        ToggleLoseText(false);
        SetCoinsText(0);
    }


    public static void ToggleStartText(bool state) => self.startText.gameObject.SetActive(state);
    public static void ToggleSWinText(bool state) => self.winText.gameObject.SetActive(state);
    public static void ToggleLoseText(bool state) => self.loseText.gameObject.SetActive(state);
    public static void SetCoinsText(int count) => self.coinsText.SetText($"{count}/{GameController.CoinsToCollect}");
}
