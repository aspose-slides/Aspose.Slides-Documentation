using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    static void Case04()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        // Add a Windows Media Player control and configure its properties.
        var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50);
        control.Properties["Caption"] = "Run";
        control.Properties["Enabled"] = "true";

        presentation.Save("set_activex_props.pptm", SaveFormat.Pptm);

        VerifyCase04(presentation);
    }
}
