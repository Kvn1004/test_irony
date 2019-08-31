using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Ast;
using Irony.Parsing;
using test_irony.Analizador;

namespace ProyectoIronyCS.sol.com.analizador
{
    class Sintactico
    {
        public void Analizar(String cadena)
        {
            Gramatica gramatica = new Gramatica();
            LanguageData lenguaje = new LanguageData(gramatica);
            Parser parser = new Parser(lenguaje);
            ParseTree arbol = parser.Parse(cadena);
            ParseTreeNode raiz = arbol.Root;

            if (raiz != null)
            {
                Console.WriteLine("analisis correcto");
            }
            else
            {
                Console.WriteLine(arbol.ParserMessages[0].Message);
                Console.WriteLine("En la fila " + (arbol.ParserMessages[0].Location.Line + 1) + " y columna " + (arbol.ParserMessages[0].Location.Column + 1));
            }
        }


    }
}