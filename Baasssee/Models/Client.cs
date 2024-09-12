using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;

namespace Baasssee.Models;

public partial class Client
{
    public int Id { get; set; }

    public string? Lastname { get; set; }

    public string? Firstname { get; set; }

    public string? Surname { get; set; }

    public int? Gender { get; set; }

    public string? Phone { get; set; }

    public string? Photopath { get; set; }
    public Bitmap? Photo => Photopath != null ? new Bitmap($@"assets\\{Photopath}") :null;

    public DateOnly? Birthday { get; set; }

    public string? Email { get; set; }

    public DateOnly? Registationdate { get; set; }

    public virtual Gender GenderNavigation { get; set; } = null;
}
