using System;
using System.Collections.Generic;

namespace Infrastructure.Data;

public partial class DepartMent
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Empolyee> Empolyees { get; set; } = new List<Empolyee>();
}
