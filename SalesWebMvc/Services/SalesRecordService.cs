﻿using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Services
{
    public class SalesRecordService
    {
        //o readonly eh pra ter certeza que este atributo nao sera alterado
        private readonly SalesWebMvcContext _context;

        public SalesRecordService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            //a declaracao da consulta abaixo ainda nao eh executada
            var result = from obj in _context.SalesRecord select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }
            //aqui executa a consulta de fato
            return await result
                .Include(x => x.Seller) //join com a tabela de Seller 
                .Include(x => x.Seller.Department) // join com a tabela de Department
                .OrderByDescending(x => x.Date)
                .ToListAsync();


        }
    }
}