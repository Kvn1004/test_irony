using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Ast;
using Irony.Parsing;

namespace test_irony.Analizador
{
    class Gramatica : Grammar
    {
        public Gramatica() : base(true)
        {
            var NUMERO = new NumberLiteral("Numero");
            var REVALUAR = ToTerm("Evaluar");
            var PTCOMA = ToTerm(";");
            var PARIZQ = ToTerm("(");
            var PARDER = ToTerm(")");
            var CORIZQ = ToTerm("[");
            var CORDER = ToTerm("]");
            var MAS = ToTerm("+");
            var MENOS = ToTerm("-");
            var POR = ToTerm("*");
            var DIVIDIDO = ToTerm("/");

            NonTerminal ini = new NonTerminal("ini");
            NonTerminal instruccion = new NonTerminal("instruccion");
            NonTerminal instrucciones = new NonTerminal("instrucciones");
            NonTerminal expresion = new NonTerminal("expresion");

            ini.Rule = instrucciones;

            instrucciones.Rule = instruccion + instrucciones
                | instruccion;

            instruccion.Rule = REVALUAR + CORIZQ + expresion + CORDER + PTCOMA;

            expresion.Rule = MENOS + expresion
                | expresion + MAS + expresion
                | expresion + MENOS + expresion
                | expresion + POR + expresion
                | expresion + DIVIDIDO + expresion
                | NUMERO
                | PARIZQ + expresion + PARDER;

            RegisterOperators(1, MAS, MENOS);
            RegisterOperators(2, POR, DIVIDIDO);

            this.Root = ini;
        }

    }
}
