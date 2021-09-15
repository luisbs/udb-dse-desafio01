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

    public virtual DbSet<Cliente> Clientes { get; set; }
    public virtual DbSet<Cuenta> Cuentas { get; set; }
    public virtual DbSet<TipoCuenta> CuentaTipos { get; set; }
    public virtual DbSet<Transaccion> Transacciones { get; set; }
    public virtual DbSet<TipoTransaccion> TransaccionTipos { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
    }
  }

  [Table("clientes")]
  public class Cliente
  {
    [Key]
    public int Id { get; set; }
    public string Nombres { get; set; }
    public string PrimerApellido { get; set; }
    public string SegundoApellido { get; set; }
    public string Telefono { get; set; }
    public string Correo { get; set; }
  }

  [Table("cuenta_tipos")]
  public class TipoCuenta
  {
    [Key]
    public int Id { get; set; }

    [Column("TipoCuenta")]
    public string Nombre { get; set; }

    public bool Activo { get; set; }
  }

  [Table("cuentas")]
  public class Cuenta
  {
    [Key]
    public int Id { get; set; }
    public string Moneda { get; set; }

    [Column("IdCliente")]
    public int ClienteId { get; set; }

    [ForeignKey("ClienteId")]
    public virtual Cliente Cliente { get; set; }

    [Column("Tipo")]
    public int TipoId { get; set; }

    [ForeignKey("TipoId")]
    public virtual TipoCuenta Tipo { get; set; }
  }

  [Table("transacciones_tipos")]
  public class TipoTransaccion
  {
    [Key]
    public int Id { get; set; }

    [Column("TipoTransaccion")]
    public string Nombre { get; set; }
  }

  [Table("transacciones")]
  public class Transaccion
  {
    [Key]
    public int Id { get; set; }
    public int Monto { get; set; }
    public string Estado { get; set; }
    public DateTime FechaTransaccion { get; set; }
    public DateTime FechaAplicacion { get; set; }

    [Column("IdCuentaBancaria")]
    public int CuentaId { get; set; }

    [ForeignKey("CuentaId")]
    public virtual Cuenta Cuenta { get; set; }

    [Column("TipoTransaccion")]
    public int TipoId { get; set; }

    [ForeignKey("TipoId")]
    public virtual TipoTransaccion Tipo { get; set; }
  }
}
