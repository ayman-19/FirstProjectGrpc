using System;
using System.Collections.Generic;

namespace Infrastructure.Data;

public partial class Empolyee
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreateDateTime { get; set; }

    public int? DepartId { get; set; }

    public virtual DepartMent? Depart { get; set; }
}
