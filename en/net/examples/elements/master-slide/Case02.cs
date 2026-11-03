using Aspose.Slides;

internal static partial class Program
{
    static void Case02()
    {
        using var presentation = new Presentation();

        // Access the first master slide.
        var firstMasterSlide = presentation.Masters[0];

        // Change the background type.
        firstMasterSlide.Background.Type = BackgroundType.OwnBackground;

        VerifyCase02(presentation);
    }
}
