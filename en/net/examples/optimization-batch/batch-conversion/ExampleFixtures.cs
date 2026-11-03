using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    private static void CreateInput()
    {
        Example.Setup();
        Directory.CreateDirectory("output/inputs/a");
        Directory.CreateDirectory("output/inputs/b");
        foreach (var item in new[]
        {
            ("a/shared.pptx", "North"),
            ("b/shared.pptx", "South"),
            ("later.pptx", "Processed after failures")
        }

        )
        {
            using var p = new Presentation();
            Example.Text(p.Slides[0].Shapes, "Text", item.Item2);
            p.Save("output/inputs/" + item.Item1, SaveFormat.Pptx);
        }

        File.WriteAllBytes("output/inputs/corrupt.pptx", new byte[] { 0x50, 0x4b, 3, 4, 0, 0, 0 });
        using (var p = new Presentation())
        {
            p.ProtectionManager.Encrypt("SyntheticExamplePassword");
            p.Save("output/inputs/locked.pptx", SaveFormat.Pptx);
        }
    }
}
