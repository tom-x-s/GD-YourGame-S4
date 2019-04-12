using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnim : MonoBehaviour
{
    [SerializeField]
    private Animator enemyAnim;

    void Start()
    {
        gameObject.SetActive(false);
    }

    public void PlayAnim()
    {
        gameObject.SetActive(true);
        enemyAnim.SetTrigger("Death");
    }
}
