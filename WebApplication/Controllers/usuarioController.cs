using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using WebApplication.Models.viewModels;

namespace WebApplication.Controllers
{
    public class usuarioController : Controller
    {
        // GET: usuario
        public ActionResult Index()
        {
            List<listUsuarioViewModel> lst;
            using (personaEntities db = new personaEntities())
            {
                lst = (from d in db.usuario
                            select new listUsuarioViewModel
                            {
                                id = d.id_usuario,
                                nombre = d.nombre_usuario,
                                apellido = d.apellido_usuario,
                                fecha_nacimiento = d.fecha_nacimiento.Value,
                                edad = d.edad.Value
                            }).ToList();
            }

            return View(lst);
        }

        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(TablaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (personaEntities db = new personaEntities())
                    {
                        var obTabla = new usuario();
                        obTabla.id_usuario = model.id;
                        obTabla.nombre_usuario = model.nombre;
                        obTabla.apellido_usuario = model.apellido;
                        obTabla.fecha_nacimiento = model.fecha_nacimiento;
                        obTabla.edad = model.edad;

                        db.usuario.Add(obTabla);
                        db.SaveChanges();
                    }
                    return Redirect("~/usuario/");
                }
                return View(model);
            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public ActionResult Editar(int id)
        {
            TablaViewModel model = new TablaViewModel();
            using (personaEntities db = new personaEntities())
            {
                var obTabla = db.usuario.Find(id);
                model.nombre = obTabla.nombre_usuario;
                model.apellido = obTabla.apellido_usuario;
                model.fecha_nacimiento = obTabla.fecha_nacimiento.Value;
                model.edad = obTabla.edad.Value;
                model.id = obTabla.id_usuario;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(TablaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (personaEntities db = new personaEntities())
                    {
                        var obTabla = db.usuario.Find(model.id);
                        obTabla.id_usuario = model.id;
                        obTabla.nombre_usuario = model.nombre;
                        obTabla.apellido_usuario = model.apellido;
                        obTabla.fecha_nacimiento = model.fecha_nacimiento;
                        obTabla.edad = model.edad;

                        db.Entry(obTabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/usuario/");
                }
                return View(model);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            using (personaEntities db = new personaEntities())
            {
                
                var obTabla = db.usuario.Find(id);
                db.usuario.Remove(obTabla);
                db.SaveChanges();
            }
            return Redirect("~/usuario/");
        }
    }
}