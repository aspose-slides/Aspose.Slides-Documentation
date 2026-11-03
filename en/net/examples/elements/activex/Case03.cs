using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    static void Case03()
    {
        using var presentation = new Presentation(Seed("control"));
        var slide = presentation.Slides[0];

        if (slide.Controls.Count > 0)
        {
            // Remove the first ActiveX control.
            slide.Controls.RemoveAt(0);
        }

        presentation.Save("removed_activex.pptm", SaveFormat.Pptm);

        VerifyCase03(presentation);
    }
}
