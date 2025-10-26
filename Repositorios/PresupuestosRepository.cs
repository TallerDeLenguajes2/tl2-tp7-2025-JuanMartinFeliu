using System;
using Microsoft.Data.Sqlite;
using Presupuestos;
using PresupuestosDetalle;

public interface IPresupuestoRepository
{
    public void CrearPresupuesto(Presupuesto presup);
    public List<Presupuesto> ListarPresupuestos();
    public Presupuesto ObtenerDetallesPresupuesto(int idBuscado);
    public void AgregarProducto(int idBuscado);
    public void EliminarPresupuesto(int idBuscado);

}

public class PresupuestoRepository : IPresupuestoRepository
{
    private string connectionString = "Data Source=Data/Tienda.db";
    public void CrearPresupuesto(Presupuesto presup)
    {
        using var conexion = new SqliteConnection(connectionString);
        conexion.Open();
        string sql = "INSERT INTO Presupuestos (idPresupuesto, NombreDestinatario, FechaCreacion) VALUES (@idPresupuesto, @NombreDestinatario, @FechaCreacion)";
        using var comando = new SqliteCommand(sql, conexion);
        comando.Parameters.Add(new SqliteParameter("@idPresupuesto", presup.IdPresupuesto));
        comando.Parameters.Add(new SqliteParameter("@NombreDestinatario", presup.NombreDestinatario));
        comando.Parameters.Add(new SqliteParameter("@FechaCreacion", presup.FechaCreacion1)); comando.ExecuteNonQuery();
    }

    public List<Presupuesto> ListarPresupuestos()
    {
        var presupuesto = new List<Presupuesto>();
        using var conexion = new SqliteConnection(connectionString);
        conexion.Open();

        string sql = "SELECT idPresupuesto, NombreDestinatario, FechaCreacion FROM Presupuestos";
        using var comando = new SqliteCommand(sql, conexion);
        using var lector = comando.ExecuteReader();

        while (lector.Read())
        {
            var pre = new Presupuesto
            {
                IdPresupuesto = Convert.ToInt32(lector["idPresupuesto"]),
                NombreDestinatario = lector["NombreDestinatario"].ToString(),
                FechaCreacion1 = Convert.ToDateTime(lector["FechaCreacion"])
            };
            presupuesto.Add(pre);
        }

        return presupuesto;
    }

    public Presupuesto ObtenerDetallesPresupuesto(int idBuscado)
    {
        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        // WHERE sobre la columna correcta
        string consulta = "SELECT  idPresupuesto, NombreDestinatario, FechaCreacion FROM Presupuesto WHERE idPresupuesto = @Id";
        using var comando = new SqliteCommand(consulta, connection);
        comando.Parameters.AddWithValue("@Id", idBuscado);

        using var lector = comando.ExecuteReader();
        if (lector.Read())
        {
            var pre = new Presupuesto
            {
                IdPresupuesto = Convert.ToInt32(lector["idPresupuesto"]),
                NombreDestinatario = lector["NombreDestinatario"].ToString(),
                FechaCreacion1 = Convert.ToDateTime(lector["FechaCreacion"])
            };
            return pre;
        }

        return null;
    }

    public void AgregarProducto(int idBuscado)
    {

    }

    public void EliminarPresupuesto(int idBuscado)
    {
        using var conexion = new SqliteConnection(connectionString);
        conexion.Open();

        string sql = "DELETE FROM Presupuestos WHERE idPresupuesto = @Id";
        using var comando = new SqliteCommand(sql, conexion);
        comando.Parameters.AddWithValue("@Id", idBuscado);

        comando.ExecuteNonQuery();
    }
    

}
