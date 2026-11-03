using Aspose.Slides;
using Aspose.Slides.Vba;

internal static partial class Program
{
    static void Case01()
    {
        using var presentation = new Presentation();
        presentation.VbaProject = new VbaProject();

        var module = presentation.VbaProject.Modules.AddEmptyModule("Module");
        module.SourceCode = """
            Sub Test()
                MsgBox "Hi"
            End Sub
            """;

        VerifyCase01(presentation);
    }
}
