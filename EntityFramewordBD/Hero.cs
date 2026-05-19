using System;
using System.Collections.Generic;

namespace EntityFrameworkBD;

public partial class Hero
{
    public int HeroId { get; set; }

    public string HeroName { get; set; } = null!;

    public string AttackType { get; set; } = null!;
}
