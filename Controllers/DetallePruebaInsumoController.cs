using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Data.SqlClient;

namespace SistemaLabprotecBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetallePruebaInsumoController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly string _cadenaConexion;

        public DetallePruebaInsumoController(IConfiguration configuration)
        {
            _configuration = configuration;
            _cadenaConexion = _configuration.GetConnectionString("conString");
        }


        [HttpPost]
        [Produces("application/json")]
        [Route("crear")]
        public IActionResult crearDetallePruebaInsumo(JObject request)//crearDetallePruebaInsumo();
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
                using (SqlCommand cmd = new SqlCommand("lab.crud_detalle_Prueba_Insumos", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@option", 1);
                    cmd.Parameters.AddWithValue("@id_usuarios", request.GetValue("id_usuarios").ToString());

                    cmd.Parameters.AddWithValue("@cantidad", request.GetValue("cantidad").ToString());
                    cmd.Parameters.AddWithValue("@id_detalle_prueba_orden_medica", request.GetValue("@id_detalle_prueba_orden_medica").ToString());
                    cmd.Parameters.AddWithValue("@id_inventario", request.GetValue("@id_inventario").ToString());
                    
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet setter = new DataSet();

                    try
                    {
                        adapter.Fill(setter, "DetallePruebaInsumo");
                        if (setter.Tables["DetallePruebaInsumo"] == null)
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

                    if (setter.Tables["DetallePruebaInsumo"].Rows.Count <= 0)
                    {
                        respuesta = new JObject();
                        respuesta.response = "No existen registros";
                        respuesta.value = 400; //Error de registros
                        return BadRequest(respuesta);

                    }

                    return Ok(setter.Tables["DetallePruebaInsumo"]);

                }

            }
        }//CrearRoles();


        [HttpPost]
        [Produces("application/json")]
        [Route("modificar")]
        public IActionResult modificarDetallePruebaInsumo(JObject request)//ModificarDetallePruebaInsumo();
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
                using (SqlCommand cmd = new SqlCommand("lab.crud_detalle_Prueba_Insumos", con))
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
                        adapter.Fill(setter, "DetallePruebaInsumo");
                        if (setter.Tables["DetallePruebaInsumo"] == null)
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

                    if (setter.Tables["DetallePruebaInsumo"].Rows.Count <= 0)
                    {
                        respuesta = new JObject();
                        respuesta.response = "No existen registros";
                        respuesta.value = 400; //Error de registros
                        return BadRequest(respuesta);

                    }

                    return Ok(setter.Tables["DetallePruebaInsumo"]);

                }

            }
        }//modificarDetallePruebaInsumo();


        [HttpPost]
        [Produces("application/json")]
        [Route("eliminar")]
        public IActionResult eliminarDetallePruebaInsumo(JObject request)//eliminarDetallePruebaInsumo();
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
                using (SqlCommand cmd = new SqlCommand("lab.[crud_detalle_Prueba_Insumos]", con))
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
                        adapter.Fill(setter, "DetallePruebaInsumo");
                        if (setter.Tables["DetallePruebaInsumo"] == null)
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

                    if (setter.Tables["DetallePruebaInsumo"].Rows.Count <= 0)
                    {
                        respuesta = new JObject();
                        respuesta.response = "No existen registros";
                        respuesta.value = 400; //Error de registros
                        return BadRequest(respuesta);

                    }

                    return Ok(setter.Tables["DetallePruebaInsumo"]);

                }

            }
        }//eliminarDetallePruebaInsumo();


        [HttpGet]
        [Produces("application/json")]
        [Route("mostrar")]
        public IActionResult verificarDetallePruebaInsumo()//mostrarPuesto();
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
                using (SqlCommand cmd = new SqlCommand("lab.crud_detalle_Prueba_Orden_Medica", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@option", 4);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet setter = new DataSet();

                    try
                    {
                        adapter.Fill(setter, "DetallePruebaInsumo");
                        if (setter.Tables["DetallePruebaInsumo"] == null)
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

                    if (setter.Tables["DetallePruebaInsumo"].Rows.Count <= 0)
                    {
                        respuesta = new JObject();
                        respuesta.response = "No existen registros";
                        respuesta.value = 400; //Error de registros
                        return BadRequest(respuesta);

                    }

                    return Ok(setter.Tables["DetallePruebaInsumo"]);

                }

            }
        }//mostrarPuesto();


    }
}
        
