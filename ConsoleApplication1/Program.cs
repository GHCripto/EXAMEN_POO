using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.Entidades;
using ConsoleApplication1.Builder;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int numeroDeCancion = 1;

            // NOMBRE DEL PROYECTO DEL MATERIAL DISCOGRAFICO, PRECIO Y STOCK...
            String nombre;
            Double precio;
            int stock;

            // INFORMACIÓN DEL AUTOR...
            Autor autor;
            String nombreArtista;
            String descripcionArtista;

            // GÉNERO MUSICAL...
            Genero genero;
            String descripcionGenero;

            // TIPO MATERIAL DISCOGRAFICO, YA SEA ALBUM O SENCILLO...
            TipoMaterialDiscografico tipoMaterialDiscografico;
            String nombreMaterialDiscografico;

            // INFORMACIÓN DE LAS CANCIONES, COMO NOMBRE, DURACION...
            List<Cancion> canciones = new List<Cancion>();
            Cancion cancion;
            String nombreCancion;
            int duracionSegundos;

            char respuesta;


            // EN ESTA SECCIÓN, SE PEDIRÁ EL INGRESO DE DATOS ANTERIORMENTE COMENTADOS...
            // MATERIAL DISCOGRAFICO
            Console.Write("Bienvenido :)" + "\nIngrese el nombre del material/proyecto: ");
            nombre = Console.ReadLine();
            Console.Write("Ahora, ingrese el precio del nuevo material: ");
            precio = Convert.ToDouble(Console.ReadLine());
            Console.Write("A continuación, ingrese el stock deseado: ");
            stock = Convert.ToInt32(Console.ReadLine());

            // AUTOR
            Console.Write("Ingrese el nombre del artista: ");
            nombreArtista = Console.ReadLine();
            Console.Write("Ingrese una breve descripcion del artista: ");
            descripcionArtista = Console.ReadLine();
            autor = new Autor(nombreArtista, descripcionArtista);

            // GÉNERO
            Console.Write("Ahora, ingrese el género de la canción: ");
            descripcionGenero = Console.ReadLine();
            genero = new Genero(descripcionGenero);

            // TIPO MATERIAL DISCOGRAFICO
            Console.Write("Ingrese el nombre del tipo de material discografico (Album, Sencillo, etc): ");
            nombreMaterialDiscografico = Console.ReadLine();
            tipoMaterialDiscografico = new TipoMaterialDiscografico(nombreMaterialDiscografico);

            do
            {
                // CANCIONES (NÚMERO DE CANCIONES)
                Console.WriteLine("\nCancion " + numeroDeCancion.ToString());
                Console.Write("Inserte el nombre de la canción: ");
                nombreCancion = Console.ReadLine();
                Console.Write("Agregue una duracion estimada de la cancion en segundos: ");
                duracionSegundos = Convert.ToInt32(Console.ReadLine());

                cancion = new Cancion(nombreCancion, duracionSegundos);
                canciones.Add(cancion);

                numeroDeCancion++;
                
                Console.Write("¿Desea seguir agregando canciones? (S/N): ");
                respuesta = Console.ReadKey().KeyChar;
                Console.ReadKey();

            } while (respuesta == 'S');

            Console.Clear();

            // CONSTRUCTOR/BUILDER MATERIAL DISCOGRAFICO
            MaterialDiscograficoBuilder builderMaterialDiscografico = new MaterialDiscograficoBuilder();
            MaterialDiscografico materialDiscografico = builderMaterialDiscografico
                .ConNombre(nombre)
                .TienePrecio(precio)
                .EnStock(stock)
                .ComoAutor(autor)
                .ComoCanciones(canciones)
                .ComoGenero(genero)
                .ComoTipoMaterialDiscografico(tipoMaterialDiscografico)
                .BuildMaterialDiscografico();

            // REPORTE DE INFORMACIÓN REGISTRADA
            Console.Write(materialDiscografico.reportarDatos());

            Console.ReadKey();
        }
    }
}
