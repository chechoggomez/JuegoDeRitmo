using UnityEngine;
using System.Collections;

public class shake : MonoBehaviour
{

    private Vector3 _originalPos;


    void Awake()
    {
        _originalPos = transform.localPosition;

       
    }

    public void Shake(float duration, float amount)
    {
        StopAllCoroutines();
        StartCoroutine(cShake(duration, amount));
    }

    public IEnumerator cShake(float duration, float amount)
    {
        float endTime = Time.time + duration;

        while (Time.time < endTime)
        {
            transform.localPosition = _originalPos + Random.insideUnitSphere * amount;

            duration -= Time.deltaTime;

            yield return null;
        }

        transform.localPosition = _originalPos;
    }
}