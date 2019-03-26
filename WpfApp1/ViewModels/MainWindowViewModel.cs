using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.Models;
using WpfApp1.Shared;

namespace WpfApp1.ViewModels
{
    public class MainWindowViewModel 
        : BaseViewModel
    {
        #region Properties

        public BaseCommand TesteCommand { get; private set; }

        private string _texto;
        public string Texto
        {
            get { return _texto; }
            set
            {
                _texto = value;
                OnPropertyChanged("Texto");
            }
        }

        private string _lblTexto;
        public string LblTexto
        {
            get { return _lblTexto; }
            set
            {
                _lblTexto = value;
                OnPropertyChanged("LblTexto");
            }
        }

        public ObservableCollection<TesteModel> _listaTeste;
        public ObservableCollection<TesteModel> ListaTeste
        {
            get { return _listaTeste; }
            set
            {
                _listaTeste = value;
                OnPropertyChanged("ListaTeste");
            }
        }

        #endregion

        public MainWindowViewModel()
        {
            TesteCommand = new BaseCommand(Teste);

            ListaTeste = new ObservableCollection<TesteModel>()
            {
                new TesteModel(){Descricao = "Teste 1", Quantidade = 0},
                new TesteModel(){Descricao = "Teste 2", Quantidade = 0},
                new TesteModel(){Descricao = "Teste 3", Quantidade = 0}
            };

            AlterarLista();
        }

        #region Methods

        private void Teste()
        {
            if (Texto.Length > 0) { 
                LblTexto = Texto;
            }
        }

        private void AlterarLista()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    Task.Delay(2000).Wait();
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        var rand = new Random();
                        ListaTeste.Add(new TesteModel() { Descricao = $"Teste {ListaTeste.Count + 1}", Quantidade = rand.Next(100) });
                        OnPropertyChanged("ListaTeste");
                    });
                }
            });
        }

        #endregion
    }
}