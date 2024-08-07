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
    /// 創建時間
    /// </summary>
    public DateTime Time { get; set; }

    public virtual ICollection<Place> Places { get; set; } = new List<Place>();
}
