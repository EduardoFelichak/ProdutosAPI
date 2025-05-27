using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProdutosAPI.Services.Abstract;

namespace ProdutosAPI.Utils
{
    public class BasicAuthAttribute : Attribute, IAsyncActionFilter
    {
        private readonly string _emailHeader;
        private readonly string _senhaHeader;

        public BasicAuthAttribute(string emailHeader = "X-User-Email", string senhaHeader = "X-User-Senha")
        {
            _emailHeader = emailHeader;
            _senhaHeader = senhaHeader;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var usuarioServ = context.HttpContext.RequestServices.GetService<IUsuarioServ>();

            var request = context.HttpContext.Request;

            if (!request.Headers.TryGetValue(_emailHeader, out var email) ||
                !request.Headers.TryGetValue(_senhaHeader, out var senha))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            if (usuarioServ == null)
            {
                throw new Exception("erro OnActionExecutionAsync");
            }

            var usuario = await usuarioServ.LoginAsync(email, senha);

            if (usuario == null)
            {
                context.Result = new UnauthorizedResult();
                return;
            }
               
            await next();
        }
    }
}
