using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject coinPrefab;
    public GameObject[] coinObjects;
    public DeathScript deathRespawn;
    private void Start()
    {
        coinObjects = GameObject.FindGameObjectsWithTag("Coin");
    }
    private void Update()
    {
        RespawnPlayer();
    }
    public void RespawnPlayer()
    {
        if (deathRespawn.respawnCoins == true)
        {
            foreach (GameObject coin in coinObjects)
            {
                coin.SetActive(true);
            }
            deathRespawn.respawnCoins = false;
        }
    }

}
