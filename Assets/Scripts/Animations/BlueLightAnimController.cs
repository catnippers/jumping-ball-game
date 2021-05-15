using UnityEngine;

public class BlueLightAnimController : MonoBehaviour
{
    private Animator anim;
    
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayBlueLightBreakDown()
    {
        anim.Play("MiniLightStoneBlueBreakDown");
    }
}
