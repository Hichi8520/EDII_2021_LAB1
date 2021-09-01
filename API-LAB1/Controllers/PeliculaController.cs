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
using Newtonsoft.Json;

namespace API_LAB1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculaController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            string mensaje = "Laboratorio 1 - Inicio Exitoso...\n * Cree su arbol - Mande un numero para crear el grado del arbol \n * Elimine el árbol existente \n * Mande sus inserciones desde postman por medio de una lista de peliculas agregando a la ruta '/populate' o enviando un archivo .json a la ruta '/populatefile' \n * Verifique la información por medio de modificar la url con los recorridos /InOrder  /PostOrder /PreOrder \n * Elimine un valor del árbol enviando el título de la película en la ruta (usar guión bajo en caso el título tenga espacios)";
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
        public ActionResult DeleteTree()
        {
            if (Data<Pelicula>.Instance.grado != 0)
            {
                Data<Pelicula>.Instance.temp = null;
                Data<Pelicula>.Instance.grado = 0;
                return Ok("Árbol eliminado exitosamente");
            }
            else return BadRequest("No existe el árbol a eliminar");
        }

        // Delete a movie from the tree
        [HttpDelete]
        [Route("populate/{*id}")]
        public IActionResult DeleteMovie(string id)
        {
            try
            {
                string titulo = id.Replace("_", " ");

                return Ok(titulo);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            
        }

        // Insert values from json body to the tree
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

        // Insert values from json file to the tree
        [HttpPost]
        [Route("populatefile")]
        public async Task<IActionResult> Add([FromForm] IFormFile file)
        {
            try
            {
                if (file.Length > 0)
                {
                    if (!Directory.Exists(_env.WebRootPath + "\\PeliculasArbol\\"))
                    {
                        Directory.CreateDirectory(_env.WebRootPath + "\\PeliculasArbol\\");
                    }
                    using (FileStream fileStream = System.IO.File.Create(_env.WebRootPath + "\\PeliculasArbol\\" + file.FileName))
                    {
                        
                        file.CopyTo(fileStream);
                        fileStream.Flush();
                    }

                    if (insertFile(file)) return Ok();
                    else return BadRequest("Debe de crear su arbol primero");
                }
                else
                {
                    return BadRequest("Archivo vacío");
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        private bool insertFile(IFormFile file)
        {
            using (StreamReader r = new StreamReader(_env.WebRootPath + "\\PeliculasArbol\\" + file.FileName))
            {
                string json = r.ReadToEnd();
                List<Pelicula> peliculas = JsonConvert.DeserializeObject<List<Pelicula>>(json);


                if (Data<Pelicula>.Instance.grado != 0)
                {
                    for (int i = 0; i < peliculas.Count; i++)
                    {
                        Data<Pelicula>.Instance.temp.insertar(peliculas[i]);
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

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
