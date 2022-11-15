using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Data.SqlClient;

namespace SistemaLabprotecBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly string _cadenaConexion;

        public EmpleadoController(IConfiguration configuration)
        {
            _configuration = configuration;
            _cadenaConexion = _configuration.GetConnectionString("conString");
        }

        [HttpGet]
        [Produces("application/json")]
        [Route("listado")]
        public IActionResult listadoEmpleado()//listadoEmpleado();
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
                using (SqlCommand cmd = new SqlCommand("admin.crud_empleado", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@option", 4);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet setter = new DataSet();

                    try
                    {
                        adapter.Fill(setter, "Empleado");
                        if (setter.Tables["Empleado"] == null)
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

                    if (setter.Tables["Empleado"].Rows.Count <= 0)
                    {
                        respuesta = new JObject();
                        respuesta.response = "No existen registros";
                        respuesta.value = 400; //Error de registros
                        return BadRequest(respuesta);

                    }

                    return Ok(setter.Tables["Empleado"]);

                }

            }
        }//listadoEmpleado();


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
                using (SqlCommand cmd = new SqlCommand("admin.crud_empleado", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@option", 1);
                    cmd.Parameters.AddWithValue("@id_usuarios", request.GetValue("id_usuarios").ToString());

                    cmd.Parameters.AddWithValue("@nombres", request.GetValue("nombres").ToString());
                    cmd.Parameters.AddWithValue("@apellidos", request.GetValue("apellidos").ToString());
                    cmd.Parameters.AddWithValue("@apellido_casada", request.GetValue("apellido_casada").ToString());
                    cmd.Parameters.AddWithValue("@dpi", request.GetValue("dpi").ToString());
                    cmd.Parameters.AddWithValue("@no_telefono", request.GetValue("no_telefono").ToString());
                    cmd.Parameters.AddWithValue("@direccion_casa", request.GetValue("direccion_casa").ToString());
                    cmd.Parameters.AddWithValue("@foto", request.GetValue("foto").ToString());
                    cmd.Parameters.AddWithValue("@ext_foto", request.GetValue("ext_foto").ToString());
                    cmd.Parameters.AddWithValue("@cv", request.GetValue("cv").ToString());
                    cmd.Parameters.AddWithValue("@ext_cv", request.GetValue("ext_cv").ToString());
                    cmd.Parameters.AddWithValue("@email", request.GetValue("email").ToString());
                    cmd.Parameters.AddWithValue("@genero", request.GetValue("genero").ToString());
                    cmd.Parameters.AddWithValue("@fecha_nacimiento", request.GetValue("fecha_nacimiento").ToString());
                    cmd.Parameters.AddWithValue("@no_cuenta", request.GetValue("no_cuenta").ToString());
                    cmd.Parameters.AddWithValue("@banco", request.GetValue("banco").ToString());
                    cmd.Parameters.AddWithValue("@tipo_cuenta", request.GetValue("tipo_cuenta").ToString());
                    cmd.Parameters.AddWithValue("@observacion", request.GetValue("observacion").ToString());

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet setter = new DataSet();

                    try
                    {
                        adapter.Fill(setter, "Empleado");
                        if (setter.Tables["Empleado"] == null)
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

                    if (setter.Tables["Empleado"].Rows.Count <= 0)
                    {
                        respuesta = new JObject();
                        respuesta.response = "No existen registros";
                        respuesta.value = 400; //Error de registros
                        return BadRequest(respuesta);

                    }

                    return Ok(setter.Tables["Empleado"]);

                }

            }
        }//crearUsuarios();

        [HttpPost]
        [Produces("application/json")]
        [Route("eliminar")]
        public IActionResult eliminarEmpleado(JObject request)
        {
            dynamic respuesta;

            using (SqlConnection con = new SqlConnection(_cadenaConexion))//eliminarEmpleado();
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
                using (SqlCommand cmd = new SqlCommand("admin.crud_empleado", con))
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
                        adapter.Fill(setter, "Empleado");
                        if (setter.Tables["Empleado"] == null)
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

                    if (setter.Tables["Empleado"].Rows.Count <= 0)
                    {
                        respuesta = new JObject();
                        respuesta.response = "No existen registros";
                        respuesta.value = 400; //Error de registros
                        return BadRequest(respuesta);

                    }

                    return Ok(setter.Tables["Empleado"]);

                }

            }
        }//eliminarEmpleado();

        [HttpPost]
        [Produces("application/json")]
        [Route("modificar")]
        public IActionResult modificarEmpleado(JObject request)//modificarEmpleado();
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
                using (SqlCommand cmd = new SqlCommand("admin.crud_empleado", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@option", 2);
                    cmd.Parameters.AddWithValue("@id_usuarios", request.GetValue("id_usuarios").ToString());
                    cmd.Parameters.AddWithValue("@nombres", request.GetValue("nombres").ToString());
                    cmd.Parameters.AddWithValue("@apellidos", request.GetValue("apellidos").ToString());
                    cmd.Parameters.AddWithValue("@no_telefono", request.GetValue("no_telefono").ToString());
                    cmd.Parameters.AddWithValue("@direccion_casa", request.GetValue("direccion_casa").ToString());
                    cmd.Parameters.AddWithValue("@email", request.GetValue("email").ToString());
                    cmd.Parameters.AddWithValue("@no_cuenta", request.GetValue("no_cuenta").ToString());
                    cmd.Parameters.AddWithValue("@banco", request.GetValue("banco").ToString());
                    cmd.Parameters.AddWithValue("@tipo_cuenta", request.GetValue("tipo_cuenta").ToString());
                    cmd.Parameters.AddWithValue("@id", request.GetValue("id").ToString());


                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet setter = new DataSet();

                    try
                    {
                        adapter.Fill(setter, "Empleado");
                        if (setter.Tables["Empleado"] == null)
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

                    if (setter.Tables["Empleado"].Rows.Count <= 0)
                    {
                        respuesta = new JObject();
                        respuesta.response = "No existen registros";
                        respuesta.value = 400; //Error de registros
                        return BadRequest(respuesta);

                    }

                    return Ok(setter.Tables["Empleado"]);

                }

            }
        }//modificarUsuarios();


        [HttpGet]
        [Produces("application/json")]
        [Route("mostrar")]
        public IActionResult verificarEmpleado(JObject request)//mostrarEmpleado();
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
                using (SqlCommand cmd = new SqlCommand("admin.crud_empleado", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@option", 5);
                    cmd.Parameters.AddWithValue("@id", request.GetValue("id").ToString());

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet setter = new DataSet();

                    try
                    {
                        adapter.Fill(setter, "Empleado");
                        if (setter.Tables["Empleado"] == null)
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

                    if (setter.Tables["Empleado"].Rows.Count <= 0)
                    {
                        respuesta = new JObject();
                        respuesta.response = "No existen registros";
                        respuesta.value = 400; //Error de registros
                        return BadRequest(respuesta);

                    }

                    return Ok(setter.Tables["Empleado"]);

                }

            }
        }//verificarEmpleado();


        [HttpGet]
        [Produces("application/json")]
        [Route("catalogo")]
        public IActionResult catalogoEmpleado()
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
                using (SqlCommand cmd = new SqlCommand("admin.crud_empleado", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@option", 6);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet setter = new DataSet();

                    try
                    {
                        adapter.Fill(setter, "Empleado");
                        if (setter.Tables["Empleado"] == null)
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

                    if (setter.Tables["Empleado"].Rows.Count <= 0)
                    {
                        respuesta = new JObject();
                        respuesta.response = "No existen registros";
                        respuesta.value = 400; //Error de registros
                        return BadRequest(respuesta);

                    }

                    return Ok(setter.Tables["Empleado"]);

                }

            }
        }//catalogoEmpleado();



    }
}
