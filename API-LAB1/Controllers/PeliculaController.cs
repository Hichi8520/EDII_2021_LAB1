using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Library_LAB1;
using API_LAB1.Models;
using API_LAB1.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_LAB1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculaController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            string mensaje = "Laboratorio 1 - Inicio Exitoso...\n * Cree su arbol - Mande un numero para crear el grado del arbol \n * Mande sus inserciones desde postman por medio de una lista de peliculas agregando a la url '/populate'\n * Verifique la información por medio de modificar la url con los recorridos /InOrder  /PostOrder /PreOrder \n";
            return mensaje;
        }

        private IHostingEnvironment _env;

        public PeliculaController(IHostingEnvironment env)
        {
            _env = env;
        }

        // Create a tree with the inserted value as the degree
        [HttpPost]
        public ActionResult Grado([FromBody] int value)
        {
            Data<Pelicula>.Instance.grado = value;
            Data<Pelicula>.Instance.temp = new ArbolB<Pelicula>(value);
            return Created("", "Árbol creado de grado " + value.ToString());
        }

        // Delete the tree
        [HttpDelete]
        public ActionResult Delete()
        {
            if (Data<Pelicula>.Instance.grado != 0)
            {
                Data<Pelicula>.Instance.temp = null;
                Data<Pelicula>.Instance.grado = 0;
                return Ok("Árbol eliminado exitosamente");
            }
            else return BadRequest("No existe el árbol a eliminar");
        }

        // Insert values from json to the tree
        [HttpPost]
        [Route("populate")]
        public IActionResult Add([FromBody] List<Pelicula> peliculas)
        {
            try
            {
                if (Data<Pelicula>.Instance.grado != 0)
                {
                    for (int i = 0; i < peliculas.Count; i++)
                    {                            
                        Data<Pelicula>.Instance.temp.insertar(peliculas[i]);
                    }
                    return Ok();
                }
                else
                {
                    return BadRequest("Debe de crear su arbol primero");
                }
            }
            catch (InvalidCastException e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok();
        }

        //public ActionResult Add([FromForm] IFormFile value)
        //{
        //    try
        //    {
        //        if (Data<Pelicula>.Instance.grado != 0)
        //        {
        //            //for (int i = 0; i < value.Count; i++)
        //            //{
        //            //    Data<Pelicula>.Instance.temp.insertar(value[i]);
        //            //}
        //            return Ok();
        //        }
        //        else
        //        {
        //            return BadRequest("Debe de crear su arbol primero");
        //        }
        //    }
        //    catch (InvalidCastException e)
        //    {
        //        return BadRequest("InternalServerError");
        //    }
        //    return Ok();
        //}

        [HttpGet]
        [Route("InOrder")]
        public IEnumerable<Pelicula> GetIn()
        {
            List<Pelicula> InOrden = new List<Pelicula>();

            if (Data<Pelicula>.Instance.grado != 0)
            {
                InOrden = Data<Pelicula>.Instance.temp.InOrder(Data<Pelicula>.Instance.grado);
                return InOrden;
            }
            else
            {
                return InOrden;
            }
        }
        [HttpGet]
        [Route("PostOrder")]
        public IEnumerable<Pelicula> GetPost()
        {
            List<Pelicula> PostOrden = new List<Pelicula>();

            if (Data<Pelicula>.Instance.grado != 0)
            {
                PostOrden = Data<Pelicula>.Instance.temp.PostOrder(Data<Pelicula>.Instance.grado);
                return PostOrden;
            }
            else
            {
                return PostOrden;
            }
        }
        [HttpGet]
        [Route("PreOrder")]
        public IEnumerable<Pelicula> GetPre()
        {
            List<Pelicula> PreOrder = new List<Pelicula>();

            if (Data<Pelicula>.Instance.grado != 0)
            {
                PreOrder = Data<Pelicula>.Instance.temp.PreOrder(Data<Pelicula>.Instance.grado);
                return PreOrder;
            }
            else
            {
                return PreOrder;
            }
        }
    }
}
