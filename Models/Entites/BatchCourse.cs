using System;
using System.Collections.Generic;

namespace Models.Entites;

public partial class BatchCourse
{
    public int Id { get; set; }

    public int? Status { get; set; }

    public int? Point { get; set; }

    public int? BatchId { get; set; }

    public int? CourseId { get; set; }

    public virtual Batch? Batch { get; set; }

    public virtual Course? Course { get; set; }
}
