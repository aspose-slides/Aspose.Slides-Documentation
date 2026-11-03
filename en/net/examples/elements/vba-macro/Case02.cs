using Aspose.Slides;
using Aspose.Slides.Vba;

internal static partial class Program
{
    static void Case02()
    {
        using var presentation = new Presentation();
        presentation.VbaProject = new VbaProject();

        var module = presentation.VbaProject.Modules.AddEmptyModule("Module");
        module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";

        var firstModule = presentation.VbaProject.Modules[0];

        VerifyCase02(presentation);
    }
}
