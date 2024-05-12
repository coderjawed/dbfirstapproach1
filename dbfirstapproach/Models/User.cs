using System;
using System.Collections.Generic;

namespace dbfirstapproach.Models;

public partial class User
{
    public int Id { get; set; }

    public string? FullName { get; set; }

    public string? MobileNo { get; set; }

    public string? Email { get; set; }

    public string? Gender { get; set; }

    public int CategoryId { get; set; }

    public string? CompanyName { get; set; }

    public string? Gstno { get; set; }

    public int RegisteredId { get; set; }

    public string Password { get; set; } = null!;

    public DateTime? CreatedDate { get; set; }
}
