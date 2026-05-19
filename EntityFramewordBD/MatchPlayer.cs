using System;
using System.Collections.Generic;

namespace EntityFrameworkBD;

public partial class MatchPlayer
{
    public Guid? MatchId { get; set; }

    public int PlayerId { get; set; }

    public int HeroId { get; set; }

    public string? Side { get; set; }

    public virtual Hero Hero { get; set; } = null!;

    public virtual Match? Match { get; set; }

    public virtual Player Player { get; set; } = null!;
}
