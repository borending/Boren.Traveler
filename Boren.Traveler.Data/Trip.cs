using System;
using System.Collections.Generic;

namespace Boren.Traveler.Data;

/// <summary>
/// 旅程
/// </summary>
public partial class Trip
{
    public int Id { get; set; }

    public string UserId { get; set; } = null!;

    /// <summary>
    /// 旅程名稱
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// 開始時間
    /// </summary>
    public DateTime Start { get; set; }

    /// <summary>
    /// 結束時間
    /// </summary>
    public DateTime End { get; set; }

    public virtual ICollection<Place> Places { get; set; } = new List<Place>();
}
