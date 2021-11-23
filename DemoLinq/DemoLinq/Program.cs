/*
Nome: Laidone Mendes de Carvalho
Laboratório 11
*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoLinq
{
   internal class Program
   {
      static void Main(string[] args)
      {
         List<Pessoa> pessoas = new List<Pessoa>
         {
            new Pessoa{Nome="Ana", DataNascimento=new DateTime(1980,3,14), Casada=true},
            new Pessoa{Nome="Paulo", DataNascimento=new DateTime(1978,10,23), Casada=false},
            new Pessoa{Nome="Ana Maria", DataNascimento=new DateTime(1980,3,14), Casada=false},
            new Pessoa{Nome="Carlos", DataNascimento=new DateTime(1999,12,12), Casada=true},
            new Pessoa{Nome="Pedro", DataNascimento=new DateTime(1970,5,27), Casada=false},
            new Pessoa{Nome="Huginho", DataNascimento=new DateTime(1970,5,27), Casada=true},
            new Pessoa{Nome="Zezinho", DataNascimento=new DateTime(1980,3,17), Casada=false},
            new Pessoa{Nome="Luizinho", DataNascimento=new DateTime(1990,7,7), Casada=false}
         };

         //Consulta tradiconal
         List<Pessoa> resultado1 = new List<Pessoa>();
         foreach (Pessoa p in pessoas)
         {
            if (p.Casada)
               resultado1.Add(p);
         }
         Console.WriteLine("Pessoas casadas, consulta tradiconal:");

         foreach (Pessoa p in resultado1)
         {
            Console.WriteLine(p.Nome);
         }

         //Consulta LINQ
         var resultado2 = (from p in pessoas
                          where p.Casada
                          select p);
         Console.WriteLine("\nPessoas casadas, consulta linq:");

         foreach (Pessoa p in resultado2)
         {
            Console.WriteLine(p.Nome);
         }

         Console.WriteLine("\nPessoas casadas, consulta linq (method syntax):");
         var resultado3 = pessoas.Where(p => p.Casada);

         foreach (Pessoa p in resultado3)
         {
            Console.WriteLine(p.Nome);
         }

         // para obter uma "lista" a partir da consulta linq
         var resultado4 = (from p in pessoas
                           where p.Casada
                           select p).ToList();


         Console.WriteLine("\nPessoas casadas que nasceram após 01/01/1980");
         var resultado5 = (from p in pessoas
                           where p.Casada && p.DataNascimento >= new DateTime(1980, 1, 1)
                           select p).ToList();

         // ups! forçando um pouco a barra...
         resultado5.ForEach(p => Console.WriteLine(p));

         Console.WriteLine("\nProjeção sobre o nome das pessoas casadas");
         var resultado6 = from p in pessoas
                          where p.Casada
                          select p.Nome;

         foreach (String s in resultado6)
         {
            Console.WriteLine(s);
         }

         Console.WriteLine("\nSoteiros em uma lista de objetos anonimos..");
         var resultado7 = (from p in pessoas
                           where !p.Casada
                           select new { p.Nome, p.DataNascimento }).ToList();

         foreach (var elem in resultado7)
         {
            Console.WriteLine(elem.Nome + " " + elem.DataNascimento);
         }

         Console.WriteLine("\nPessoas agrupadas pelo estado civil");
         var resultado8 = from p in pessoas
                          group p by p.Casada;
         foreach (var g in resultado8)
         {
            Console.WriteLine($"casado:{g.Key}");
            foreach (var p in g)
            {
               Console.WriteLine(p);
            }
         }

         Console.WriteLine("\nPessoa mais nova");
         var resultado9 = pessoas.Min(p => p.DataNascimento);
         //Console.WriteLine("Consulta 9:");
         //Console.WriteLine(resultado9);

         var resultado10 = (from p in pessoas
                            where p.DataNascimento == resultado9
                            select p.Nome).ToList();

         resultado10.ForEach(x => Console.WriteLine(x));

         //Pessoas agrupadas pelo mês de nascimento em ordem crescente de mês em ordem crescente
         Console.WriteLine("Pessoas agrupadas pelo mês de nascimento");
         var resultado11 = (from p in pessoas 
                           orderby p.DataNascimento.Month
                           group p by p.DataNascimento.Month);
                           
          foreach (var g in resultado11)
         {
            Console.WriteLine($"Mês de nascimento:{g.Key}");
            foreach (var p in g){
               Console.WriteLine(p);
            }
         }
         
         //Número de pessoas que fazem aniversário em cada mês da semana
         int janeiro = (from p in pessoas
                        where p.DataNascimento.Month == 1
                        select p.Nome).Count();
         System.Console.WriteLine("Pessoas que fazem aniversário em outubro é " + janeiro);

         int fevereiro = (from p in pessoas
                        where p.DataNascimento.Month == 2
                        select p.Nome).Count();
         System.Console.WriteLine("Pessoas que fazem aniversário em fevereiro é " + fevereiro);

         int marco = (from p in pessoas
                        where p.DataNascimento.Month == 3
                        select p.Nome).Count();
         System.Console.WriteLine("Pessoas que fazem aniversário em marco é " + marco);

         int abril = (from p in pessoas
                        where p.DataNascimento.Month == 4
                        select p.Nome).Count();
         System.Console.WriteLine("Pessoas que fazem aniversário em abril é " + abril);

         int maio = (from p in pessoas
                        where p.DataNascimento.Month == 5
                        select p.Nome).Count();
         System.Console.WriteLine("Pessoas que fazem aniversário em maio é " + maio);

         int junho = (from p in pessoas
                        where p.DataNascimento.Month == 6
                        select p.Nome).Count();
         System.Console.WriteLine("Pessoas que fazem aniversário em junho é " + junho);

         int julho = (from p in pessoas
                        where p.DataNascimento.Month == 7
                        select p.Nome).Count();
         System.Console.WriteLine("Pessoas que fazem aniversário em julho é " + julho);

         int agosto = (from p in pessoas
                        where p.DataNascimento.Month == 8
                        select p.Nome).Count();
         System.Console.WriteLine("Pessoas que fazem aniversário em agosto é " + agosto);

         int setembro = (from p in pessoas
                        where p.DataNascimento.Month == 9
                        select p.Nome).Count();
         System.Console.WriteLine("Pessoas que fazem aniversário em setembro é " + setembro);

         int outubro = (from p in pessoas
                        where p.DataNascimento.Month == 10
                        select p.Nome).Count();
         System.Console.WriteLine("Pessoas que fazem aniversário em outubro é " + outubro);

         int novembro = (from p in pessoas
                        where p.DataNascimento.Month == 11
                        select p.Nome).Count();
         System.Console.WriteLine("Pessoas que fazem aniversário em novembro é " + novembro);

         int dezembro = (from p in pessoas
                        where p.DataNascimento.Month == 12
                        select p.Nome).Count();
         System.Console.WriteLine("Pessoas que fazem aniversário em dezembro é " + dezembro);
         
         System.Console.WriteLine("\nPessoa mais velha");
         var resultado12 = pessoas.Min(p => p.DataNascimento);
         var resultado13 = (from p in pessoas
                           where p.DataNascimento == resultado12
                           select p.Nome).ToList();
         int c = resultado13.Count;

         foreach(var p in resultado13)
         {
            System.Console.WriteLine(p);
         }

         System.Console.WriteLine("\nPessoa solteira mais nova");
         //var resultado14 = pessoas.Max(p => p.DataNascimento);
         //Pessoa solteira mais nova
          var resultado14 = (from p in pessoas
                           where !p.Casada
                           select p).ToList();
         var resultado15 = (from p in resultado14
                           where p.DataNascimento == resultado14.Max(p => p.DataNascimento)
                           select p.Nome).ToList();
          foreach(var p in resultado15)
          {
             System.Console.WriteLine(p);
          }
         //Idade média das pessoas em anos
         var resultado16 = (from p in pessoas
                           select p.DataNascimento.Year).ToList();
         int soma = 0;
         int cont = 0;
         double media;              
         foreach (var p in resultado16)
         {
            soma = soma + p;
            ++cont;
         }
         media = soma/cont;
         System.Console.WriteLine("Média dos anos das pessoas " + media);

         Console.ReadLine();
      }
   }
}