using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Razor;

namespace DevMarcos.UI.Site.Extensions
{
    /// <summary>
    /// Classe com metodos de validações das claims dentro da razor pages 
    /// </summary>
    public static class RazorExtensions
    {
        /// <summary>
        /// Metodo de extensão  para validar uma determinada claim dentro da pagina razor (View Razor)
        /// </summary>
        /// <param name="page">Nome da pagina</param>
        /// <param name="claimName">Nome da Claim</param>
        /// <param name="claimValue">Valor da Claim</param>
        /// <returns></returns>
        public static bool IfClaim(this RazorPage page, string claimName, string claimValue)
        {
            return CustomAuthorization.ValidarClaimsUsuario(page.Context, claimName, claimValue);
        }

        /// <summary>
        /// Metodo de extensão para validar uma claim desabilitando um botão por exemplo caso o usuário não tenha acesso
        /// </summary>
        /// <param name="page">Nome da pagina</param>
        /// <param name="claimName">Nome da Claim</param>
        /// <param name="claimValue">Valor da Claim</param>
        /// <returns></returns>
        public static string IfClaimShow(this RazorPage page, string claimName, string claimValue)
        {
            return CustomAuthorization.ValidarClaimsUsuario(page.Context, claimName, claimValue) ? "" : "disabled";
        }

        /// <summary>
        /// Metodo de extensão para validar uma claim e removendo um link caso o usuário não possa acessar 
        /// </summary>
        /// <param name="page">Nome da pagina</param>
        /// <param name="context">Contexto da aplicação </param>
        /// <param name="claimName">Nome da Claim</param>
        /// <param name="claimValue">Valor da Claim</param>
        /// <returns></returns>
        public static IHtmlContent IfClaimShow(this IHtmlContent page, HttpContext context, string claimName, string claimValue)
        {
            return CustomAuthorization.ValidarClaimsUsuario(context, claimName, claimValue) ? page : null;
        }
    }
}