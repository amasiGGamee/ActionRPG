using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject Sphere;
    public GameObject Cube;
    public float Speed;
   

    // Update is called once per frame
    void Update()
    {
        Sphere.transform.position = Vector3.MoveTowards(Sphere.transform.position, Cube.transform.position, Speed * Time.deltaTime);
    }
}
