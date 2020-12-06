using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoorController : MonoBehaviour
{
    private GameObject player;
    private float distance;
    private Animator animator;
    [SerializeField] private GameObject objective;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance < 5 && animator.GetBool("character_nearby") == false && !objective)
        {
            animator.SetBool("character_nearby", true);
        }
        else if (distance >= 5 && animator.GetBool("character_nearby") == true)
        {
            animator.SetBool("character_nearby", false);
        }
    }
}
