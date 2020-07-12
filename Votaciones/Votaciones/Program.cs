using System;
using System.Security.Cryptography.X509Certificates;
using System.Linq;

namespace Votaciones
{
    struct candidatos
    {
        public string Nombre;
        public string posicion;
        public string Partido;
    }
    struct partidos
    {
        public string FechFund;
        public string PartNombre;
        public string siglas;
        public int votes;
        public int pos;

    }
    class Program
    {



        static void Main(string[] args)
        {
            partidos[] fecha_fund = new partidos[4];
            partidos[] nombre_part = new partidos[4];
            partidos[] siglas_part = new partidos[4];
            partidos[] vote = new partidos[4];
            partidos[] posicion = new partidos[4];

            candidatos[] nombreCand = new candidatos[4];
            candidatos[] posicionCand = new candidatos[4];
            candidatos[] partidoCand = new candidatos[4];
            //1
            fecha_fund[0].FechFund = "12 de septiembre del 2008";
            nombre_part[0].PartNombre = "Partido Gallo";
            siglas_part[0].siglas = "PG";
            vote[0].votes = 0;

            nombreCand[0].Nombre = "Jorge Emilio Gaviria Perez";
            posicionCand[0].posicion = "Presidente";
            partidoCand[0].Partido = "PG";
            //2
            fecha_fund[1].FechFund = "18 de octubre del 2001";
            nombre_part[1].PartNombre = "Partido Delfines Arriba ";
            siglas_part[1].siglas = "PDA";
            vote[1].votes = 0;

            nombreCand[1].Nombre = "Abel Ino Garcias Perez";
            posicionCand[1].posicion = "Presidente";
            partidoCand[1].Partido = "PDA";
            //3
            fecha_fund[2].FechFund = "12 de enero del 1998";
            nombre_part[2].PartNombre = "Partido Tiburon";
            siglas_part[2].siglas = "PT";
            vote[2].votes = 0;

            nombreCand[2].Nombre = "Carlos Jose Quintana Hernandez";
            posicionCand[2].posicion = "Presidente";
            partidoCand[2].Partido = "PT";
            //4
            fecha_fund[3].FechFund = "28 de julio del 2011";
            nombre_part[3].PartNombre = "Partido Alacran ";
            siglas_part[3].siglas = "PA";
            vote[3].votes = 0;

            nombreCand[3].Nombre = "Jose Emilio Castro Perez";
            posicionCand[3].posicion = "Presidente";
            partidoCand[3].Partido = "PA";

            do
            {
                Random rnd = new Random();
                int rand = rnd.Next(0, 1000);
                if (rand <= 500 && rand % 2 == 0) { vote[0].votes = vote[0].votes + 1; }
                if (rand > 500 && rand % 2 == 0) { vote[1].votes = vote[1].votes + 1; }
                if (rand <= 500 && rand % 2 != 0) { vote[2].votes = vote[2].votes + 1; }
                if (rand > 500 && rand % 2 != 0) { vote[3].votes = vote[3].votes + 1; }
            } while ((vote[0].votes + vote[1].votes + vote[2].votes + vote[3].votes) < 1000);
            Console.WriteLine("--Partidos Aspirantes--");
            for (int i = 0; i <= 3; i++)
            {

                Console.WriteLine("Partido numero {0}", i + 1);

                Console.WriteLine("Nombre del partido: {0}", nombre_part[i].PartNombre);
                Console.WriteLine("Siglas del partido: {0}", siglas_part[i].siglas);
                Console.WriteLine("Fecha de fundacion del partido: {0}", fecha_fund[i].FechFund);
                Console.WriteLine("Candidato del partido: {0}", nombreCand[i].Nombre);
                Console.WriteLine("Cantidad de votos: " + vote[i].votes + " Votos.");
                Console.WriteLine("");

            }
            Console.WriteLine("------------");
            Console.WriteLine("Porcentaje de Votos por partido en orden descendente. ");
            Console.WriteLine(" ");
            int mayor = vote[0].votes;
            int menor = mayor;
            posicion[0].pos = 0;
            posicion[3].pos = 0;
            for (int i = 1; i <= 3; i++)
            {
                if (vote[i].votes >= mayor)
                {
                    mayor = vote[i].votes;
                    posicion[0].pos = i;
                }
                else
                {
                    if (vote[i].votes <= menor)
                    {
                        menor = vote[i].votes;
                        posicion[3].pos = i;
                    }
                }
            }
            mayor = 0;
            menor = 0;
            posicion[1].pos = -1;
            posicion[2].pos = -1;
            for (int j = 0; j <= 3; j++)
            {
                if (j != posicion[0].pos && j != posicion[3].pos)
                {
                    if (vote[j].votes >= mayor)
                    {
                        mayor = vote[j].votes;
                        posicion[1].pos = j;
                    }
                    else
                    {
                        menor = vote[j].votes;
                        posicion[2].pos = j;
                    }
                }
            }
            if (posicion[2].pos == -1) 
            {
                for (int a = 0;a <= 3;a++) 
                {
                    if (a != posicion[0].pos && a != posicion[3].pos && a != posicion[1].pos) 
                    {
                        posicion[2].pos = a;
                    }
                }

            }
            for(int k = 0; k <= 3; k++)
            {
                Console.WriteLine(nombre_part[posicion[k].pos].PartNombre);
                Console.WriteLine("Cantidad de votos: " + vote[posicion[k].pos].votes + " Votos.");
                 double porcentaje = (vote[posicion[k].pos].votes * 1000) * 0.0001;
                Console.WriteLine(porcentaje + "%");
                Console.WriteLine("------------");
            }
            int suma = vote[0].votes + vote[1].votes + vote[2].votes + vote[3].votes;
            Console.WriteLine("Cantidad de votos sumados: {0}", suma);           
        }
    }
}
