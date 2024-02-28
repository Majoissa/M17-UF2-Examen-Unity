using UnityEngine;

public class Wizard : Character
{
    [SerializeField] private float protection = 50f;

    public override void TakeDamage(float amount)
    {
        if (HasProtection())
        {
            float damageToApply = Mathf.Max(amount - protection, 0); // Calcula el daño que pasa la protección
            UseProtection(amount);

            // Aplica el daño restante a la salud, si hay alguno
            if (damageToApply > 0)
            {
                base.TakeDamage(damageToApply);
            }
        }
        else
        {
            // No hay protección, tomar daño normalmente
            base.TakeDamage(amount);
        }
    }

    private void UseProtection(float amount)
    {
        protection -= amount;
        if (protection < 0)
        {
            protection = 0;
        }
    }

    private bool HasProtection()
    {
        return protection > 0;
    }
}
