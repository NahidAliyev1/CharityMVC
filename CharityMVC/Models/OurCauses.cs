namespace CharityMVC.Models;

public class OurCauses
{
    public int Id { get; set; }
    public string ImgPath { get; set; }
    public string Name { get; set; }
    public string ShortDescription { get; set; }
    public double RaisedPrice { get; set; }
    public double GoalPrice { get; set; }
    public static string DonateNow { get; set; }
}
