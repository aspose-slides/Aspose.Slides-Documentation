using System;
using System.Threading.Tasks;
using System.Drawing;
using System.IO.Compression;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

internal static partial class Program
{
    private static Task<int> Main(string[] args) => RunChecked(args);
    private static void CleanPresentation()
    {
        Example.Setup();
        using (var p = new Presentation())
        using (var unusedMasterSource = new Presentation())
        {
            Example.Text(p.Slides[0].Shapes, "Content", Example.Choice("Keep referenced content", "Keep"));
            p.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, 150, 100, p.Images.AddImage(Example.Png(150, 100, Color.Teal))).Name = "Required image";
            p.Masters.AddClone(unusedMasterSource.Masters[0]);
            p.Save("output/input.pptx", SaveFormat.Pptx);
            Example.Render(p, "output/before.png");
        }

        // Add an explicitly unreferenced package part to the synthetic fixture.
        using (var zip = ZipFile.Open("output/input.pptx", ZipArchiveMode.Update))
        {
            var entry = zip.CreateEntry("ppt/media/orphan.png");
            using var stream = entry.Open();
            stream.Write(Example.Png(30, 30, Color.Orange));
        }

        int mastersBefore, layoutsBefore;
        using (var p = new Presentation("output/input.pptx"))
        {
            mastersBefore = p.Masters.Count;
            layoutsBefore = p.LayoutSlides.Count;
            Example.Render(p, "output/before.png");
            Compress.RemoveUnusedLayoutSlides(p);
            Compress.RemoveUnusedMasterSlides(p);
            p.Save("output/cleaned.pptx", SaveFormat.Pptx);
            Example.Render(p, "output/after.png");
        }

        RemoveKnownUnreferencedImage("output/cleaned.pptx", "ppt/media/orphan.png");
        using var result = new Presentation("output/cleaned.pptx");
        Example.Require(result.Masters.Count < mastersBefore && result.LayoutSlides.Count < layoutsBefore, "Unused structures were not removed.");
        Example.Require(Example.Named<IAutoShape>(result.Slides[0], "Content").TextFrame.Text == Example.Choice("Keep referenced content", "Keep"), "Referenced text changed.");
        Example.Require(Example.Named<IPictureFrame>(result.Slides[0], "Required image").PictureFormat.Picture.Image.BinaryData.Length > 0, "Referenced media removed.");
        Example.Require(MediaParts("output/input.pptx") == 2 && MediaParts("output/cleaned.pptx") == 1, "The nominated unreferenced media part was not removed.");
        string referencedPart;
        using (var zip = ZipFile.OpenRead("output/cleaned.pptx"))
            referencedPart = zip.Entries.Single(e => e.FullName.StartsWith("ppt/media/", StringComparison.Ordinal)).FullName;
        bool protectedImage = Example.Throws(() => RemoveKnownUnreferencedImage("output/cleaned.pptx", referencedPart));
        Example.Require(protectedImage, "Referenced image was not protected.");
        Example.Require(Example.HashFile("output/before.png") == Example.HashFile("output/after.png"), "Rendered content changed.");
        Example.Json("output/counts.json", new { masters_before = mastersBefore, masters_after = result.Masters.Count, layouts_before = layoutsBefore, layouts_after = result.LayoutSlides.Count, media_before = 2, media_after = 1 });
        Example.Result(new { unused_structures_removed = true, referenced_content_preserved = true, nominated_unreferenced_image_removed = true, referenced_image_deletion_rejected = protectedImage, render_identical = true });
    }
}
