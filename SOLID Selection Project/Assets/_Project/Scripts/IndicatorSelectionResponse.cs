using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorSelectionResponse : MonoBehaviour, ISelectionResponse
{
    [SerializeField] public GameObject block;

    public void OnSelect(Transform selection)
    {
        block.SetActive(true);
        var particle = block.GetComponent<ParticleSystem>();

        if (block != null)
        {
            var height = selection.transform.localScale.y;
            block.transform.position = new Vector3(selection.transform.position.x, height * 2f, selection.transform.position.z);
            var emission = particle.emission;

            emission.enabled = true;
        }


    }

    public void OnDeselect(Transform selection)
    {
        var particle = block.GetComponent<ParticleSystem>();
        if (block != null)
        {
            block.transform.position = selection.transform.position;
            particle.Stop();
            block.SetActive(false);

        }
    }

}
