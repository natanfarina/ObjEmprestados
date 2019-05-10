using System;
using System.Collections.Generic;
using System.Text;

namespace ObjetosEmprestados.Services
{
   public interface ICaminhoSQLite
    {
        string GetCaminhoDB(string nomeDB);
    }
            
}
