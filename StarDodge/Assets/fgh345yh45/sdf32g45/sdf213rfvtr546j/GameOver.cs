using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    public int continuePrice;

    public RocketController rocketController;
    public GameObject menu;
    public TextMeshProUGUI priceText;
    public Animation notEnough;
    public LevelLoader levelLoader;
    [HideInInspector]
    public bool crashed;

    public static GameOver instance;

    private Animation anim;

    void Start()
    {
        instance = this;
        anim = this.GetComponent<Animation>();
        priceText.text = continuePrice.ToString();
        crashed = false;
    }
    public void Crashed()
    {
       
        crashed = true;
        rocketController.Crashed();
        anim.Play("Game-Over-In");
        menu.SetActive(false);
    }

    public void Continue()
    {
        if(Wallet.GetAmount() >= continuePrice)
        {
            Wallet.SetAmount(Wallet.GetAmount() - continuePrice);
            Score_SAD.continueGame = true;
            levelLoader.LoadLevel(1);
        }
        else
        {
            notEnough.Play("Not-Enough-In");
        }
    }
}
