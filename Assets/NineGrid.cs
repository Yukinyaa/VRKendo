using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class NineGrid : MonoBehaviour
{
    public List<AudioClip> counting;
    public List<Destroyable> destoryables;

    bool ended = true;
    IEnumerator DoRandom(int count, float delay)
    {
        for (int i = 0; i < 9; i++)
        {
            destoryables[i].gameObject.SetActive(true);
            destoryables[i].destoryable = false;
        }
        Debug.Assert(count <= 9);
        List<int> shffle = Enumerable.Range(0, 9).ToList();
        shffle.Shuffle();
        AudioSource aso = GetComponent<AudioSource>();
        for (int i = 0; i < count; i++)
        {
            int target = shffle[i];
            aso.clip = counting[target];
            aso.Play();
            yield return new WaitForSeconds(delay);
        }
        Destroyable lastd = null;
        for (int i = 0; i < count; i++)
        {
            int target = shffle[i];
            var d = destoryables[target];
            if (lastd != null)
                d.precursor = lastd;
            else
                d.precursor = null;
            d.destoryable = true;
            lastd = d;
        }
        for (; ; )
        {
            if (lastd.gameObject.activeInHierarchy == false)
                break;
            yield return null;
        }
        ended = true;

    }
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {

        if (ended)
        {
            StartCoroutine(DoRandom(4, 0.6f));
            ended = false;
        }
            

    }
}
