using System;
using System.Collections.Generic;

namespace AfisolProject.Models;

public partial class TblContact
{
    public int ContactId { get; set; }

    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    public string? Tel { get; set; }

    public string? Mobile { get; set; }

    public string? Email { get; set; }

    public int? CountryId { get; set; }

    public virtual TblCountry? Country { get; set; }
}
