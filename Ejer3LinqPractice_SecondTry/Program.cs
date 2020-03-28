using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejer3LinqPractice_SecondTry
{
    class Program
    {
        
        static void Main(string[] args)
        {
            String baseDato = File.ReadAllText("Cars.json");
            List<Cars> cars = JsonConvert.DeserializeObject<List<Cars>>(baseDato);

        
        }
        static void Ejer2(List<Cars> cars)
        {
            var fabricantes = cars.GroupBy(x => x.Maker).Select(y => y.First());
            foreach(var coches in fabricantes)
            {
                Console.WriteLine("Fabricante: " + coches.Maker);
            }
        }
        static void Ejer3(List<Cars> cars)
        {
            var colores = cars.GroupBy(x => x.Color).Select(z => z.First());
            foreach(var c in colores)
            {
                Console.WriteLine("Color: " + c.Color + " Fabricante: " + c.Maker + " Modelo: " + c.Model);
            }
        }
        static void Ejer4(List<Cars> cars)
        {
            var cochesVerdes = cars.Where(x => x.Color == "Green");
            foreach(var cocje in cochesVerdes)
            {
                Console.WriteLine("fabricante: " + cocje.Maker + "modelo: " + cocje.Model);
            }
        }
        static void Ejer5(List<Cars> cars,double latitud,double longitud)
        {
            var punto = cars.Where(x => x.Latitude == latitud && x.Longitude == longitud);
            foreach(var p in punto)
            {
                if (p.Year == 1920)
                {
                    Console.WriteLine("Este coche si pertenece a 1920");
                }
                else
                {
                    Console.WriteLine("Este coche no pertenece a 1920");
                }

            }

        }
        static void Ejer6(List<Cars> cars)
        {
            var lista = cars.Where(x => x.Year > 2001);
            foreach(var y in lista)
            {
                Console.WriteLine(y.id);
            }
        }
        static void Ejer7(List<Cars> cars)
        {
            var clase = cars.Where(c => c.Location.Latitude == null && c.Location.Longitude == null); 
            foreach(var e in clase)
            {
                Console.WriteLine(e.id);
            }

        }
        static void Ejer8(List<Cars> cars)
        {
            var ej = cars.Where(x => x.Color == "Blue" && x.Year > 2000);
            foreach(var i in ej)
            {
                Console.WriteLine("id: " + i.id);
            }
        }
        static void Ejer9(List<Cars> cars)
        {
            var list = cars.OrderBy(x => x.Year).GroupBy(x => x.Maker);
           
            foreach (var i in list)
            {
                Console.WriteLine("id: " + i);
            }
        }
        static void Ejer10(List<Cars> cars)
        {
            var lista = cars.GroupBy(x => x.Model);
           
            foreach(var i in lista)
            {
                Console.WriteLine(i);
            }
            var listaColor = cars.Select(x => x.Color).First();
            foreach(var lc in listaColor)
            {
                Console.WriteLine(lc);
            }
        }
        static void Ejer11(List<Cars> cars)
        {
            int p = 0;
            var listaCoche = cars.Take(10);
            try
            {
                do
                {
                    foreach(var i in listaCoche)
                    {
                        Console.WriteLine(i);
                    }
                    p += 10;
                    listaCoche = cars.Skip(p).Take(10);
                } while (listaCoche != listaCoche.Last());
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("No hay mas coches en la lista");
            }
        }
        static void Ejer12(List<Cars> cars)
        {
            var e = cars.GroupBy(x => x.Year > 2001 && x.Maker == "Suzuki").Select(s => s.First());
            foreach(var i in e)
            {
                Console.WriteLine(i.id);
            }
        }
        static void Ejer13(List<Cars> cars)
        {
            var lista = cars.Where(x => x.Year != null);
            foreach(var i in lista)
            {
                Console.WriteLine(i);
            }
        }
        static void Ejer14(List<Cars> cars)
        {
            var lista = cars.Count(y=>y.Color=="Pink");
            var listaGeneral = cars.GroupBy(x => x.Year);
            foreach(var i in listaGeneral)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine($"Contador: {lista}");
        }
        static void Ejer15(List<Cars> cars)
        {
            var lista = cars.Where(x => x.Maker == "BMW" && x.Year == null && x.Location.Latitude == null && string.IsNullOrEmpty(x.Color));
            foreach(var i in lista)
            {
                Console.WriteLine(i);
            }
        }
        static void Ejer16(List<Cars> cars,string color,string modelo)
        {
            var lista = cars.Where(x => x.Color == color && x.Model == modelo);
            foreach(var i in lista)
            {
                Console.WriteLine(i);
            }
        }
    }
}
