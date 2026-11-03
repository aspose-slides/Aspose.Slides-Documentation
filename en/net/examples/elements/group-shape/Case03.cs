using Aspose.Slides;

internal static partial class Program
{
    static void Case03()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var group = slide.Shapes.AddGroupShape();

        slide.Shapes.Remove(group);

        VerifyCase03(presentation);
    }
}
