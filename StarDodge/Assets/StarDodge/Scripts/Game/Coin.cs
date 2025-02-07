using UnityEngine;

public class Coin : MonoBehaviour
{
    private Animation anim;
    private AudioSource audioSource;
    private bool taken;

    void Start()
    {
        anim = this.GetComponent<Animation>();
        audioSource = this.GetComponent<AudioSource>();
        taken = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(!taken)
        {
            if(col.name == "Front" || col.name == "Back")
            {
                Wallet.SetAmount(Wallet.GetAmount() + 1);
                anim.Play("Coin-Destroy-Down");
                audioSource.Play();
                taken = true;
            }
        }
    }
}
