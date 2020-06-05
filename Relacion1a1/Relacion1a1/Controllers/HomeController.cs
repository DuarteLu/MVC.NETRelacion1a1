using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Relacion1a1.Datos;


namespace Relacion1a1.Controllers
{
    public class HomeController : Controller
    {
        Relacion1a1Entities ctx;

         public HomeController()
        {
              ctx = new Relacion1a1Entities();

        }
        public ActionResult Index()
        {
            var Empleado = new Empleado();
            Crear();

            var idEmpleado = 1;
            AgregaDireccionAEmpleado(idEmpleado);

            return View();
        }
        //Crea solo el empleado sin direccion
        public void Crear()
        {
            Empleado emp = new Empleado() { Nombre = "Pepito" };

            ctx.Empleado.Add(emp);
            ctx.SaveChanges();
        }


        //Si arranco por la tabla empleados
        public void CrearDesdeEmpleado()
        {
            Empleado em = new Empleado();
            em.Nombre = "Ignacio";
            Direccion dir = new Direccion();
            dir.Calle = "Calle Arbitraria";
            em.Direccion = dir;
            ctx.Empleado.Add(em);//debido a que creo los dos al mismo tiempo tengo que agregarlos al contexto
            ctx.SaveChanges();

        }
        //Si arranco desde la tabla direccion
        public void CrearDesdeDireccion()
        {
            Empleado em = new Empleado();
            em.Nombre = "Juancito";
            Direccion dir = new Direccion();
            dir.Calle = "Calle Arbitraria ";
            dir.Empleado = em;
            ctx.Direccion.Add(dir);
            ctx.SaveChanges();

        }

        //Guarda direccion a un cliente que ya existe
        //Agrega una direccion desde la tabla empleado
        //La direccion debe existir porque sino me daria error
        public void AgregaDireccionAEmpleado1(int idEmpleado)
        {
            var Em = ctx.Empleado.Find(idEmpleado);
            if (Em.Direccion != null)
            {
                Em.Direccion.Calle = "Modificada";
            }
            else
            {
                Direccion dir = new Direccion();
                dir.Calle = "Calle Arbitraria ";
                Em.Direccion = dir;
                //no hace falta que se haga el add a la direccion. Porque el cliente ya existe,lo conoce, y por su relacion 1a1
                ctx.SaveChanges();
            }
        }
        //Guarda direccion a un cliente que ya existe 
        //agrega una direccion desde la tabla direccion
        //agrega una direccion desde la tabla Direccion.Y es por esto que debo indicar que lo agrego al contexto
        public void AgregaDireccionAEmpleado2(int idEmpleado)
        {
            Direccion dir = new Direccion();
            dir.Empleado = ctx.Empleado.Find(idEmpleado);
            dir.Calle = "Calle arbitraria";
            ctx.Direccion.Add(dir);
            ctx.SaveChanges();
        }
        //Guarda una direccion a un cliente que ya existe(Modelo de parcial)
        //agrega una direccion desde la tabla Direccion.Y es por esto que debo indicar que lo agrego al contexto
        //ctx.Direccion.Add(dir);
        public void AgregaDireccionAEmpleado3(int idEmpleado)
        {
            Direccion dir = new Direccion()
            {
                Calle = "Calle Arbitraria",
            };
             
            dir.Empleado =  ctx.Empleado.Find(idEmpleado);
            ctx.Direccion.Add(dir);
            ctx.SaveChanges();
           
        }


}
}