using System.Collections.ObjectModel;

public class Category
{
    public string Name { get; set; }
    public ObservableCollection<Problem> Problems { get; set; }
    public Category(string name)
    {
        Name = name;
        Problems = new ObservableCollection<Problem>();
    }

    public override string ToString()
    {
        return Name;
    }
}
