using Aspose.Slides;

internal static partial class Program
{
    static void Case03()
    {
        using var presentation = new Presentation(Seed("master"));

        // Remove the first explicitly unused master by index.
        presentation.Masters.RemoveAt(1);

        // Remove a master slide by reference.
        var firstMasterSlide = presentation.Masters[1];
        presentation.Masters.Remove(firstMasterSlide);

        VerifyCase03(presentation);
    }
}
