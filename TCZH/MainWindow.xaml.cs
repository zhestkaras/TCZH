using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TCZH
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private Category selectedCategory;
        private Problem selectedProblem;

        public ObservableCollection<Category> Categories { get; set; }
        public Category SelectedCategory
        {
            get => selectedCategory;
            set
            {
                selectedCategory = value;
                Signal();
            }
        }
        public Problem SelectedProblem
        {
            get => selectedProblem;
            set
            {
                selectedProblem = value;
                Signal();
            }
        }

        public ICommand CreateProblemCommand { get; }

        public static ProblemStatus[] StatusOptions { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            
            Categories = new ObservableCollection<Category>
            {
                new Category ( "Качество коммунальных услуг" ),
                new Category ( "Планы по обустройству" ),
                new Category ( "Иные проблемы" )
            };

            StatusOptions = new ProblemStatus[]
            {
              ProblemStatus.New,
              ProblemStatus.InProgress,
              ProblemStatus.Resolved,
            };
            
            DataContext = this;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        void Signal([CallerMemberName] string prop = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedCategory != null)
            {
                SelectedCategory.Problems.Add(new Problem { Title = "Новая проблема", Description = "Описание проблемы", Applicant = "Заявитель" });
            }
        }
    }


}
public enum ProblemStatus
{
    New,
    InProgress,
    Resolved
}