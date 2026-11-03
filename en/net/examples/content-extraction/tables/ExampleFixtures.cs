using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    private static void CreateInput()
    {
        Example.Setup();
        using (var p = new Presentation())
        {
            var group = p.Slides[0].Shapes.AddGroupShape();
            var table = group.Shapes.AddTable(30, 30, new double[] { 200, 160, 200 }, new double[] { 45, 45, 45 });
            table.Name = "Source table";
            table[0, 0].TextFrame.Text = "Customer";
            table[1, 0].TextFrame.Text = "Detail";
            table.MergeCells(table[1, 0], table[2, 0], false);
            table[0, 1].TextFrame.Text = Example.Choice("Acme, Inc.", "A,β");
            table[1, 1].TextFrame.Text = "東京";
            table[2, 1].TextFrame.Text = Example.Choice("\"Quoted\"", "\"Q\"");
            table[0, 2].TextFrame.Text = Example.Choice("Résumé", "é");
            p.Save("output/input.pptx", SaveFormat.Pptx);
        }
    }
}
