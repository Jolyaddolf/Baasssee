using System;
using System.Collections.Generic;

namespace Baasssee.Models;

public partial class Visit
{
    public int? Id { get; set; }

    public DateOnly? Date { get; set; }

    public TimeOnly? Time { get; set; }
}
