using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace udb_dse_desafio01.Models
{
  public class BancoDB : DbContext
  {
    // El contexto se ha configurado para usar una cadena de conexión 'BancoDB' del archivo
    // de configuración de la aplicación (App.config o Web.config). De forma predeterminada,
    // esta cadena de conexión tiene como destino la base de datos 'udb_dse_desafio01.Models.BancoDB' de la instancia LocalDb.
    //
    // Si desea tener como destino una base de datos y/o un proveedor de base de datos diferente,
    // modifique la cadena de conexión 'BancoDB'  en el archivo de configuración de la aplicación.
    public BancoDB() : base("name=BancoDB") { }

    // Agregue un DbSet para cada tipo de entidad que desee incluir en el modelo. Para obtener más información
    // sobre cómo configurar y usar un modelo Code First, vea http://go.microsoft.com/fwlink/?LinkId=390109.

    //public virtual DbSet<Contacto> Contactos { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
    }
  }

  [Table("clientes")]
  public class Cliente
  {
    public int Id { get; set; }

    public string Nombres { get; set; }

    public string PrimerApellido { get; set; }

    public string SegundoApellido { get; set; }

    public string Telefono { get; set; }

    public string Correo { get; set; }
  }

  [Table("cuenta_tipos")]
  public class TipoCuentaBancaria
  {
    public int Id { get; set; }

    [Column("TipoCuentaBancaria")]
    public string Nombre { get; set; }

    public bool Activo { get; set; }
  }

  [Table("cuentas")]
  public class CuentaBancaria
  {
    public int Id { get; set; }

    public int IdCliente { get; set; }

    public int Tipo { get; set; }

    public string Moneda { get; set; }
  }

  [Table("transacciones_tipos")]
  public class TipoTransaccion
  {
    public int Id { get; set; }
    
    [Column("TipoTransaccion")]
    public string Nombre { get; set; }
  }

  [Table("transacciones")]
  public class Transaccion
  {
    public int Id { get; set; }

    public int IdCuentaBancaria { get; set; }

    public int TipoTransaccion { get; set; }

    public int Monto { get; set; }

    public string Estado { get; set; }

    public DateTime FechaTransaccion { get; set; }

    public DateTime FechaAplicacion { get; set; }
  }
}
