using System;
using System.Collections.Generic;
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
using System.Collections.ObjectModel;

namespace WpfApp1
{
   
    public partial class MainWindow : Window
    {
        ObservableCollection<Datos> datos = new ObservableCollection<Datos>();

        public MainWindow()
        {
            InitializeComponent();

            Series serie1 = new Series("American Horror Story", "Terror", "Diferentes temas dependiendo la serie, circo, casa del terror, asilo, coven, etc", "Ryan Murphy, Brad Falchuk", 2011, 9, 5);
            Series serie2 = new Series("Greys Anatomy", "Drama", "La vida de cirujanos  que laboran en el Hospital de Seattle", "Shonda Rhimes", 2005, 16, 5);
            Series serie3 = new Series("Mr. Robot", "Drama", "Un joven programador que sufre de un trastorno antisocial se conecta con la gente pirateando sus máquinas.", "Sam Esmail", 2015, 4, 4);

            Peliculas pelicula1 = new Peliculas("La Sirenita","Fantasia", "La historia de una sirena que quiere conocer el mundo fuera del mar", " Ron Clements, John Musker", 1989, 5);
            Peliculas pelicula2 = new Peliculas("El extraño mundo de Jack", "Fantasia", "El rey de las calabazas en el pueblo de las brujas planea secuestrar a Santa Claus y al mismo tiempo llevar pánico en vez de alegría.", "Tim Burton", 2006, 5);
            Peliculas pelicula3 = new Peliculas("Chucky", "Terror", "Chucky es un muñeco Good Guy que fue poseído por medio de magia vudú por el asesino en serie Charles Lee Ray. ", "Don Mancini", 1988, 4);

            datos.Add(serie1);
            datos.Add(serie2);
            datos.Add(serie3);
            datos.Add(pelicula1);
            datos.Add(pelicula2);
            datos.Add(pelicula3);
            listview.ItemsSource = datos;
    }

        private void listview_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            grdMain.Children.Clear();
            grdMain.Children.Add(new Agregarelemento());
            agregarboton.Visibility = Visibility.Hidden;
            guardarboton.Visibility = Visibility.Visible;
            añoboton1.Visibility = Visibility.Hidden;
            añoboton2.Visibility = Visibility.Hidden;
            azboton.Visibility = Visibility.Hidden;
            zaboton.Visibility = Visibility.Hidden;
            radioserie.Visibility = Visibility.Visible;
            radiopelicula.Visibility = Visibility.Visible;
            cancelarboton.Visibility = Visibility.Visible;

        }

        private void lstCatalogo_SelectionChanged(object sender, SelectionChangedEventArgs e) {

            if (datos[listview.SelectedIndex].Peliculas == "Peliculas" || datos[listview.SelectedIndex].Tipo == "peliculas")
            {
                agregarboton.Visibility = Visibility.Hidden;
                añoboton1.Visibility = Visibility.Hidden;
                añoboton2.Visibility = Visibility.Hidden;
                azboton.Visibility = Visibility.Hidden;
                zaboton.Visibility = Visibility.Hidden;
                editarboton.Visibility = Visibility.Hidden;
                eliminarboton.Visibility = Visibility.Hidden;
                cancelarboton.Visibility = Visibility.Hidden;
                actualizarboton.Visibility = Visibility.Hidden;


                ((Agregarelemento)(grdMain.Children[0])).titu.Text = datos[listview.SelectedIndex].Titulo;
                ((Agregarelemento)(grdMain.Children[0])).comboboxGenero.Text = datos[listview.SelectedIndex].Genero;
                ((Agregarelemento)(grdMain.Children[0])).dire.Text = datos[listview.SelectedIndex].Director;
                ((Agregarelemento)(grdMain.Children[0])).sino.Text = datos[listview.SelectedIndex].Sinopsis;
                ((Agregarelemento)(grdMain.Children[0])).año.Text = datos[listview.SelectedIndex].Año.ToString();
            }



                if (datos[listview.SelectedIndex].Tipo == "Serie" || datos[listview.SelectedIndex].Tipo == "Series")
                {
                    grdMain.Children.Clear();
                    grdMain.Children.Add(new Agregarelementoserie());
                    ((Agregarelementoserie)(grdMain.Children[0])).titu.Text = datos[listview.SelectedIndex].Titulo;
                    ((Agregarelementoserie)(grdMain.Children[0])).txtboxTemporadas.Text = datos[listview.SelectedIndex].Temporadas.ToString();
                    ((Agregarelementoserie)(grdMain.Children[0])).año.Text = datos[listview.SelectedIndex].Año.ToString();
                    ((Agregarelementoserie)(grdMain.Children[0])).comboboxGenero.Text = datos[listview.SelectedIndex].Genero;
                    ((Agregarelementoserie)(grdMain.Children[0])).dire.Text = datos[listview.SelectedIndex].Director;
                    ((Agregarelementoserie)(grdMain.Children[0])).sino.Text = datos[listview.SelectedIndex].Sinopsis;

                }
                   public void az_Click(object sender, RoutedEventArgs e)
                {
                    bool swap;


                    do
                    {
                        swap = false;
                        for (int index = 0; index < (datos.Count - 1); index++)
                        {
                            if (string.Compare(datos[index].Titulo, datos[index + 1].Titulo) > 0)
                            {
                                var temp = datos[index];
                                datos[index] = datos[index + 1];
                                datos[index + 1] = temp;
                                swap = true;
                            }

                        }
                    } while (swap == true);
                }
                    private void za_Click(object sender, RoutedEventArgs e)
                    {
                        bool swap;


                        do
                        {
                            swap = false;
                            for (int index = 0; index < (datos.Count - 1); index++)
                            {
                                if (string.Compare(datos[index].Titulo, datos[index + 1].Titulo) < 0)
                                {
                                    var temp = datos[index];
                                    datos[index] = datos[index + 1];
                                    datos[index + 1] = temp;
                                    swap = true;
                                }

                            }
                        } while (swap == true);
                    }

            private void actualizar_Click(object sender, RoutedEventArgs e)
            {
                datos[listview.SelectedIndex].Titulo = ((editarboton)(grdMain.Children[0])).tb_titulo_e.Text;
                datos[listview.SelectedIndex].Genero = ((editarboton)(grdMain.Children[0])).cb_genero_e.Text;
                datos[listview.SelectedIndex].Sinopsis = ((editarboton)(grdMain.Children[0])).tb_sinopsis_e.Text;
                datos[listview.SelectedIndex].Director = ((editarboton)(grdMain.Children[0])).tb_director_e.Text;
                datos[listview.SelectedIndex].Temporadas = ((editarboton)(grdMain.Children[0])).tb_temporadas_e.Text;
                datos[listview.SelectedIndex].Año = Convert.ToInt32(((editarboton)(grdMain.Children[0])).tb_año_e.Text);
                datos[listview.SelectedIndex].Calificacion = ((editarboton)(grdMain.Children[0])).cb_calificacion_e.Text;
            }
            private void cancelar_Click(object sender, RoutedEventArgs e)
            {
                grdMain.Children.Clear();
                agregarboton.Visibility = Visibility.Visible;
                añoboton1.Visibility = Visibility.Visible;
                cancelarboton.Visibility = Visibility.Hidden;
                añoboton2.Visibility = Visibility.Visible;
                eliminarboton.Visibility = Visibility.Hidden;
                azboton.Visibility = Visibility.Visible;
                zaboton.Visibility = Visibility.Visible;
                actualizarboton.Visibility = Visibility.Hidden;
           
            }
            private void eliminar_Click(object sender, RoutedEventArgs e)
            {
                if (listview.SelectedIndex != -1)
                {
                    datos.RemoveAt(listview.SelectedIndex);
                    grdMain.Children.Clear();
                    actualizarboton.Visibility = Visibility.Hidden;
                    eliminarboton.Visibility = Visibility.Hidden;
                    cancelarboton.Visibility = Visibility.Hidden;
                 
                    agregarboton.Visibility = Visibility.Visible;
                   azboton.Visibility = Visibility.Visible;
                    zaboton.Visibility = Visibility.Visible;
                    añoboton1.Visibility = Visibility.Visible;
                    añoboton2.Visibility = Visibility.Visible;  
                }
            }
            private void añouno_Click(object sender, RoutedEventArgs e)
            {
                bool proceso = false;
                do
                {
                    proceso = false;
                    for (int i = 0; i < datos.Count - 1; i++)
                    {
                        if (datos[i].Año < datos[i + 1].Año)
                        {
                            var temp = datos[i];
                            datos[i] = datos[i + 1];
                            datos[i + 1] = temp;
                            proceso = true;
                        }
                    }
                }
                while (proceso);

            }

            private void añodos_Click(object sender, RoutedEventArgs e)
            {
                bool proceso = false;
                do
                {
                    proceso = false;
                    for (int i = 0; i < datos.Count - 1; i++)
                    {
                        if (datos[i].Año > datos[i + 1].Año)
                        {
                            var temp = datos[i];
                            datos[i] = datos[i + 1];
                            datos[i + 1] = temp;
                            proceso = true;
                        }
                    }
                }
                while (proceso);
            }

            private void RadioButton1_Checked(object sender, RoutedEventArgs e)
            {
                grdMain.Children.Clear();
                grdMain.Children.Add(new agregarboton());

                ((agregarboton)(grdMain.Children[0])).cb_temp.Visibility = Visibility.Hidden;
                ((agregarboton)(grdMain.Children[0])).texto_temp.Visibility = Visibility.Hidden;
                
   


            }

            private void RadioButton_Checked(object sender, RoutedEventArgs e)
            {
                grdMain.Children.Clear();
                grdMain.Children.Add(new agregarboton());
                

            }


        }


    }
            }