using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Meteor : MonoBehaviour
{
    private Transform[] _planetLocations;
    private ParticleSystem _particle;
    private Transform _startTransform;
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _startTransform = transform;
    }
    
    public IEnumerator Fall()
    {
        _rb.isKinematic = false;
        var randomAim = _planetLocations[UnityEngine.Random.Range(0, _planetLocations.Length)];
        yield return new WaitForSeconds(.3f);
        transform.DOJump(randomAim.position, 10f, 10, 2);
        _particle.Play();
        gameObject.SetActive(false);
        transform.position = _startTransform.position;
    }

    private void OnCollisionEnter()
    {
        _particle.Play();
        gameObject.SetActive(false);
        transform.position = _startTransform.position;
        _rb.isKinematic = true;
    }
}

    
    
