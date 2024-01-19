using SistemaNotasImperio.Models;

public class NotaFiscal
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal Valor { get; set; }
    public string Descricao { get; set; }
    public DateTime DataCompra { get; set; }

    public int EmpresaId { get; set; }
    public Empresa Empresa { get; set; }
}
