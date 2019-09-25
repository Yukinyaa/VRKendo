using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongSaber : MonoBehaviour
{
    public GameObject ls1;
    public GameObject ls2;
    public GameObject ls_long;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("RightHand"))
        {
            ls1.SetActive(false);
            ls2.SetActive(false);
            ls_long.SetActive(true);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("RightHand"))
        {
            ls1.SetActive(true);
            ls2.SetActive(true);
            ls_long.SetActive(false);
        }
    }
}
