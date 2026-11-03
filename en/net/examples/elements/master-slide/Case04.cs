using Aspose.Slides;

internal static partial class Program
{
    static void Case04()
    {
        using var presentation = new Presentation();

        presentation.Masters.AddClone(presentation.Masters[0]).Name = "Unused";

        // Remove all unused master slides (even those marked as Preserve).
        presentation.Masters.RemoveUnused(ignorePreserveField: true);

        VerifyCase04(presentation);
    }
}
