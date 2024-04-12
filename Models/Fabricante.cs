using System;
using System.Collections.Generic;

namespace saudesuicidio.Models;

public partial class Fabricante
{
    public int CodFab { get; set; }

    public string? NomeFab { get; set; }

    public virtual ICollection<MatMed> MatMeds { get; } = new List<MatMed>();
}
