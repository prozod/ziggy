using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Dtos.Stock;

public class UpdateStockRequestDto
{
    // Id removed
    [MaxLength(16)] public string Symbol { get; set; } = string.Empty;
    [MaxLength(256)] public string CompanyName { get; set; } = string.Empty;
    [Column(TypeName = "decimal(18,2)")] public decimal Purchase { get; set; }
    [Column(TypeName = "decimal(18,2)")] public decimal Dividend { get; set; }
    [MaxLength(256)] public string Industry { get; set; } = string.Empty;

    public long MarketCap { get; set; }
    // Comments removed
}