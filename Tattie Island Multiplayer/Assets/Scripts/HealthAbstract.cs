using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HealthAbstract : MonoBehaviour
{
    public abstract void TakeDamage(float dmg);

    public abstract void UpDateHealthBar();
}
