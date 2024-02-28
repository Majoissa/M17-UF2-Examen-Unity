using UnityEngine;

public class Wizard : Character
{
    public float protection = 50f;

    public override void TakeDamage(float amount)
    {
        if (protection > 0)
        {
            protection -= amount;
            if (protection < 0)
            {
                health += protection;
                protection = 0;
            }
        }
        else
        {
            base.TakeDamage(amount);
        }
    }
}
