using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace Quanly.Models.DTO
{
    public class Hanghoa
    {
        public string MaMH    {get; set;}
        public string TenMH   {get; set;}
        public string Xuatxu  {get; set;}
        public int Gianhap {get; set;}
        public int Giaban  {get; set;}
        public string NSX     {get; set;}
        public string HSD     {get; set;}
        public int Soluong {get; set;}
        public int Conlai { get; set; }
    }
}

