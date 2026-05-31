using System;
using System.Collections.Generic;

namespace IV.DataCenter.Models;

public partial class BtStkType
{
    public int StkTypeId { get; set; }

    public string? StkTypeName { get; set; }

    public string? StkTypeDesc { get; set; }

    public DateTime? TimeLog { get; set; }

    public string? UserLog { get; set; }
}
