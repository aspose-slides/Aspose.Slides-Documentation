using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    static void Case01()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        // Add a new ActiveX control.
        var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

        // Optionally set some properties.
        control.Properties["Value"] = "Text";

        presentation.Save("add_activex.pptm", SaveFormat.Pptm);

        VerifyCase01(presentation);
    }
}
