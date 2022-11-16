using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Data.SqlClient;

namespace SistemaLabprotecBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamenesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly string _cadenaConexion;

        public ExamenesController(IConfiguration configuration)
        {
            _configuration = configuration;
            _cadenaConexion = _configuration.GetConnectionString("conString");
        }


        [HttpPost]
        [Produces("application/json")]
        [Route("crear")]
        public IActionResult crearExamenes(JObject request)//crearExamenes();
        {
            dynamic respuesta;

            using (SqlConnection con = new SqlConnection(_cadenaConexion))
            {
                try
                {
                    con.Open();
                }
                catch (Exception ex)
                {
                    respuesta = new JObject();
                    respuesta.response = ex.Message;
                    respuesta.value = 500; //Error de apertura de conexión
                    return BadRequest(respuesta);
                }
                using (SqlCommand cmd = new SqlCommand("lab.crud_examenes", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@option", 1);
                    cmd.Parameters.AddWithValue("@id_usuarios", request.GetValue("id_usuarios").ToString());

                    cmd.Parameters.AddWithValue("@nombre", request.GetValue("nombre").ToString());
                    cmd.Parameters.AddWithValue("@descripcion", request.GetValue("descripcion").ToString());

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet setter = new DataSet();

                    try
                    {
                        adapter.Fill(setter, "Examnenes");
                        if (setter.Tables["Examnenes"] == null)
                        {
                            respuesta = new JObject();
                            respuesta.response = "No existen registros";
                            respuesta.value = 400; //Error de registros
                            return BadRequest(respuesta);
                        }
                    }
                    catch (Exception ex)
                    {
                        respuesta = new JObject();
                        respuesta.response = ex.Message;
                        respuesta.value = 400; //Error al capturar los de registros
                        return BadRequest(respuesta);

                    }

                    if (setter.Tables["Examnenes"].Rows.Count <= 0)
                    {
                        respuesta = new JObject();
                        respuesta.response = "No existen registros";
                        respuesta.value = 400; //Error de registros
                        return BadRequest(respuesta);

                    }

                    return Ok(setter.Tables["Examnenes"]);

                }

            }
        }//CrearExamenes();


        [HttpPost]
        [Produces("application/json")]
        [Route("modificar")]
        public IActionResult modificarExamenes(JObject request)//ModificarExamenes();
        {
            dynamic respuesta;

            using (SqlConnection con = new SqlConnection(_cadenaConexion))
            {
                try
                {
                    con.Open();
                }
                catch (Exception ex)
                {
                    respuesta = new JObject();
                    respuesta.response = ex.Message;
                    respuesta.value = 500; //Error de apertura de conexión
                    return BadRequest(respuesta);
                }
                using (SqlCommand cmd = new SqlCommand("admin.crud_roles", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@option", 2);
                    cmd.Parameters.AddWithValue("@id_usuarios", request.GetValue("id_usuarios").ToString());
                    cmd.Parameters.AddWithValue("@nombre", request.GetValue("nombre").ToString());
                    cmd.Parameters.AddWithValue("@descripcion", request.GetValue("descripcion").ToString());
                    cmd.Parameters.AddWithValue("@id", request.GetValue("id").ToString());

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet setter = new DataSet();

                    try
                    {
                        adapter.Fill(setter, "Examenes");
                        if (setter.Tables["Examenes"] == null)
                        {
                            respuesta = new JObject();
                            respuesta.response = "No existen registros";
                            respuesta.value = 400; //Error de registros
                            return BadRequest(respuesta);
                        }
                    }
                    catch (Exception ex)
                    {
                        respuesta = new JObject();
                        respuesta.response = ex.Message;
                        respuesta.value = 400; //Error al capturar los de registros
                        return BadRequest(respuesta);

                    }

                    if (setter.Tables["Examenes"].Rows.Count <= 0)
                    {
                        respuesta = new JObject();
                        respuesta.response = "No existen registros";
                        respuesta.value = 400; //Error de registros
                        return BadRequest(respuesta);

                    }

                    return Ok(setter.Tables["Examenes"]);

                }

            }
        }//modificarExamenes();


        [HttpPost]
        [Produces("application/json")]
        [Route("eliminar")]
        public IActionResult eliminarExamenes(JObject request)//eliminarExamenes();
        {
            dynamic respuesta;

            using (SqlConnection con = new SqlConnection(_cadenaConexion))
            {
                try
                {
                    con.Open();
                }
                catch (Exception ex)
                {
                    respuesta = new JObject();
                    respuesta.response = ex.Message;
                    respuesta.value = 500; //Error de apertura de conexión
                    return BadRequest(respuesta);
                }
                using (SqlCommand cmd = new SqlCommand("lab.crud_examenes", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@option", 3);
                    cmd.Parameters.AddWithValue("@id_usuarios", request.GetValue("id_usuarios").ToString());
                    cmd.Parameters.AddWithValue("@estado", request.GetValue("estado").ToString());
                    cmd.Parameters.AddWithValue("@id", request.GetValue("id").ToString());

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet setter = new DataSet();

                    try
                    {
                        adapter.Fill(setter, "Examenes");
                        if (setter.Tables["Examenes"] == null)
                        {
                            respuesta = new JObject();
                            respuesta.response = "No existen registros";
                            respuesta.value = 400; //Error de registros
                            return BadRequest(respuesta);
                        }
                    }
                    catch (Exception ex)
                    {
                        respuesta = new JObject();
                        respuesta.response = ex.Message;
                        respuesta.value = 400; //Error al capturar los de registros
                        return BadRequest(respuesta);

                    }

                    if (setter.Tables["Examenes"].Rows.Count <= 0)
                    {
                        respuesta = new JObject();
                        respuesta.response = "No existen registros";
                        respuesta.value = 400; //Error de registros
                        return BadRequest(respuesta);

                    }

                    return Ok(setter.Tables["Examenes"]);

                }

            }
        }//eliminarExamenes();



        [HttpGet]
        [Produces("application/json")]
        [Route("mostrar")]
        public IActionResult verificarExamenes()//verificarExamenes();
        {
            dynamic respuesta;

            using (SqlConnection con = new SqlConnection(_cadenaConexion))
            {
                try
                {
                    con.Open();
                }
                catch (Exception ex)
                {
                    respuesta = new JObject();
                    respuesta.response = ex.Message;
                    respuesta.value = 500; //Error de apertura de conexión
                    return BadRequest(respuesta);
                }
                using (SqlCommand cmd = new SqlCommand("lab.crud_examenes", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@option", 4);
                    
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet setter = new DataSet();

                    try
                    {
                        adapter.Fill(setter, "Examenes");
                        if (setter.Tables["Examenes"] == null)
                        {
                            respuesta = new JObject();
                            respuesta.response = "No existen registros";
                            respuesta.value = 400; //Error de registros
                            return BadRequest(respuesta);
                        }
                    }
                    catch (Exception ex)
                    {
                        respuesta = new JObject();
                        respuesta.response = ex.Message;
                        respuesta.value = 400; //Error al capturar los de registros
                        return BadRequest(respuesta);

                    }

                    if (setter.Tables["Examenes"].Rows.Count <= 0)
                    {
                        respuesta = new JObject();
                        respuesta.response = "No existen registros";
                        respuesta.value = 400; //Error de registros
                        return BadRequest(respuesta);

                    }

                    return Ok(setter.Tables["Examenes"]);

                }

            }
        }//verificarExamenes();


        [HttpGet]
        [Produces("application/json")]
        [Route("catalogo")]
        public IActionResult catalogoExamenes()
        {
            dynamic respuesta;

            using (SqlConnection con = new SqlConnection(_cadenaConexion))
            {
                try
                {
                    con.Open();
                }
                catch (Exception ex)
                {
                    respuesta = new JObject();
                    respuesta.response = ex.Message;
                    respuesta.value = 500; //Error de apertura de conexión
                    return BadRequest(respuesta);
                }
                using (SqlCommand cmd = new SqlCommand("lab.crud_examenes", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@option", 5);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet setter = new DataSet();

                    try
                    {
                        adapter.Fill(setter, "Examenes");
                        if (setter.Tables["Examenes"] == null)
                        {
                            respuesta = new JObject();
                            respuesta.response = "No existen registros";
                            respuesta.value = 400; //Error de registros
                            return BadRequest(respuesta);
                        }
                    }
                    catch (Exception ex)
                    {
                        respuesta = new JObject();
                        respuesta.response = ex.Message;
                        respuesta.value = 400; //Error al capturar los de registros
                        return BadRequest(respuesta);

                    }

                    if (setter.Tables["Examenes"].Rows.Count <= 0)
                    {
                        respuesta = new JObject();
                        respuesta.response = "No existen registros";
                        respuesta.value = 400; //Error de registros
                        return BadRequest(respuesta);

                    }

                    return Ok(setter.Tables["Examenes"]);

                }

            }
        }//catalogoExamenes();



    }
}
        
