using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialObject : MonoBehaviour
{
   public Transform parentCelestial;
   public float speed;
   public float selfSpeed;
   private int _years,_days;
   public GameObject uICard;
   private void Start()
   {
      _days = 0;
      _years = 0;
   }

   private void Update()
   {
      SelfRotation();
      StartCoroutine(DayCounter(selfSpeed));
      if (parentCelestial == null) return;
      OrbitRotation();
      StartCoroutine(YearCounter(speed));
   }

   private void OrbitRotation()
   {
      transform.RotateAround(parentCelestial.position,Vector3.up,speed);
   }

   private void SelfRotation()
   {
      transform.RotateAround(transform.position,Vector3.up,selfSpeed);
   }
   private IEnumerator YearCounter(float speed)
   {
      yield return new WaitForSeconds(360 / speed);
      _years++;
      Debug.Log(_years + " years passed");
   }
   private IEnumerator DayCounter(float speed)
   {
      yield return new WaitForSeconds(360 / speed);
      _days++;
      Debug.Log(_years + " days passed");
   }
}
