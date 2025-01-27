using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TryAgain()
    {
        SceneManager.LoadScene("Main");
        Movement.ifAllowedToMove = true;
        OpenChestAnim.startParticles = false;
    }
}
