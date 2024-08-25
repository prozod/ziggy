using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models;

public class Stock
{
    public int Id { get; set; }
    [MaxLength(16)] public string Symbol { get; set; } = string.Empty;
    [MaxLength(256)] public string CompanyName { get; set; } = string.Empty;

    [Column(TypeName = "decimal(18,2)")] public decimal Purchase { get; set; }
    [Column(TypeName = "decimal(18,2)")] public decimal Dividend { get; set; }
    [MaxLength(256)] public string Industry { get; set; } = string.Empty;
    public long MarketCap { get; set; }
    public List<Comment> Comments { get; set; } = new();
}