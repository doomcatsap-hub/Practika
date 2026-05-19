using System;
using System.Collections.Generic;

namespace EntityFrameworkBD;

public partial class Country
{
    public int CountryId { get; set; }

    public string? CountryName { get; set; }

    public virtual ICollection<Player> Players { get; set; } = new List<Player>();
}
