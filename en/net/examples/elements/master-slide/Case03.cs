using Aspose.Slides;

internal static partial class Program
{
    static void Case03()
    {
        using var presentation = new Presentation(Seed("master"));
        var secondUnusedMaster = presentation.Masters[2];

        // Remove the first explicitly unused master by index.
        presentation.Masters.RemoveAt(1);

        // Remove a master slide by reference.
        presentation.Masters.Remove(secondUnusedMaster);

        VerifyCase03(presentation);
    }
}
