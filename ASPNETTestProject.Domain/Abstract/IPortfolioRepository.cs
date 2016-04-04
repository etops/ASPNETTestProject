using ASPNETTestProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETTestProject.Domain.Abstract
{
    public interface IPortfolioRepository
    {
        IEnumerable<Portfolio> Portfolios { get; }
    }
}
