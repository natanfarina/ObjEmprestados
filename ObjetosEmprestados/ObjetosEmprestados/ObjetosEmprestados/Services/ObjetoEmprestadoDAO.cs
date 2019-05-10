﻿using ObjetosEmprestados.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace ObjetosEmprestados.Services
{
   public class ObjetoEmprestadoDAO
    {
        private SQLiteConnection conexao;


            public ObjetoEmprestadoDAO()
             {
                 string caminho = DependencyService.Get<ICaminhoSQLite>().GetCaminhoDB("objeto_emprestado_db.sqlite");


            conexao = new SQLiteConnection(caminho);
            conexao.CreateTable<ObjetoEmprestado>();
             }

        public List<ObjetoEmprestado> GetTodos()
        {
            return (from dados in conexao.Table<ObjetoEmprestado>() select dados).ToList();
        }

        public ObjetoEmprestado Get(int id)
        {
            return conexao.Table<ObjetoEmprestado>().FirstOrDefault(x => x.Id == id);
        }

        public void ExcluirTodos()
        {
            conexao.DeleteAll<ObjetoEmprestado>();
        }

        public void ExcluirPorId(int id)
        {
            conexao.Delete<ObjetoEmprestado>(id);
        }

        public void Inserir(ObjetoEmprestado objeto)
        {
            conexao.Insert(objeto);
        }

        public void Atualizar(ObjetoEmprestado objeto)
        {
            conexao.Update(objeto);
        }
    }
}
