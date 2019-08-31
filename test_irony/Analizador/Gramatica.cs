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
        public Gramatica() : base(false)
        {
            var ID = new IdentifierTerminal("ID", "_", "_");
            var ComentarioLinea = new CommentTerminal("ComentarioLinea", "//", "\n", "\r\n");
            var ComentarioMultilinea = new CommentTerminal("ComentarioMultilinea", "/*", "*/");
            var ENTERO = new RegexBasedTerminal("ENTERO", "[0-9]+");
            var DECIMAL = new RegexBasedTerminal("DECIMAL", "[0-9]+[.][0-9]+");
            var CADENA = new StringLiteral("CADENA", "\"");
            var DATE = new RegexBasedTerminal("DATE", "[0-2][0-9][0-9][0-9][-][0-1][0-9][-][0-3][0-9]");
            var TIME = new RegexBasedTerminal("TIME", "[0-2][0-9][:][0-6][0-9][:][0-6][0-9]");

            MarkReservedWords("null");
            MarkReservedWords("int");
            MarkReservedWords("double");
            MarkReservedWords("string");
            MarkReservedWords("boolean");
            MarkReservedWords("true");
            MarkReservedWords("false");
            MarkReservedWords("date");
            MarkReservedWords("time");
            MarkReservedWords("create");
            MarkReservedWords("type");
            MarkReservedWords("new");
            MarkReservedWords("alter");
            MarkReservedWords("add");
            MarkReservedWords("delete");
            MarkReservedWords("create");
            MarkReservedWords("database");
            MarkReservedWords("use");
            MarkReservedWords("drop");
            MarkReservedWords("table");
            MarkReservedWords("counter");
            MarkReservedWords("primary");
            MarkReservedWords("key");

            NonGrammarTerminals.Add(ComentarioLinea);
            NonGrammarTerminals.Add(ComentarioMultilinea);

            var s = new NonTerminal("s");
            var sentencias = new NonTerminal("sentencias");
            var sentencia = new NonTerminal("sentencia");
            var create_type = new NonTerminal("create_type");
            var alter_add_type = new NonTerminal("add_type");
            var alter_delete_type = new NonTerminal("add_type");
            var if_not_exists = new NonTerminal("if_not_exists");
            var declaracion_type = new NonTerminal("declaracion_type");
            var delete_type = new NonTerminal("delete_type");
            var declaraciones_type = new NonTerminal("declaraciones_type");
            var lista_ids = new NonTerminal("declaraciones_delete");
            var declaracion_objeto = new NonTerminal("declaracion_objeto");
            var instancia_objeto = new NonTerminal("instancia_objeto");
            var lista_valores = new NonTerminal("lista_valores");
            var expresiones = new NonTerminal("valores");
            var tipo_variable = new NonTerminal("tipo");
            var condicion = new NonTerminal("condicion");
            var comparacion = new NonTerminal("comparacion");
            var expresion = new NonTerminal("expresion");
            var id = new NonTerminal("id");
            var asignacion = new NonTerminal("asignacion");
            var casteo = new NonTerminal("casteo");
            var create_database = new NonTerminal("create_database");
            var use_database = new NonTerminal("use_database");
            var drop_database = new NonTerminal("drop_database");
            var create_table = new NonTerminal("create_table");
            var definicion_columnas = new NonTerminal("definicion_columnas");
            var columna = new NonTerminal("columna");
            var tipo_columna = new NonTerminal("tipo_columna");
            var llave_primaria = new NonTerminal("llave_primaria");

            this.Root = s;

            s.Rule = sentencias;

            sentencias.Rule = MakeStarRule(sentencias, sentencia);

            sentencia.Rule =
                  create_type
                | alter_add_type
                | alter_delete_type
                | delete_type
                | declaracion_type
                | declaracion_objeto 
                | instancia_objeto
                // DDL
                | create_database
                | use_database
                | drop_database
                | create_table
                ;

            //CQL general
            create_type.Rule = 
                  ToTerm("create") + ToTerm("type") + if_not_exists + ID + ToTerm("(") + declaraciones_type + ToTerm(")") + ToTerm(";")
                ;

            if_not_exists.Rule = 
                  ToTerm("if") + ToTerm("not") + ToTerm("exists")
                | Empty;

            declaraciones_type.Rule = 
                  MakePlusRule(declaraciones_type, ToTerm(","), declaracion_type);

            declaracion_type.Rule = 
                  expresion + tipo_variable;

            alter_add_type.Rule =
                  ToTerm("alter") + ToTerm("type") + ID + ToTerm("add") + ToTerm("(") + declaraciones_type + ToTerm(")") + ToTerm(";")
                ;

            alter_delete_type.Rule =
                  ToTerm("alter") + ToTerm("type") + ID + ToTerm("delete") + ToTerm("(") + lista_ids + ToTerm(")") + ToTerm(";")
                ;

            lista_ids.Rule =
                  MakePlusRule(lista_ids, ToTerm(","), ID)
                ;

            delete_type.Rule = 
                  ToTerm("delete") + ToTerm("type") + ID + ToTerm(";")
                ;

            declaracion_objeto.Rule = 
                  ID + ToTerm("@") + ID + ToTerm(";");

            instancia_objeto.Rule = 
                  ID + ToTerm("@") + id + ToTerm("=") + asignacion
                | tipo_variable + ToTerm("@") + id + ToTerm("=") + asignacion
                | ToTerm("@") + id + ToTerm("=") + asignacion    
                ;

            asignacion.Rule = 
                  ToTerm("new") + ID + ToTerm(";")
                | lista_valores + ToTerm(";")
                | ToTerm("@") + expresion + ToTerm(";")
                | expresion + ToTerm(";")
                ;

            tipo_variable.Rule =
                  ToTerm("int")
                | ToTerm("double")
                | ToTerm("string")
                | ToTerm("boolean")
                | ToTerm("date")
                | ToTerm("time")
                ;


            expresion.Rule =
                  casteo + id
                | casteo + ENTERO
                | casteo + DECIMAL
                | casteo + CADENA
                | casteo + DATE
                | casteo + TIME
                ;

            id.Rule = 
                  MakePlusRule(id, ToTerm("."), ID)
                ;

            casteo.Rule = 
                  ToTerm("(") + tipo_variable + ToTerm(")")
                | Empty;

            lista_valores.Rule = 
                  ToTerm("{") + expresiones + ToTerm("}")
                ;

            expresiones.Rule = 
                  MakePlusRule(expresiones, ToTerm(","), expresion)
                ;

            //DDL
            create_database.Rule = 
                  ToTerm("create") + ToTerm("database") + if_not_exists + ID + ToTerm(";")
                ;

            use_database.Rule = 
                  ToTerm("use") + ID + ToTerm(";")
                ;

            drop_database.Rule = 
                  ToTerm("drop") + ToTerm("database") + ID + ToTerm(";")
                ;

            create_table.Rule = 
                  ToTerm("create") + ToTerm("table") + if_not_exists + ID + ToTerm("(") + definicion_columnas + ToTerm(")") + ToTerm(";")
                ;

            definicion_columnas.Rule =
                  MakePlusRule(definicion_columnas, ToTerm(","), columna)
                ;

            columna.Rule =
                  ID + tipo_columna + llave_primaria
                | llave_primaria + ToTerm("(") + lista_ids + ToTerm(")")
                ;
                

            llave_primaria.Rule =
                  ToTerm("primary") + ToTerm("key")
                | Empty
                ;

            tipo_columna.Rule = 
                  ToTerm("counter")
                | tipo_variable
                ;


        }
    }
}
