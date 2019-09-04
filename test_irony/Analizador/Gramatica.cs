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
            var DATE = new RegexBasedTerminal("DATE", "['][0-2][0-9][0-9][0-9][-][0-1][0-9][-][0-3][0-9][']");
            var TIME = new RegexBasedTerminal("TIME", "['][0-2][0-9][:][0-6][0-9][:][0-6][0-9][']");

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
            MarkReservedWords("truncate");
            MarkReservedWords("commit");
            MarkReservedWords("rollback");
            MarkReservedWords("user");
            MarkReservedWords("with");
            MarkReservedWords("password");
            MarkReservedWords("grant");
            MarkReservedWords("on");
            MarkReservedWords("in");
            MarkReservedWords("revoke");
            //MarkReservedWords("insert");
            MarkReservedWords("into");
            MarkReservedWords("values");
            MarkReservedWords("update");
            //MarkReservedWords("set");
            MarkReservedWords("where");
            MarkReservedWords("from");
            MarkReservedWords("select");
            MarkReservedWords("order");
            MarkReservedWords("by");
            MarkReservedWords("limit");
            MarkReservedWords("begin");
            MarkReservedWords("apply");
            MarkReservedWords("batch");
            MarkReservedWords("count");
            MarkReservedWords("min");
            MarkReservedWords("max");
            MarkReservedWords("sum");
            MarkReservedWords("avg");
            MarkReservedWords("map");
            MarkReservedWords("list");
            MarkReservedWords("if");
            MarkReservedWords("else");
            MarkReservedWords("switch");
            MarkReservedWords("case");
            MarkReservedWords("default");
            MarkReservedWords("detener");
            MarkReservedWords("while");
            MarkReservedWords("do");
            MarkReservedWords("for");
            MarkReservedWords("cursor");
            MarkReservedWords("procedure");
            MarkReservedWords("call");
            MarkReservedWords("break");
            MarkReservedWords("return");
            MarkReservedWords("continue");
            MarkReservedWords("is");
            MarkReservedWords("each");
            MarkReservedWords("open");
            MarkReservedWords("close");
            MarkReservedWords("throw");
            MarkReservedWords("try");
            MarkReservedWords("catch");
            MarkReservedWords("as");

            NonGrammarTerminals.Add(ComentarioLinea);
            NonGrammarTerminals.Add(ComentarioMultilinea);

            var s = new NonTerminal("s");
            var sentencias = new NonTerminal("sentencias");
            var sentencia = new NonTerminal("sentencia");
            var create_type = new NonTerminal("create_type");
            var alter_add_type = new NonTerminal("add_type");
            var alter_delete_type = new NonTerminal("add_type");
            var if_not_exists = new NonTerminal("if_not_exists");
            var if_exists = new NonTerminal("if_exists");
            var declaracion_type = new NonTerminal("declaracion_type");
            var delete_type = new NonTerminal("delete_type");
            var declaraciones_type = new NonTerminal("declaraciones_type");
            var lista_ids = new NonTerminal("lista_ids");
            var condiciones = new NonTerminal("condiciones");
            var condiciones_insert = new NonTerminal("condiciones_insert");
            var primitivo = new NonTerminal("tipo_primitivo");
            var tipo_variable = new NonTerminal("tipo_variable");
            var condicion = new NonTerminal("condicion");
            var condicion_insert = new NonTerminal("condicion_insert");
            var comparacion = new NonTerminal("comparacion");
            var expresion = new NonTerminal("expresion");
            var id = new NonTerminal("id");
            var tipo_id = new NonTerminal("tipo_id");
            var casteo = new NonTerminal("casteo");
            var create_database = new NonTerminal("create_database");
            var use_database = new NonTerminal("use_database");
            var drop_database = new NonTerminal("drop_database");
            var create_table = new NonTerminal("create_table");
            var definicion_columnas = new NonTerminal("definicion_columnas");
            var columna = new NonTerminal("columna");
            var tipo_columna = new NonTerminal("tipo_columna");
            var llave_primaria = new NonTerminal("llave_primaria");
            var alter_table_add = new NonTerminal("alter_table_add");
            var alter_table_drop = new NonTerminal("alter_table_drop");
            var drop_table = new NonTerminal("drop_table");
            var truncate_table = new NonTerminal("truncate_table");
            var commit = new NonTerminal("commit");
            var rollback = new NonTerminal("rollback");
            var create_user = new NonTerminal("create_user");
            var grant = new NonTerminal("grant");
            var revoke = new NonTerminal("revoke");
            var insert_normal = new NonTerminal("insert_normal");
            var insert_especial = new NonTerminal("insert_especial");
            var update = new NonTerminal("update");
            var op_unaria = new NonTerminal("op_unaria");
            var asignacion_tabla = new NonTerminal("asignacion_tabla");
            var asignaciones_tabla = new NonTerminal("asignaciones_tabla");
            var where = new NonTerminal("where");
            var delete = new NonTerminal("delete");
            var select = new NonTerminal("select");
            var lista_campos = new NonTerminal("lista_campos");
            var order_by = new NonTerminal("order_by");
            var limit = new NonTerminal("limit");
            var asc_desc = new NonTerminal("asc_desc");
            var order_by_order = new NonTerminal("order_by_order");
            var order_by_campos = new NonTerminal("order_by_campos");
            var batch = new NonTerminal("batch");
            var sentencias_batch = new NonTerminal("sentencias_batch");
            var sentencia_batch = new NonTerminal("sentencia_batch");
            var funcion_agregacion = new NonTerminal("funcion_agregacion");
            var tipo_agregacion = new NonTerminal("tipo_agregacion");
            var pto_coma = new NonTerminal("pto_coma");
            var collection = new NonTerminal("collection");
            var asignacion_collection = new NonTerminal("tipo_collection");
            var map_init = new NonTerminal("map");
            var list_init = new NonTerminal("list");
            var set_init = new NonTerminal("set");
            var insert_map = new NonTerminal("insert_map");
            var tipo_asignacion = new NonTerminal("tipo_asignacion");
            var args = new NonTerminal("args");
            var bloque = new NonTerminal("bloque");
            var operacion_unaria = new NonTerminal("operacion_unaria");
            var sentencias_bloque = new NonTerminal("sentencias_bloque");
            var sentencia_bloque = new NonTerminal("sentencia_bloque");
            var declaracion_variable = new NonTerminal("declaracion_variable");
            var lista_variables = new NonTerminal("lista_variables");
            var nombre_variable = new NonTerminal("nombre_variable");
            var variable = new NonTerminal("variable");
            var asignacion = new NonTerminal("asignacion");
            var asignacion_variable = new NonTerminal("asignacion_variable");
            var asignacion_operacion = new NonTerminal("asignacion_operacion");
            var operador_asignador = new NonTerminal("operador_asignador");
            var sentencia_if = new NonTerminal("sentencia_if");
            var sentencia_else = new NonTerminal("sentencia_else");
            var sentencia_switch = new NonTerminal("sentencia_switch");
            var sentencias_case = new NonTerminal("sentencias_case");
            var sentencia_case = new NonTerminal("sentencia_case");
            var case_break = new NonTerminal("case_break");
            var sentencia_while = new NonTerminal("sentencia_while");
            var sentencia_do_while = new NonTerminal("sentencia_do_while");
            var sentencia_for = new NonTerminal("sentencia_for");
            var sentencia_for_each = new NonTerminal("sentencia_for_each");
            var inicializacion_for = new NonTerminal("inicializacion_for");
            var actualizacion_for = new NonTerminal("actualizacion_for");
            var funcion = new NonTerminal("funcion");
            var tipo_funcion = new NonTerminal("tipo_funcion");
            var parametros = new NonTerminal("parametros");
            var parametro = new NonTerminal("parametro");
            var llamada_funcion = new NonTerminal("llamada_funcion");
            var procedimiento = new NonTerminal("procedimiento");
            var call = new NonTerminal("call");
            var sentencia_return = new NonTerminal("sentencia_return");
            var sentencia_continue = new NonTerminal("sentencia_continue");
            var sentencia_break = new NonTerminal("sentencia_break");
            var cursor = new NonTerminal("cursor");
            var open_cursor = new NonTerminal("open_cursor");
            var close_cursor = new NonTerminal("close_cursor");
            var sentencia_throw = new NonTerminal("sentencia_throw");
            var sentencia_try_catch = new NonTerminal("sentencia_try_catch");
            var asignacion_user_type_set = new NonTerminal("valor_user_type");
            var condiciones_asignacion = new NonTerminal("condiciones_asignacion");
            var condicion_asignacion = new NonTerminal("condicion_asignacion");

            this.Root = s;

            RegisterOperators(12, Associativity.Left, ToTerm("("), ToTerm(")"));
            RegisterOperators(11, ToTerm("++"), ToTerm("--"));
            RegisterOperators(10, Associativity.Right, ToTerm("-"), ToTerm("!"));
            RegisterOperators(9, Associativity.Left, ToTerm("/"), ToTerm("*"), ToTerm("%"), ToTerm("**"));
            RegisterOperators(8, Associativity.Left, ToTerm("+"), ToTerm("-"));
            RegisterOperators(7, ToTerm("<"), ToTerm("<="), ToTerm(">"), ToTerm(">="));
            RegisterOperators(6, Associativity.Left, ToTerm("=="), ToTerm("!=="));
            RegisterOperators(5, Associativity.Left, ToTerm("^"));
            RegisterOperators(4, Associativity.Left, ToTerm("&&"));
            RegisterOperators(3, Associativity.Left, ToTerm("||"));
            RegisterOperators(2, Associativity.Right, ToTerm("?"), ToTerm(":"));
            RegisterOperators(1, Associativity.Right, ToTerm("="));

            s.Rule = sentencias;

            sentencias.Rule = MakeStarRule(sentencias, sentencia);

            sentencia.Rule =
                  create_type
                | alter_add_type
                | alter_delete_type
                | delete_type
                // DDL
                | create_database
                | use_database
                | drop_database
                | create_table
                | alter_table_add
                | alter_table_drop
                | drop_table
                | truncate_table
                // TCL
                | commit
                | rollback
                // DCL
                | create_user
                | grant
                | revoke
                // DML
                | insert_normal
                | insert_especial
                | update
                | delete
                | select
                | batch
                | funcion_agregacion
                // FCL
                | bloque
                | operacion_unaria
                | declaracion_variable
                | asignacion_variable
                | asignacion_operacion
                | sentencia_if
                | sentencia_switch
                | sentencia_while
                | sentencia_do_while
                | sentencia_for
                | sentencia_for_each
                | funcion
                | llamada_funcion
                | procedimiento
                | call
                | sentencia_break
                | sentencia_return
                | sentencia_continue
                | cursor
                | open_cursor
                | close_cursor
                | sentencia_throw
                | sentencia_try_catch
                ;

            // CQL general
            create_type.Rule =
                  ToTerm("create") + ToTerm("type") + if_not_exists + ID + ToTerm("(") + declaraciones_type + ToTerm(")") + ToTerm(";")
                ;

            if_not_exists.Rule =
                  ToTerm("if") + ToTerm("not") + ToTerm("exists")
                | Empty;

            if_exists.Rule =
                 ToTerm("if") + ToTerm("exists")
                | Empty;

            declaraciones_type.Rule =
                  MakePlusRule(declaraciones_type, ToTerm(","), declaracion_type);

            declaracion_type.Rule =
                  condicion + primitivo
                | condicion + asignacion_collection
                | condicion + ID
                ;

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

            primitivo.Rule =
                  ToTerm("int")
                | ToTerm("double")
                | ToTerm("string")
                | ToTerm("boolean")
                | ToTerm("date")
                | ToTerm("time")
                ;

            collection.Rule =
                  ToTerm("map")
                | ToTerm("set")
                | ToTerm("list")
                ;

            asignacion_collection.Rule =
                  map_init
                | set_init
                | list_init
                ;

            tipo_asignacion.Rule =
                  asignacion_collection
                | primitivo
                | ID
                ;

            map_init.Rule =
                  ToTerm("map") + ToTerm("<") + tipo_variable + ToTerm(",") + tipo_asignacion + ToTerm(">")
                ;

            set_init.Rule =
                  ToTerm("set") + ToTerm("<") + tipo_asignacion + ToTerm(">")
                ;

            list_init.Rule =
                  ToTerm("list") + ToTerm("<") + tipo_asignacion + ToTerm(">")
                ;

            // expresiones
            condicion.Rule =
                  condicion + ToTerm("?") + condicion + ToTerm(":") + condicion
                | condicion + ToTerm("&&") + condicion
                | condicion + ToTerm("||") + condicion
                | condicion + ToTerm("^") + condicion
                | ToTerm("!") + condicion
                | expresion + comparacion + expresion
                | expresion
                ;

            comparacion.Rule =
                  ToTerm("==")
                | ToTerm("!=")
                | ToTerm("<")
                | ToTerm("<=")
                | ToTerm(">")
                | ToTerm(">=")
                ;

            expresion.Rule =
                  expresion + ToTerm("+") + expresion
                | expresion + ToTerm("-") + expresion
                | expresion + ToTerm("*") + expresion
                | expresion + ToTerm("/") + expresion
                | expresion + ToTerm("**") + expresion
                | expresion + ToTerm("%") + expresion
                | ToTerm("-") + expresion
                | id + op_unaria
                //| ID + ToTerm("(") + args + ToTerm(")")
                | ToTerm("@") + id + op_unaria
                | ENTERO
                | DECIMAL
                | CADENA
                | DATE
                | TIME
                | ToTerm("null")
                | ToTerm("true")
                | ToTerm("false")
                | ToTerm("(") + condicion + ToTerm(")")
                ;

            op_unaria.Rule =
                  ToTerm("++")
                | ToTerm("--")
                | Empty
                ;

            id.Rule =
                  MakePlusRule(id, ToTerm("."), tipo_id)
                ;

            tipo_id.Rule =
                  ID
                | ID + ToTerm("(") + args + ToTerm(")")
                | ID + ToTerm("[") + args + ToTerm("]")
                ;

            args.Rule =
                  MakeStarRule(args, ToTerm(","), condicion | asignacion_user_type_set)
                ;

            casteo.Rule =
                  ToTerm("(") + primitivo + ToTerm(")")
                ;

            condiciones.Rule =
                  MakePlusRule(condiciones, ToTerm(","), condicion)
                ;

            condiciones_insert.Rule =
                  MakePlusRule(condiciones_insert, ToTerm(","), condicion_insert)
                ;

            condicion_insert.Rule =
                  condicion
                | ToTerm("{") + insert_map + ToTerm("}")
                | ToTerm("{") + condiciones + ToTerm("}")
                | ToTerm("[") + condiciones + ToTerm("]")
                ;

            insert_map.Rule =
                  MakePlusRule(insert_map, ToTerm(","), condicion + ToTerm(":") + condicion)
                ;

            // DDL
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
                | primitivo
                | asignacion_collection
                | ID
                ;

            alter_table_add.Rule =
                  ToTerm("alter") + ToTerm("table") + ID + ToTerm("add") + declaraciones_type + ToTerm(";")
                ;

            alter_table_drop.Rule =
                  ToTerm("alter") + ToTerm("table") + ID + ToTerm("drop") + lista_ids + ToTerm(";")
                ;

            drop_table.Rule =
                  ToTerm("drop") + ToTerm("table") + if_exists + ID + ToTerm(";")
                ;

            truncate_table.Rule =
                  ToTerm("truncate") + ToTerm("table") + ID + ToTerm(";")
                ;

            // TCL
            commit.Rule =
                  ToTerm("commit") + ToTerm(";")
                ;

            rollback.Rule =
                  ToTerm("rollback") + ToTerm(";")
                ;

            // DCL
            create_user.Rule =
                  ToTerm("create") + ToTerm("user") + ID + ToTerm("with") + ToTerm("password") + condicion + ToTerm(";")
                ;

            grant.Rule =
                  ToTerm("grant") + ID + ToTerm("on") + ID + ToTerm(";")
                ;

            revoke.Rule =
                  ToTerm("revoke") + ID + ToTerm("on") + ID + ToTerm(";")
                ;

            // DML
            insert_normal.Rule =
                  ToTerm("insert") + ToTerm("into") + ID + ToTerm("values") + ToTerm("(") + condiciones_insert + ToTerm(")") + ToTerm(";")
                ;

            insert_especial.Rule =
                  ToTerm("insert") + ToTerm("into") + ID + ToTerm("(") + lista_ids + ToTerm(")") + ToTerm("values") + ToTerm("(") + condiciones_insert + ToTerm(")") + ToTerm(";")
                ;

            update.Rule =
                ToTerm("update") + ID + ToTerm("set") + asignaciones_tabla + where + ToTerm(";")
                ;

            asignaciones_tabla.Rule =
                  MakePlusRule(asignaciones_tabla, ToTerm(","), asignacion_tabla)
                ;

            asignacion_tabla.Rule =
                  id + ToTerm("=") + condicion
                | id + ToTerm("=") + condiciones_insert
                | id + ToTerm("=") + ID + ToTerm("+") + condiciones_insert
                | id + ToTerm("=") + ID + ToTerm("-") + condiciones_insert
                ;

            where.Rule =
                  ToTerm("where") + condicion
                | ToTerm("where") + condicion + ToTerm("in") + condicion
                | ToTerm("where") + condicion + ToTerm("in") + ToTerm("(") + condiciones + ToTerm(")")
                | Empty
                ;

            delete.Rule =
                  ToTerm("delete") + ToTerm("from") + ID + where + ToTerm(";")
                | ToTerm("delete") + id + ToTerm("from") + ID + where + ToTerm(";")
                ;

            select.Rule =
                  ToTerm("select") + lista_campos + ToTerm("from") + ID + where + order_by + limit + pto_coma
                ;

            pto_coma.Rule =
                  ToTerm(";")
                | Empty
                ;

            lista_campos.Rule =
                  ToTerm("*")
                | condiciones
                ;

            order_by.Rule =
                  ToTerm("order") + ToTerm("by") + order_by_order
                | Empty
                ;

            order_by_order.Rule =
                  MakePlusRule(order_by_order, ToTerm(","), order_by_campos)
                ;

            order_by_campos.Rule =
                  ID + asc_desc
                ;

            asc_desc.Rule =
                  ToTerm("asc")
                | ToTerm("desc")
                | Empty
                ;

            limit.Rule =
                  ToTerm("limit") + condicion
                | Empty
                ;

            batch.Rule =
                  ToTerm("begin") + ToTerm("batch") + sentencias_batch + ToTerm("apply") + ToTerm("batch") + ToTerm(";")
                ;

            sentencias_batch.Rule =
                  MakePlusRule(sentencias_batch, sentencia_batch)
                ;

            sentencia_batch.Rule =
                  insert_normal
                | insert_especial
                | delete
                | update
                ;

            funcion_agregacion.Rule =
                  tipo_agregacion + ToTerm("(") + ToTerm("<<") + select + ToTerm(">>") + ToTerm(")") + ToTerm(";")
                ;

            tipo_agregacion.Rule =
                  ToTerm("count")
                | ToTerm("min")
                | ToTerm("max")
                | ToTerm("sum")
                | ToTerm("avg")
                ;

            // FCL 
            bloque.Rule =
                  ToTerm("{") + sentencias_bloque + ToTerm("}")
                ;

            sentencias_bloque.Rule =
                  MakeStarRule(sentencias_bloque, sentencia_bloque)
                ;

            sentencia_bloque.Rule =
                  // DDL
                  create_database
                | use_database
                | drop_database
                | create_table
                | alter_table_add
                | alter_table_drop
                | drop_table
                | truncate_table
                // DML
                | insert_normal
                | insert_especial
                | update
                | delete
                | select
                | batch
                | funcion_agregacion
                // FCL
                | bloque
                | operacion_unaria
                | declaracion_variable
                | asignacion_variable
                | asignacion_operacion
                | sentencia_if
                | sentencia_switch
                | sentencia_while
                | sentencia_do_while
                | sentencia_for
                | sentencia_for_each
                | funcion
                | llamada_funcion
                | procedimiento
                | call
                | sentencia_break
                | sentencia_return
                | sentencia_continue
                | cursor
                | open_cursor
                | close_cursor
                | sentencia_throw
                | sentencia_try_catch
                ;

            operacion_unaria.Rule = 
                  ToTerm("@") + id + op_unaria + ToTerm(";")
                ;

            declaracion_variable.Rule =
                  tipo_variable + lista_variables + asignacion + ToTerm(";")
                | tipo_variable + lista_variables + ToTerm(";")
                ;

            tipo_variable.Rule =
                  primitivo
                | collection
                | ID
                ;

            lista_variables.Rule =
                  MakePlusRule(lista_variables, ToTerm(","), nombre_variable)
                ;

            nombre_variable.Rule =
                  ToTerm("@") + ID
                ;

            variable.Rule =
                  ToTerm("@") + id
                ;

            asignacion.Rule =
                  ToTerm("=") + condicion
                | ToTerm("=") + casteo + condicion
                | ToTerm("=") + asignacion_user_type_set
                | ToTerm("=") + ToTerm("new") + ID
                | ToTerm("=") + ToTerm("new") + asignacion_collection
                | ToTerm("=") + ToTerm("[") + insert_map + ToTerm("]")
                ;

            asignacion_user_type_set.Rule =
                  ToTerm("{") + condiciones_asignacion + ToTerm("}") + ToTerm("as") + ID
                | ToTerm("{") + condiciones_asignacion + ToTerm("}")
                | ToTerm("[") + condiciones_asignacion + ToTerm("]")
                ;

            condiciones_asignacion.Rule =
                  MakePlusRule(condiciones_asignacion, ToTerm(","), condicion_asignacion)
                ;

            condicion_asignacion.Rule =
                  condicion
                | asignacion_user_type_set
                ;

            asignacion_variable.Rule =
                  variable + asignacion + ToTerm(";")
                ;

            asignacion_operacion.Rule =
                  variable + operador_asignador + ENTERO + ToTerm(";")
                ;

            operador_asignador.Rule =
                  ToTerm("+=")
                | ToTerm("*=")
                | ToTerm("-=")
                | ToTerm("/=")
                ;


            sentencia_if.Rule = 
                  ToTerm("if") + ToTerm("(") + condicion + ToTerm(")") + ToTerm("{") + sentencias + ToTerm("}")
                | ToTerm("if") + ToTerm("(") + condicion + ToTerm(")") + ToTerm("{") + sentencias + ToTerm("}") + sentencia_else
                ;

            sentencia_else.Rule = 
                  ToTerm("else") + ToTerm("if") + ToTerm("(") + condicion + ToTerm(")") + ToTerm("{") + sentencias + ToTerm("}")
                | ToTerm("else") + ToTerm("if") + ToTerm("(") + condicion + ToTerm(")") + ToTerm("{") + sentencias + ToTerm("}") + sentencia_else
                | ToTerm("else") + ToTerm("{") + sentencias + ToTerm("}")
                ;

            sentencia_switch.Rule = 
                  ToTerm("switch") + ToTerm("(") + condicion + ToTerm(")") + ToTerm("{") + sentencias_case + ToTerm("}")
                ;

            sentencias_case.Rule = 
                  MakePlusRule(sentencias_case, sentencia_case)
                ;

            sentencia_case.Rule = 
                  ToTerm("case") + condicion + ToTerm(":") + sentencias + case_break
                | ToTerm("default") + ToTerm(":") + sentencias + case_break
                ;

            case_break.Rule = 
                  sentencia_break
                | Empty;

            sentencia_while.Rule = 
                  ToTerm("while") + ToTerm("(") + condicion + ToTerm(")") + ToTerm("{") + sentencias + ToTerm("}")
                ;

            sentencia_do_while.Rule = 
                  ToTerm("do") + ToTerm("{") + sentencias + ToTerm("}") + ToTerm("while") + ToTerm("(") + condicion + ToTerm(")") + ToTerm(";")
                ;

            sentencia_for.Rule = 
                  ToTerm("for") + ToTerm("(") + inicializacion_for + ToTerm(";") + condicion + ToTerm(";") + actualizacion_for + ToTerm(")") + ToTerm("{") + sentencias + ToTerm("}")
                ;

            inicializacion_for.Rule = 
                  tipo_variable + nombre_variable + asignacion
                | variable + asignacion
                ;

            actualizacion_for.Rule =
                  variable + asignacion
                | ToTerm("@") + id + op_unaria
                ;

            sentencia_for_each.Rule = 
                  ToTerm("for") + ToTerm("each") + ToTerm("(") + parametros + ToTerm(")") + ToTerm("in") + variable + ToTerm("{") + sentencias + ToTerm("}")
                ;

            funcion.Rule = 
                  tipo_funcion + ID + ToTerm("(") + parametros + ToTerm(")") + ToTerm("{") + sentencias + ToTerm("}")
                ;

            tipo_funcion.Rule =
                  ToTerm("cursor")
                | primitivo
                | collection
                | ID
                ;

            parametros.Rule = 
                  MakeStarRule(parametros, ToTerm(","), parametro)
                ;

            parametro.Rule = 
                  tipo_variable + variable
                ;

            llamada_funcion.Rule = 
                  ID + ToTerm("(") + args + ToTerm(")") + ToTerm(";")
                ;

            procedimiento.Rule = 
                  ToTerm("procedure") + ID + ToTerm("(") + parametros + ToTerm(")") + ToTerm(",") + ToTerm("(") + parametros + ToTerm(")") + ToTerm("{") + sentencias + ToTerm("}")
                ;

            call.Rule =
                  ToTerm("call") + ID + ToTerm("(") + args + ToTerm(")") + ToTerm(";")
                | lista_variables + ToTerm("=") + ToTerm("call") + ID + ToTerm("(") + args + ToTerm(")") + ToTerm(";")
                ;

            sentencia_break.Rule = 
                  ToTerm("break") + ToTerm(";")
                ;

            sentencia_return.Rule = 
                  ToTerm("return") + ToTerm(";")
                | ToTerm("return") + condiciones + ToTerm(";")
                ;

            sentencia_continue.Rule = 
                  ToTerm("continue") + ToTerm(";")
                ;

            cursor.Rule = 
                  ToTerm("cursor") + variable + ToTerm("is") + select
                ;

            open_cursor.Rule = 
                  ToTerm("open") + variable + ToTerm(";")
                ;

            close_cursor.Rule = 
                  ToTerm("close") + variable + ToTerm(";")
                ;

            sentencia_throw.Rule = 
                  ToTerm("throw") + ToTerm("new") + ID + ToTerm(";")
                ;

            sentencia_try_catch.Rule = 
                  ToTerm("try") + ToTerm("{") + sentencias + ToTerm("}") + ToTerm("catch") + ToTerm("(") + ID + variable + ToTerm(")") + ToTerm("{") + sentencias + ToTerm("}")
                ;
        }
    }
}