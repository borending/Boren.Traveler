using System;
using System.Collections.Generic;
using NpgsqlTypes;

namespace Boren.Traveler.Data;

public partial class Place
{
    public int Id { get; set; }

    public int TripId { get; set; }

    /// <summary>
    /// Place API.Id
    /// </summary>
    public string PlaceApiId { get; set; } = null!;

    /// <summary>
    /// Place API.displayName
    /// </summary>
    public string OriginName { get; set; } = null!;

    /// <summary>
    /// 自訂名稱
    /// </summary>
    public string? CustomName { get; set; }

    /// <summary>
    /// 座標
    /// </summary>
    public NpgsqlPoint Location { get; set; }

    /// <summary>
    /// 停留時長
    /// </summary>
    public DateTime? Stay { get; set; }

    /// <summary>
    /// 順序
    /// </summary>
    public int Order { get; set; }

    /// <summary>
    /// 備註
    /// </summary>
    public string? Remark { get; set; }

    public virtual Trip Trip { get; set; } = null!;
}
