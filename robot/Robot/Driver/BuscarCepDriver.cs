using EasyAutomationFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
            this.StartBrowser();
        }

        public EasyReturn.Web StartBrowser(TypeDriver typeDriver = TypeDriver.GoogleChorme, string pathCache = null)
        {
            try
            {
                switch (typeDriver)
                {
                    case TypeDriver.GoogleChorme:
                        {
                            var sc = ChromeDriverService.CreateDefaultService();
                            sc.HideCommandPromptWindow = true;
                            ChromeOptions c = new ChromeOptions();
                            c.AddArgument("--start-maximized");
                            c.AddArgument("--user-data-dir=~/.config/google-chrome");
                            c.AddArgument("--headless");
                            c.AddArgument("--no-sandbox");
                            c.AddArgument("--disable-gpu");
                            c.AddArgument("--ddisable-dev-shm-usage");
                            driver = new ChromeDriver(sc, c);
                            break;
                        }
                }

                return new EasyReturn.Web
                {
                    driver = driver,
                    Sucesso = true
                };
            }
            catch (Exception ex)
            {
                return new EasyReturn.Web
                {
                    driver = driver,
                    Sucesso = false,
                    Error = ex.Message.ToString()
                };
            }
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
