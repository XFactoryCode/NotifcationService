using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NotificacaoService.Domain.Templates
{
    public interface ITemplateRepository
    {
        Task<Template> GetAsyncBy(Expression<Func<Template, bool>> predicate);
    }
}
