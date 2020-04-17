﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfSemana03
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ClsDatos obj = new ClsDatos();
        public MainWindow()
        {
            InitializeComponent();

        }

        private void BtnConsutar_Click(object sender, RoutedEventArgs e)
        {
            dgvPedido.ItemsSource = obj.ListaPedidoFechas(Convert.ToDateTime(txtFechaInicio.Text),
                Convert.ToDateTime(txtFechaFin.Text)).DefaultView;
        }

        private void DgvPedido_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int idPedido;
            var item = dgvPedido.SelectedItem as DataRowView;
            if (null == item) return;
            idPedido = Convert.ToInt32(item.Row["IdPedido"]);
            dvgDetallePedido.ItemsSource = obj.ListarDetalle(idPedido).DefaultView;
            txtTotal.Text = Convert.ToString(obj.PedidoTotal(idPedido));
        }


    }
}
