using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

[ApiController]
[Route("conexion")]
public class Conexion : Controller {
    [HttpGet("sql")]
    public IActionResult ListarCarrerasSql(){
        List<CarrerasSQL> lista = new List<CarreraSQL>();

        SqlConnection conn = new SqlConnection(CadenasConecxion.SQL_SERVER);
        SqlCommand cmd = new SqlCommand("select IdCarrera, Carrera from Carreras");
        cmd.Connection = conn;
        cmd.CommandType = System.Data.CommandType.Text;
        cmd.Connection.Open();

        sqlDataReader = cmd.ExecuteReader();

        while (reader.Read()) {
            CarreraSQL carreera = new CarreraSQL();
            carrera.IdCarrera = reader.GetInt16("IdCarrera");
            carrera.Carrera = reader.GetString("Carrera");

            lista.Add(carrera);
        }

        reader.Close();
        conn.Close();

        return Ok(lista);
    }

    [HttpGet("mongo")]
    public IActionResult ListarSalonesMongoDb(){
        return Ok("Me estoy conectando a MongoDb");
    }
}