﻿using System;
using System.Collections.Generic;

namespace dbfirstapproach.Models;

public partial class Category
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public DateTime? CreatedDate { get; set; }
}
