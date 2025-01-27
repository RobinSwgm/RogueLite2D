using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform Player;

    Vector3 velocity = Vector3.zero;

    public float smoothTime = .15f;

    private void FixedUpdate()
    {
        Vector3 targetPos = Player.position;

        targetPos.z = transform.position.z;

        transform.position = Vector3.SmoothDamp(transform.position, targetPos , ref velocity, smoothTime);
    }
}
