using System;
using System.Collections.Generic;

namespace AfisolProject.Models;

public partial class TblCountry
{
    public int CountryId { get; set; }

    public string Country { get; set; } = null!;

    public virtual ICollection<TblContact> TblContacts { get; set; } = new List<TblContact>();
}
