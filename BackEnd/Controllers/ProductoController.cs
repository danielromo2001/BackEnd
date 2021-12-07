using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Models;
using BackEnd.Models.Response;
using BackEnd.Models.Request;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() {
            Respuesta respuesta = new Respuesta();
            respuesta.Win = 0;  
            try
            { 
                using (BoutiqueContext db = new BoutiqueContext())
                {
                    var lst = db.Producto.ToList();
                    respuesta.Win = 1;
                    respuesta.Data = lst;
                }
            } catch(Exception e)
            {
                respuesta.Mensaje = e.Message;
            }
            return Ok(respuesta);
        }

        [HttpPost]
        public IActionResult Add(ProductoRequest model){
            Respuesta respuesta = new Respuesta();
            respuesta.Win = 0;
            try
            {
                using (BoutiqueContext db = new BoutiqueContext()) {

                    Producto producto = new Producto();
                    producto.Id = model.Id;
                    producto.Descripcion = model.Descripcion;
                    producto.Cantidad = model.Cantidad;
                    producto.Costo = model.Costo;
                    db.Producto.Add(producto);
                    db.SaveChanges();
                    respuesta.Win = 1;
                }
                
            }
            catch (Exception e)
            {
                respuesta.Mensaje = e.Message;
            }

            return Ok(respuesta);
        }

        [HttpPut]
        public IActionResult Edit(ProductoRequest model)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.Win = 0;
            try
            {
                using (BoutiqueContext db = new BoutiqueContext())
                {

                    Producto producto = db.Producto.Find(model.Id);
                    producto.Descripcion = model.Descripcion;
                    producto.Cantidad = model.Cantidad;
                    producto.Costo = model.Costo;
                    db.Entry(producto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    respuesta.Win = 1;
                }

            }
            catch (Exception e)
            {
                respuesta.Mensaje = e.Message;
            }

            return Ok(respuesta);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.Win = 0;
            try
            {
                using (BoutiqueContext db = new BoutiqueContext())
                {

                    Producto producto = db.Producto.Find(Id);
                    db.Remove(producto);
                    db.SaveChanges();
                    respuesta.Win = 1;
                }

            }
            catch (Exception e)
            {
                respuesta.Mensaje = e.Message;
            }

            return Ok(respuesta);
        }
    }
}
