using EasyAutomationFramework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot.Driver
{
    public class BuscarCepDriver : Web
    {
        public BuscarCepDriver() 
        {
            StartBrowser();
        }

        public void BuscarCep(EnderecoModel endereco)
        {
            Navigate("https://buscacepinter.correios.com.br/app/endereco/index.php");

            AssignValue(TypeElement.Id, "endereco", endereco.CEP)
                .element.SendKeys(Keys.Enter);

            Thread.Sleep(1000);

            var result = GetTableData(TypeElement.Id, "resultado-DNEC");
            
            foreach (DataRow row in result.table.Rows)
            {
                endereco.Logradouro = row[0].ToString();
                endereco.Bairro = row[1].ToString();
                endereco.UF = row[2].ToString();
            }
        }
    }
}
