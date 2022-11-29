using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class qAnim : MonoBehaviour
{

    private IEnumerator Start()
    {
        yield return new WaitUntil(() => GameManager.instance.haComenzado);
        transform.DOScale(Vector3.one, .7f);
        yield return new WaitForSeconds(5);
        transform.DOScale(Vector3.zero, .7f);
    }
}
