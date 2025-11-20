using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Playables;
public class TriggeTimeline : MonoBehaviour
{
    public GameObject angler;
    public PlayableDirector timelineDirector;
    void Start()
    {
        timelineDirector.stopped += OnTimelineStopped;
    }
    private void OnTimelineStopped(PlayableDirector director)
    {

        angler.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            angler.SetActive(true);
            timelineDirector.Play();
            StartCoroutine(ResetTriggerAfterTimeline());
        }
    }

    private IEnumerator ResetTriggerAfterTimeline()
    {
        yield return new WaitForSeconds((float)timelineDirector.duration);
        GetComponent<Collider>().enabled = true;
    }
}
