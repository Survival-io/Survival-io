using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public static UnityEvent enemyMovementAnimation = new UnityEvent();
    public static UnityEvent enemyAttackAnimation = new UnityEvent();
    public static UnityEvent doorOpening = new UnityEvent();
    public static UnityEvent doorClosing = new UnityEvent();
}
