using UnityEngine;

[CreateAssetMenu(fileName = "MeleeData", menuName = "CustomData/MeleeData", order = 1)]
[System.Serializable]
public class MeleeData : ScriptableObject
{
    public AnimatorOverrideController AnimatorOverrideController;
    public bool RightHandWeapon;
    public bool LeftHandWeapon;

    public Attack[] Attacks;

    public float AbilityAttackDamage = 10f;
    public float AbilityForce = 10f;
    public float AbilityForceTime = 0.3f;
    public float AbilityKnockback = 10f;
    public float AbilityAttackTime = 0.3f;
    public float HeavyImpactTime = 0.3f;
    public GameObject HeavySlash;

     public float ChargeExitDelay = 1f;
     public float ChargeImpactTime = 1f;
     public float ChargeKnockBack = 1f;
     public float MaxChargeTime = 1f;
     public float MinChargeTime = 0.5f;
}

