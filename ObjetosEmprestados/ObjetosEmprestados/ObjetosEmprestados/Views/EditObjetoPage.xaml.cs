using ObjetosEmprestados.Models;
using ObjetosEmprestados.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ObjetosEmprestados.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditObjetoPage : ContentPage
	{

        private ObjetoEmprestado objetoEmprestado;

        public EditObjetoPage (ObjetoEmprestado objetoEmprestado)
		{
			InitializeComponent ();
            
            if(objetoEmprestado != null) //Editar / Excluir
            {
                this.objetoEmprestado = objetoEmprestado;
                  DescricaoEntry.Text = objetoEmprestado.Descricao;

                  NomeEntry.Text = objetoEmprestado.Nome;

                 DataDatePicker.Date = objetoEmprestado.Data;
                Title = "Editar Objeto Emprestado";

                SalvarButton.IsVisible = false;
                AtualizarButton.IsVisible = true;
                ExcluirButton.IsVisible = true;

            }
            else //Novo
            {
                DataDatePicker.Date = DateTime.Now;
                Title = "Nove Objeto Emprestado";
            }
                  
		}

        private void OnSalvar(object sender, System.EventArgs e)
        {
            //Criar o Objeto (pegar informações da tela)

            ObjetoEmprestado objeto = new ObjetoEmprestado();
            objeto.Descricao = DescricaoEntry.Text;
            objeto.Nome = NomeEntry.Text;
            objeto.Data = DataDatePicker.Date;

            //Enviar para o Banco de Dados(salvar)
            ObjetoEmprestadoDAO dao = new ObjetoEmprestadoDAO();
            dao.Inserir(objetoEmprestado);

            //Fechar a Tela
            Navigation.PopAsync();
        }

        private void OnAtualizar(object sender, System.EventArgs e)
        {
            //Atualiza as Informações
            objetoEmprestado.Descricao = DescricaoEntry.Text;
            objetoEmprestado.Nome = NomeEntry.Text;
            objetoEmprestado.Data = DataDatePicker.Date;

            //Atualiza o BD 
            ObjetoEmprestadoDAO dao = new ObjetoEmprestadoDAO();
            dao.Atualizar(objetoEmprestado);

            //Fechar a Tela
            Navigation.PopAsync();
        }

        private void OnExcluir(object sender, System.EventArgs e)
        {
            //Excluir o Objeto do Banco
            ObjetoEmprestadoDAO dao = new ObjetoEmprestadoDAO();
            dao.ExcluirPorId(objetoEmprestado.Id);
            //Fechar a Tela
            Navigation.PopAsync();
        }
    }
}