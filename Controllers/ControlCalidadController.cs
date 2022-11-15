using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Data.SqlClient;

namespace SistemaLabprotecBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControlCalidadController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly string _cadenaConexion;

        public ControlCalidadController(IConfiguration configuration)
        {
            _configuration = configuration;
            _cadenaConexion = _configuration.GetConnectionString("conString");
        }


        [HttpPost]
        [Produces("application/json")]
        [Route("crear")]
        public IActionResult crearControlCalidad(JObject request)//crearControlCalidad();
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
                using (SqlCommand cmd = new SqlCommand("lab.crud_control_calidad", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@option", 1);
                    cmd.Parameters.AddWithValue("@id_usuarios", request.GetValue("id_usuarios").ToString());

                    cmd.Parameters.AddWithValue("@cantidad", request.GetValue("cantidad").ToString());
                    cmd.Parameters.AddWithValue("@id_detalle_prueba_insumos", request.GetValue("@id_detalle_prueba_insumos").ToString());
                    cmd.Parameters.AddWithValue("@id_inventario", request.GetValue("@id_inventario").ToString());
                    
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet setter = new DataSet();

                    try
                    {
                        adapter.Fill(setter, "ControlCalidad");
                        if (setter.Tables["ControlCalidad"] == null)
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

                    if (setter.Tables["ControlCalidad"].Rows.Count <= 0)
                    {
                        respuesta = new JObject();
                        respuesta.response = "No existen registros";
                        respuesta.value = 400; //Error de registros
                        return BadRequest(respuesta);

                    }

                    return Ok(setter.Tables["ControlCalidad"]);

                }

            }
        }//CrearControlCalidad();


        [HttpPost]
        [Produces("application/json")]
        [Route("modificar")]
        public IActionResult modificarControlCalidad(JObject request)//ModificarControlCalidad();
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
                using (SqlCommand cmd = new SqlCommand("lab.crud_control_calidad", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@option", 2);
                    cmd.Parameters.AddWithValue("@id_usuarios", request.GetValue("id_usuarios").ToString());
                    cmd.Parameters.AddWithValue("@cantidad", request.GetValue("cantidad").ToString());
                    cmd.Parameters.AddWithValue("@id", request.GetValue("id").ToString());

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet setter = new DataSet();

                    try
                    {
                        adapter.Fill(setter, "ControlCalidad");
                        if (setter.Tables["ControlCalidad"] == null)
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

                    if (setter.Tables["ControlCalidad"].Rows.Count <= 0)
                    {
                        respuesta = new JObject();
                        respuesta.response = "No existen registros";
                        respuesta.value = 400; //Error de registros
                        return BadRequest(respuesta);

                    }

                    return Ok(setter.Tables["ControlCalidad"]);

                }

            }
        }//modificarControlCalidad();


        [HttpPost]
        [Produces("application/json")]
        [Route("eliminar")]
        public IActionResult eliminarControlCalidad(JObject request)//eliminarControlCalidad();
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
                using (SqlCommand cmd = new SqlCommand("lab.[crud_control_calidad]", con))
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
                        adapter.Fill(setter, "ControlCalidad");
                        if (setter.Tables["ControlCalidad"] == null)
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

                    if (setter.Tables["ControlCalidad"].Rows.Count <= 0)
                    {
                        respuesta = new JObject();
                        respuesta.response = "No existen registros";
                        respuesta.value = 400; //Error de registros
                        return BadRequest(respuesta);

                    }

                    return Ok(setter.Tables["ControlCalidad"]);

                }

            }
        }//eliminarControlCalidad();


        [HttpGet]
        [Produces("application/json")]
        [Route("mostrar")]
        public IActionResult verificarControlCalidad()//mostrarControlCalidad();
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
                using (SqlCommand cmd = new SqlCommand("lab.control_calidad", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@option", 4);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet setter = new DataSet();

                    try
                    {
                        adapter.Fill(setter, "ControlCalidad");
                        if (setter.Tables["ControlCalidad"] == null)
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

                    if (setter.Tables["ControlCalidad"].Rows.Count <= 0)
                    {
                        respuesta = new JObject();
                        respuesta.response = "No existen registros";
                        respuesta.value = 400; //Error de registros
                        return BadRequest(respuesta);

                    }

                    return Ok(setter.Tables["ControlCalidad"]);

                }

            }
        }//mostrarControlCalidad();
    }
}
        
