using System;
using System.Collections.Generic;

namespace saudesuicidio.Models;

public partial class ClasseMed
{
    public int CodClass { get; set; }

    public string NomeClasse { get; set; } = null!;

    public virtual ICollection<MatMed> MatMeds { get; } = new List<MatMed>();
}
