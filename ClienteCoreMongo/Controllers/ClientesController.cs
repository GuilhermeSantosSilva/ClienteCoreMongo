using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClienteCoreMongo.Extensions;
using ClienteCoreMongo.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace ClienteCoreMongo.Controllers
{
    public class ClientesController : Controller
    {
        public IActionResult Index()
        {
            MongoDbContext dbContext = new MongoDbContext();
            List<Cliente> listaClientes = dbContext.Clientes.Find(m => true).ToList();
            return View(listaClientes);
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            MongoDbContext dbContext = new MongoDbContext();
            var entity = dbContext.Clientes.Find(m => m.Id == id).FirstOrDefault();
            return View(entity);
        }
        [HttpPost]
        public IActionResult Edit(Cliente entity)
        {
            MongoDbContext dbContext = new MongoDbContext();
            dbContext.Clientes.ReplaceOne(m => m.Id == entity.Id, entity);
            TempData.Put("Success", new Message() { CssClassName = "alert-success", Title = entity.Nome, Text = "alterado com sucesso!" });
            return RedirectToAction("Index", "Clientes");
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Cliente entity)
        {
            MongoDbContext dbContext = new MongoDbContext();
            entity.Id = Guid.NewGuid();
            dbContext.Clientes.InsertOne(entity);
            TempData.Put("Success", new Message() { CssClassName = "alert-success", Title = entity.Nome, Text = "cadastrado com sucesso!" });
            return RedirectToAction("Index", "Clientes");
        }
        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            MongoDbContext dbContext = new MongoDbContext();
            var entity = dbContext.Clientes.Find(m => m.Id == id).FirstOrDefault();
            dbContext.Clientes.DeleteOne(m => m.Id == id);
            TempData.Put("Success", new Message() { CssClassName = "alert-success", Title = entity.Nome, Text = "excluído com sucesso!" });
            return RedirectToAction("Index", "Clientes");
        }
    }
}