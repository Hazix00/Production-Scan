﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProdScan
{
    class UserProd
    {
        public string Name { get; set; }
        public string BANQUE { get; set; }
        public string Client { get; set; }
        public string FOURNISSEUR { get; set; }
        public string SCAN { get; set; }
        public string CAISSE { get; set; }
        public string Total { get; set; }

        public UserProd()
        {
            
        }
        public void calculTotal()
        {
            var valB  = getNumberOfDocsWithPages(BANQUE);
            var valC  = getNumberOfDocsWithPages(Client);
            var valF  = getNumberOfDocsWithPages(FOURNISSEUR);
            var valS  = getNumberOfDocsWithPages(SCAN);
            var valCs = getNumberOfDocsWithPages(CAISSE);
            var totalDocs = valB[0] + valC[0] + valF[0] + valS[0];
            var TotalPages = valB[1] + valC[1] + valF[1] + valS[1];

            Total = $"{totalDocs};{TotalPages}";
            foreach (PropertyInfo property in typeof(UserProd).GetProperties())
            {
                var value = property.GetValue(this).ToString().Replace(";", "  ");
                property.SetValue(this, value);
            }
        }

        private int[] getNumberOfDocsWithPages(string prg)
        {
            if (prg == "0" || prg == "")
                return new int[] { 0, 0 };
            
            return Array.ConvertAll( prg.Split(';'),int.Parse);
        }
    }
}
