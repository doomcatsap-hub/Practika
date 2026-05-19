using System;
using System.Collections.Generic;

namespace EntityFrameworkBD;

public partial class Match
{
    public Guid MatchId { get; set; }

    public DateTime? MatchDate { get; set; }

    public string Winner { get; set; } = null!;
}
