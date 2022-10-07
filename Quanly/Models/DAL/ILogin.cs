using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Quanly.Models.DTO;

namespace Quanly.Models.DAL
{
    public interface ILogin
    {
        int loginAcc(Login login);
    }
}

