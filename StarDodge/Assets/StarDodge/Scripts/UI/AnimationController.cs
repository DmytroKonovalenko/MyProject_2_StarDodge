using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animation anim;

    void Start()
    {
        anim = this.GetComponent<Animation>();
    }
    
    public void PlayIdle()
    {
        anim.Play(anim.name + "-Idle");
    }
    public void OpenWindow()
    {
        anim.Play("Window-In");
    }
    public void CloseWindow()
    {
        anim.Play("Window-Out");        
    }
}
