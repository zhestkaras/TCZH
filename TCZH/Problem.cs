public class Problem
{
    public DateTime CreationDate { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Appaus { get; set; }
    public string Solusion { get; set; }
    public string Status { get; set; }
    public string Applicant { get; set; }

    public Problem()
    {
        CreationDate = DateTime.Now;
        Status = "Open";
    }
}
