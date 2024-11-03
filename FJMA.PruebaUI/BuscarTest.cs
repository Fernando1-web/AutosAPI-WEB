using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace FJMA.PruebaUI
{
    [TestClass]
    public class BuscarTest
    {
        private IWebDriver driver;

        public BuscarTest()
        {
            driver = new ChromeDriver();   
        }

        [TestMethod]
        public void MVC()
        {
            // Navega a Google
            driver.Navigate().GoToUrl("https://localhost:7275/Autos");//Este es el link de la lista de registros

            // Espera un momento para que se carguen los resultados
            System.Threading.Thread.Sleep(1000);

            // Encuentra el cuadro de búsqueda
            var btn = driver.FindElement(By.Name("crear"));

            btn.Click();

            // Espera un momento para que se carguen los resultados
            System.Threading.Thread.Sleep(1000);

            var marca = driver.FindElement(By.Id("Marca"));//Busca al input con el nombre "Marca" 

            marca.SendKeys("Ferrari");//"Ferrari es con lo que va a rellenar ese input

            var modelo = driver.FindElement(By.Id("Modelo"));//Asi pasa con este

            modelo.SendKeys("F-XX");//Este es el modelo a ingresar

            var anno = driver.FindElement(By.Id("Year"));

            anno.SendKeys("2023");

            var precio = driver.FindElement(By.Id("Precio"));

            precio.SendKeys("9999");

            var guardar = driver.FindElement(By.Name("subir"));//Este guarda el registro

            guardar.Click();

            // Espera un momento para que se carguen los resultados
            System.Threading.Thread.Sleep(1000);

            var regresar = driver.FindElement(By.Name("regresar"));//este funciona después de haber completado el registro

            regresar.Click();//evento que activa el boton

            // Espera un momento para que se carguen los resultados
            System.Threading.Thread.Sleep(1000);

        }

        public void Dispose()
        {
            // Cierra el navegador
            driver.Quit();
        }
    }
}

//Eso fue todo, gracias por la atencion prestada