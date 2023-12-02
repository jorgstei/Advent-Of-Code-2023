namespace Day_2;


public class Round
{
    public int NumGreen { get; set; }
    public int NumBlue { get; set; }
    public int NumRed { get; set; }

    public Round(string roundString)
    {
        string[] colorsInfo = roundString.Split(',');
        foreach (var colorStr in colorsInfo)
        {
            var greenIndex = colorStr.IndexOf("green");
            var blueIndex = colorStr.IndexOf("blue");
            var redIndex = colorStr.IndexOf("red");
            if (greenIndex != -1){
                NumGreen = Int32.Parse(colorStr.Trim().Split(' ')[0]);
            }
            else if (blueIndex != -1){
                NumBlue = Int32.Parse(colorStr.Trim().Split(' ')[0]);
            }
            else if (redIndex != -1){
                NumRed = Int32.Parse(colorStr.Trim().Split(' ')[0]);
            }
        }
    }
}