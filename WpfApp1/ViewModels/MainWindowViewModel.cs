using WpfApp1.Shared;

namespace WpfApp1.ViewModels
{
    public class MainWindowViewModel 
        : BindableBase
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

        #endregion

        public MainWindowViewModel()
        {
            TesteCommand = new BaseCommand(Teste);
        }

        #region Methods

        private void Teste()
        {
            if (Texto.Length > 0) { 
                LblTexto = Texto;
            }
        }

        #endregion
    }
}