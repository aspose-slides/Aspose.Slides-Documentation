using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    static void Case03()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];
        slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

        slide.Controls.RemoveAt(0);

        presentation.Save("removed_activex.pptm", SaveFormat.Pptm);

        VerifyCase03(presentation);
    }
}
