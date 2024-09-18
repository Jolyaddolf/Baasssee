using System;
using System.Collections.Generic;

namespace Baasssee.Models;

public partial class Gender
{
    public int Code { get; set; }

    public string? Namegender { get; set; }

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    public virtual Gender CodeNavigation { get; set; } = null!;

    public virtual Gender? InverseCodeNavigation { get; set; }
}
