using System;
using System.Collections.Generic;

namespace EntityFrameworkBD;

public partial class Player
{
    public int PlayerId { get; set; }

    public string PlayerName { get; set; } = null!;

    public int? Mmr { get; set; }

    public bool? DotaPlus { get; set; }

    public int CountryId { get; set; }

    public virtual Country Country { get; set; } = null!;
}
