using UnityEngine;

public class OrangeLightAnimController : MonoBehaviour
{
    private Animator anim;
    
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayOrangeLightBreakDown()
    {
        anim.Play("MiniLightStoneOrangeBreakDown");
    }
}
