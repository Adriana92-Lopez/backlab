using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Data.SqlClient;

namespace SistemaLabprotecBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReferenciaEmpleadosController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly string _cadenaConexion;

        public ReferenciaEmpleadosController(IConfiguration configuration)
        {
            _configuration = configuration;
            _cadenaConexion = _configuration.GetConnectionString("conString");
        }


        [HttpPost]
        [Produces("application/json")]
        [Route("crear")]
        public IActionResult crearReferenciasEmpleados(JObject request)//crearRefereciasEmpleados();
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
                using (SqlCommand cmd = new SqlCommand("admin.crud_referencia_empleados", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@option", 1);
                    cmd.Parameters.AddWithValue("@id_usuarios", request.GetValue("id_usuarios").ToString());

                    cmd.Parameters.AddWithValue("@nombres_referencias", request.GetValue("nombres_referencias").ToString());
                    cmd.Parameters.AddWithValue("@apellidos_referencias", request.GetValue("apellidos_referencias").ToString());
                    cmd.Parameters.AddWithValue("@no_telefono", request.GetValue("no_telefono").ToString());
                    cmd.Parameters.AddWithValue("@direccion", request.GetValue("direccion").ToString());
                    cmd.Parameters.AddWithValue("@id_empleado", request.GetValue("id_empleado").ToString());

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet setter = new DataSet();

                    try
                    {
                        adapter.Fill(setter, "ReferenciaEmpleados");
                        if (setter.Tables["ReferenciaEmpleados"] == null)
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

                    if (setter.Tables["ReferenciaEmpleados"].Rows.Count <= 0)
                    {
                        respuesta = new JObject();
                        respuesta.response = "No existen registros";
                        respuesta.value = 400; //Error de registros
                        return BadRequest(respuesta);

                    }

                    return Ok(setter.Tables["ReferenciaEmpleados"]);

                }

            }
        }//CrearReferenciasEmpleados();


        [HttpPost]
        [Produces("application/json")]
        [Route("modificar")]
        public IActionResult modificarReferenciasEmpleados(JObject request)//ModificarReferenciasEmpleados();
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
                using (SqlCommand cmd = new SqlCommand("admin.crud_referencia_empleados", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@option", 2);
                    cmd.Parameters.AddWithValue("@nombres_referencias", request.GetValue("nombres_referencias").ToString());
                    cmd.Parameters.AddWithValue("@apellidos_referencias", request.GetValue("apellidos_referencias").ToString());
                    cmd.Parameters.AddWithValue("@no_telefono", request.GetValue("no_telefono").ToString());
                    cmd.Parameters.AddWithValue("@direccion", request.GetValue("direccion").ToString());
                    cmd.Parameters.AddWithValue("@id", request.GetValue("id").ToString());

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet setter = new DataSet();

                    try
                    {
                        adapter.Fill(setter, "ReferenciaEmpleados");
                        if (setter.Tables["ReferenciaEmpleados"] == null)
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

                    if (setter.Tables["ReferenciaEmpleados"].Rows.Count <= 0)
                    {
                        respuesta = new JObject();
                        respuesta.response = "No existen registros";
                        respuesta.value = 400; //Error de registros
                        return BadRequest(respuesta);

                    }

                    return Ok(setter.Tables["ReferenciaEmpleados"]);

                }

            }
        }//modificarReferenciaEmpleados();


        [HttpGet]
        [Produces("application/json")]
        [Route("listado")]
        public IActionResult listadoReferenciaEmpleado()
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
                using (SqlCommand cmd = new SqlCommand("admin.crud_referencia_empleados", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@option", 3);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet setter = new DataSet();

                    try
                    {
                        adapter.Fill(setter, "ReferenciaEmpleados");
                        if (setter.Tables["ReferenciaEmpleados"] == null)
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

                    if (setter.Tables["ReferenciaEmpleados"].Rows.Count <= 0)
                    {
                        respuesta = new JObject();
                        respuesta.response = "No existen registros";
                        respuesta.value = 400; //Error de registros
                        return BadRequest(respuesta);

                    }

                    return Ok(setter.Tables["ReferenciaEmpleados"]);

                }

            }
        }//listadoReferenciaEmpleados();



        [HttpPost]
        [Produces("application/json")]
        [Route("eliminar")]
        public IActionResult eliminarReferenciaEmpleados(JObject request)//eliminarReferenciaEmpleados();
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
                using (SqlCommand cmd = new SqlCommand("admin.crud_referencia_empleados", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@option", 5);
                    cmd.Parameters.AddWithValue("@id", request.GetValue("id").ToString());

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet setter = new DataSet();

                    try
                    {
                        adapter.Fill(setter, "ReferenciaEmpleados");
                        if (setter.Tables["ReferenciaEmpleados"] == null)
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

                    if (setter.Tables["ReferenciaEmpleados"].Rows.Count <= 0)
                    {
                        respuesta = new JObject();
                        respuesta.response = "No existen registros";
                        respuesta.value = 400; //Error de registros
                        return BadRequest(respuesta);

                    }

                    return Ok(setter.Tables["ReferenciaEmpleados"]);

                }

            }
        }//verificarReferenciaEmpleados();

        [HttpPost]
        [Produces("application/json")]
        [Route("mostrar")]
        public IActionResult verificarReferenciaEmpleados(JObject request)//mostrarReferenciaEmpleados();
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
                using (SqlCommand cmd = new SqlCommand("admin.crud_referencia_empleados", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@option", 4);
                    cmd.Parameters.AddWithValue("@id_empleado", request.GetValue("id_empleado").ToString());

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet setter = new DataSet();

                    try
                    {
                        adapter.Fill(setter, "ReferenciaEmpleados");
                        if (setter.Tables["ReferenciaEmpleados"] == null)
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

                    if (setter.Tables["ReferenciaEmpleados"].Rows.Count <= 0)
                    {
                        respuesta = new JObject();
                        respuesta.response = "No existen registros";
                        respuesta.value = 400; //Error de registros
                        return BadRequest(respuesta);

                    }

                    return Ok(setter.Tables["ReferenciaEmpleados"]);

                }

            }
        }//verificarReferenciaEmpleados();


    }
}
        
