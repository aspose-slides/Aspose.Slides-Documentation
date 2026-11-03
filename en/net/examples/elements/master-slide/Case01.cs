using Aspose.Slides;
using System.Drawing;

internal static partial class Program
{
    static void Case01()
    {
        using var presentation = new Presentation();
        // Clone the default master slide.
        var defaultMasterSlide = presentation.Masters[0];
        var newMasterSlide = presentation.Masters.AddClone(defaultMasterSlide);

        // Add a banner with company name to the top of the master slide.
        var banner = newMasterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 0, y: 0, width: 720, height: 25);
        banner.TextFrame.Text = "Acme";
        var textFill = banner.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat;
        textFill.FillType = FillType.Solid;
        textFill.SolidFillColor.Color = Color.Black;
        banner.FillFormat.FillType = FillType.NoFill;

        // Assign the new master slide to a layout slide.
        var layoutSlide = presentation.LayoutSlides[0];
        layoutSlide.MasterSlide = newMasterSlide;

        // Assign the layout slide to the first slide in the presentation.
        presentation.Slides[0].LayoutSlide = layoutSlide;

        VerifyCase01(presentation);
    }
}
