using UnityEngine;

public class OpenChestAnim : MonoBehaviour
{

    private Animator anim;
    public static bool startParticles;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "Player")
        {
            anim.SetBool("IsOpened", true);
            startParticles = true;
        }
    }

    private void OnTriggerExit2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "Player")
        {
            anim.SetBool("IsOpened", false);
            startParticles = false;
        }
    }
}
