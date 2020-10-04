using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CadastroVeiculos.Data;
using CadastroVeiculos.Models;

namespace CadastroVeiculos.Controllers
{
    public class VeiculoController : Controller
    {
        private BancoContext db = new BancoContext();

        public async Task<ActionResult> Index()
        {
            var veiculos = db.Veiculos.Include(v => v.Categoria).Include(v => v.Funcionario);
            return View(await veiculos.ToListAsync());
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veiculo veiculo = await db.Veiculos.FindAsync(id);
            var funcionario = await db.Funcionarios.FindAsync(veiculo.FuncionarioId);
            var categoria = await db.Categorias.FindAsync(veiculo.CategoriaId);

            veiculo.Funcionario = funcionario;
            veiculo.Categoria = categoria;

            if (veiculo == null)
            {
                return HttpNotFound();
            }
            return View(veiculo);
        }

        public ActionResult Create()
        {
            ViewBag.Categoria = new SelectList(db.Categorias, "Id", "Descricao");
            ViewBag.Funcionario = new SelectList(db.Funcionarios, "Id", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Placa,Frota,Ano,DataAquisicao,FuncionarioId,CategoriaId")] Veiculo veiculo)
        {
            var placa = db.Veiculos.Where(v => v.Placa == veiculo.Placa).ToList();
            var frota = db.Veiculos.Where(v => v.Frota == veiculo.Frota).ToList();

            if (placa.Count > 0) ModelState.AddModelError("Placa", "Placa já cadastrada!");
            if (frota.Count > 0) ModelState.AddModelError("Frota", "Frota já cadastrada!");

            if (ModelState.IsValid)
            {
                db.Veiculos.Add(veiculo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Categoria = new SelectList(db.Categorias, "Id", "Descricao", veiculo.CategoriaId);
            ViewBag.Funcionario = new SelectList(db.Funcionarios, "Id", "Nome", veiculo.FuncionarioId);
            return View(veiculo);
        }

        // GET: Veiculo/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veiculo veiculo = await db.Veiculos.FindAsync(id);

            if (veiculo == null)
            {
                return HttpNotFound();
            }
            ViewBag.Categoria = new SelectList(db.Categorias, "Id", "Descricao", veiculo.CategoriaId);
            ViewBag.Funcionario = new SelectList(db.Funcionarios, "Id", "Nome", veiculo.FuncionarioId);
            return View(veiculo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Placa,Frota,Ano,DataAquisicao,FuncionarioId,CategoriaId")] Veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(veiculo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Categoria = new SelectList(db.Categorias, "Id", "Descricao", veiculo.CategoriaId);
            ViewBag.Funcionario = new SelectList(db.Funcionarios, "Id", "Nome", veiculo.FuncionarioId);
            return View(veiculo);
        }

        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            Veiculo veiculo = await db.Veiculos.FindAsync(id);
            var funcionario = await db.Funcionarios.FindAsync(veiculo.FuncionarioId);
            var categoria = await db.Categorias.FindAsync(veiculo.CategoriaId);
                        veiculo.Funcionario = funcionario;
            veiculo.Categoria = categoria;
            
            if (veiculo == null) return HttpNotFound();
            return View(veiculo);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Veiculo veiculo = await db.Veiculos.FindAsync(id);
            db.Veiculos.Remove(veiculo);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
