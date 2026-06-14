using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GerenciadorCartoes.Data;
using GerenciadorCartoes.Models;

namespace GerenciadorCartoes.Controllers
{
    public class CartaoController : Controller
    {
        private readonly ApplicationDbContext _context;

        // Injeção de Dependência: O ASP.NET fornece o contexto do banco automaticamente aqui
        public CartaoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // 1. READ (Listagem) - GET: /Cartao
        public async Task<IActionResult> Index()
        {
            // Busca todos os cartões do banco de dados de forma assíncrona
            var cartoes = await _context.Cartoes.ToListAsync();
            return View(cartoes);
        }

        // 2. CREATE (Tela de Cadastro) - GET: /Cartao/Create
        public IActionResult Create()
        {
            return View();
        }

        // 2. CREATE (Ação de Salvar) - POST: /Cartao/Create
        [HttpPost]
        [ValidateAntiForgeryToken] // Proteção contra ataques CSRF (segurança)
        public async Task<IActionResult> Create([Bind("NomeTitular,NumeroCartao,DataValidade,Cvv")] Cartao cartao)
        {
            // Verifica se as validações da Model (como tamanho do CVV, campos obrigatórios) são válidas
            if (ModelState.IsValid)
            {
                _context.Add(cartao);
                await _context.SaveChangesAsync(); // Salva de fato no SQL Server
                return RedirectToAction(nameof(Index)); // Volta para a listagem
            }
            // Se houver erro de validação, reexibe a tela com os erros
            return View(cartao);
        }

        // 3. UPDATE (Tela de Edição) - GET: /Cartao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var cartao = await _context.Cartoes.FindAsync(id);
            if (cartao == null) return NotFound();

            return View(cartao);
        }

        // 3. UPDATE (Ação de Salvar Alteração) - POST: /Cartao/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeTitular,NumeroCartao,DataValidade,Cvv")] Cartao cartao)
        {
            if (id != cartao.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cartao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartaoExists(cartao.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cartao);
        }

        // 4. DELETE (Tela de Confirmação) - GET: /Cartao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var cartao = await _context.Cartoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cartao == null) return NotFound();

            return View(cartao);
        }

        // 4. DELETE (Confirmação do Clique) - POST: /Cartao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cartao = await _context.Cartoes.FindAsync(id);
            if (cartao != null)
            {
                _context.Cartoes.Remove(cartao);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        // Método auxiliar para checar se o cartão existe
        private bool CartaoExists(int id)
        {
            return _context.Cartoes.Any(e => e.Id == id);
        }
    }
}