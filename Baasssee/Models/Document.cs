using System;
using System.Collections.Generic;
using NpgsqlTypes;

namespace Baasssee.Models;

public partial class Document
{
    public int Id { get; set; }

    public NpgsqlPath? Path { get; set; }

    public int ClientId { get; set; }
}
