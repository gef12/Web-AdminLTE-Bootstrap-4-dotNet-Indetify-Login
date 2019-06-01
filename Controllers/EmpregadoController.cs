using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web_AdminLTE_Bootstrap_4_dotNet_Indetify.Data;
using Web_AdminLTE_Bootstrap_4_dotNet_Indetify.Models;

namespace Web_AdminLTE_Bootstrap_4_dotNet_Indetify.Controllers
{
    [Authorize]
    public class EmpregadoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmpregadoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Empregado
        public async Task<IActionResult> Index()
        {
            if (User.IsInRole("Admin"))
            {
                return View(await _context.Empregado.ToListAsync());
            }
            else
            {
                return View("ReadOnly", await _context.Empregado.ToListAsync());
            }
                
        }

        // GET: Empregado/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empregado = await _context.Empregado
                .FirstOrDefaultAsync(m => m.EmpregadoId == id);
            if (empregado == null)
            {
                return NotFound();
            }

            return View(empregado);
        }

        [Authorize(Roles = "Admin")]
        // GET: Empregado/Create
        public IActionResult AddOrEdit(int id=0)
        {
            //testando se e para inserir ou editar
            if(id == 0 )
                return View(new Empregado());
            else
                return View(_context.Empregado.Find(id));

        }

        [Authorize(Roles = "Admin")]
        // POST: Empregado/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("EmpregadoId,NameCompleto,EmpCode,Posicao,LocalizacaoTrabalho")] Empregado empregado)
        {
            if (ModelState.IsValid)
            {
                //verificando se e para salvar ou atualizar os dados
                if(empregado.EmpregadoId == 0)
                    _context.Add(empregado);
                else
                    _context.Update(empregado);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(empregado);
        }

        [Authorize(Roles = "Admin")]
        // GET: Empregado/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empregado = await _context.Empregado.FindAsync(id);
            if (empregado == null)
            {
                return NotFound();
            }
            return View(empregado);
        }

        [Authorize(Roles = "Admin")]
        // POST: Empregado/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmpregadoId,NameCompleto,EmpCode,Posicao,LocalizacaoTrabalho")] Empregado empregado)
        {
            if (id != empregado.EmpregadoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empregado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpregadoExists(empregado.EmpregadoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(empregado);
        }

        [Authorize(Roles = "Admin")]
        // GET: Empregado/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var empregado = await _context.Empregado.FindAsync(id);
            _context.Empregado.Remove(empregado);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
            /*
             * metodo antigo para deletar enviando para outra pagina mostrando os dados antes de deletar*
            if (id == null)
            {
                return NotFound();
            }

            var empregado = await _context.Empregado
                .FirstOrDefaultAsync(m => m.EmpregadoId == id);
            if (empregado == null)
            {
                return NotFound();
            }

            return View(empregado);
            */
        }

        [Authorize(Roles = "Admin")]
        // POST: Empregado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empregado = await _context.Empregado.FindAsync(id);
            _context.Empregado.Remove(empregado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpregadoExists(int id)
        {
            return _context.Empregado.Any(e => e.EmpregadoId == id);
        }
    }
}
