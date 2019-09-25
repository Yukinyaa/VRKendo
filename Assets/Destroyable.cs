using UnityEngine;
using System.Collections;
/// <summary>
/// 파괴 가능한 오브젝트
/// </summary>
public class Destroyable : MonoBehaviour
{
    /// <summary>
    /// 파괴되기 이전에 파괴되어야 하는 오브젝트
    /// </summary>
    public Destroyable precursor;
    /// <summary>
    /// 폭발 이펙트 프리팹
    /// </summary>
    public GameObject explosion;

    // Use this for initialization
    void Start()
    {
        if (precursor != null)
        {
            GetComponent<LineRenderer>().enabled = true; 
            GetComponent<LineRenderer>().positionCount = 2;
            GetComponent<LineRenderer>().SetPositions(new Vector3[2] { precursor.transform.position, this.transform.position });
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (precursor == null || !precursor.isActiveAndEnabled)
        {
            GetComponent<LineRenderer>().enabled = false;
            GetComponent<Renderer>().material.color = Color.red;
        }
    }
    private void OnCollisionStay (Collision collision)
    {
        if (collision.collider.CompareTag("SaberBlade"))
        {
            Debug.Log((precursor == null || !precursor.isActiveAndEnabled));
            if ((precursor == null || !precursor.isActiveAndEnabled))
            {
                GameObject.Instantiate(explosion, transform.position, Quaternion.identity);
                gameObject.SetActive(false);
            }
        }
    }
}
