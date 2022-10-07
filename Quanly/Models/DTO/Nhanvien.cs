using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace Quanly.Models.DTO
{
    public class Nhanvien
    {
        public string user { get; set; }
        public int UserId  {get; set;}
       public string MaNV    {get; set;}
       public string TenNV   {get; set;}
       public int Gioitinh{get; set;}
       public string Ngaysinh{get; set;}
       public string Diachi  {get; set;}
       public string Sdt { get; set; }

    }
}

