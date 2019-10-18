using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<string> listaFirme = new ObservableCollection<string>();
        public ObservableCollection<string> listaOre = new ObservableCollection<string>();
        public ObservableCollection<Inregistrare> listaInregistrari = new ObservableCollection<Inregistrare>();

        public MainWindow()
        {
            InitializeComponent();

            listView.ItemsSource = listaInregistrari;

            listaFirme.Add("United Motors International");
            listaFirme.Add("Aurom Metal Investment");
            listaFirme.Add("SOLO INFO KONTA");
            ddlFirma.ItemsSource = listaFirme;
            

            datePicker.SelectedDate = DateTime.Today;

            for (float i = 0.5f; i <= 8; i = i + 0.5f) {
                listaOre.Add(i.ToString());
        
            }

            ddlOre.ItemsSource = listaOre;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listView.ItemsSource);
            view.Filter = UserFilter;

        }

        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(txtFilter.Text))
                return true;
            else
                return ((item as Inregistrare).user.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void txtFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(listView.ItemsSource).Refresh();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            string user = txtUser.Text.ToString();
            string data = datePicker.Text.ToString();
            string firma = ddlFirma.SelectedItem.ToString();
            float ore = float.Parse(ddlOre.SelectedItem.ToString());
            

            Inregistrare inregistrare = new Inregistrare(user, data, firma, ore);
            listaInregistrari.Add(inregistrare);

            for(int i = 0;i<listaInregistrari.Count;i++)
            Console.WriteLine(listaInregistrari[i].ToString());

            listView.ItemsSource = listaInregistrari;
       

        }
    }
}
