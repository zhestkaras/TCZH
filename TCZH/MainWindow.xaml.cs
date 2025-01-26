using System.Collections.ObjectModel;
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
    public partial class MainWindow : Window
    {
 public ObservableCollection<Category> Categories { get; set; }
            public Category SelectedCategory { get; set; }
            public Problem SelectedProblem { get; set; }
            public static ProblemStatus[] StatusOptions { get; set; }
        public MainWindow()
        {
            InitializeComponent(); 
            DataContext = this;
            Categories = new ObservableCollection<Category>
            {
                new Category { Name = "Качество коммунальных услуг" },
                new Category { Name = "Планы по обустройству" },
                new Category { Name = "Иные проблемы" }
            };

            StatusOptions = new ProblemStatus[]
            {
              ProblemStatus.New,
              ProblemStatus.InProgress,
              ProblemStatus.Resolved,
            };
        }

        private void CreateProblemButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedCategory != null)
            {
                SelectedCategory.Problems.Add(new Problem { Title = "Новая проблема", Description = "Описание проблемы", Applicant = "Заявитель" });
            }
        }


    }


}

       

public class Category
    {
        public string Name { get; set; }
        public ObservableCollection<Problem> Problems { get; set; } = new ObservableCollection<Problem>();

        public override string ToString()
        {
            return Name;
        }
    }

    public class Problem
    {
        public DateTime CreationDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Applicant { get; set; }
        public string Solution { get; set; }
        public ProblemStatus Status { get; set; }

        public Problem()
        {
            CreationDate = DateTime.Now;
            Status = ProblemStatus.New;
        }
    }

    public enum ProblemStatus
    {
        New,
        InProgress,
        Resolved
    }


