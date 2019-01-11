using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App_ConsultarCEP.Servico.Modelo;
using App_ConsultarCEP.Servico;

namespace App_ConsultarCEP
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            btnBuscar.Clicked += BuscarCEP;
		}
        private void BuscarCEP(object sender, EventArgs args) {
            string CEP = txtCEP.Text.Trim();
            if (isValidCEP(CEP))
            {
                try
                { 
                Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(txtCEP.Text);
                    if(end != null)
                    {
                        lblResultado.Text = string.Format("Endereço: {2} de {3} em {0}/ {1}", end.localidade, end.uf, end.logradouro, end.bairro);
                    }
                    else
                    {
                        DisplayAlert("Erro", "Não foi encontrado um endereço para o CEP informado!", "OK");
                    }
                }
                catch (Exception e)
                {
                    DisplayAlert("Erro", e.Message, "OK");
                }
            }
            else
            {
                DisplayAlert("Erro", "O CEP é Inválido", "OK");
                lblResultado.Text = "";
            }
        }
        private bool isValidCEP(string CEP) 
        {
            bool Valido = true;
            if(CEP.Length != 8)
            {
                Valido = false;
            }
            int NovoCEP = 0;
            if (!int.TryParse(CEP, out NovoCEP))
            {
                Valido = false;
            }
            return Valido;
        }
	}
}
