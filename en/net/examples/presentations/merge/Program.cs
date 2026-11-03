using System;
using System.Drawing;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    private static void RunExample()
    {
        CreateDeck("blue.pptx", "A", Color.LightBlue);
        CreateDeck("green.pptx", "B", Color.LightGreen);
        string blueHash = Hash("blue.pptx"), greenHash = Hash("green.pptx");
        using var blue = new Presentation("blue.pptx");
        using var green = new Presentation("green.pptx");
        using (var merged = new Presentation())
        {
            merged.Slides.RemoveAt(0); // Remove the destination's default blank slide.
            foreach (var slide in blue.Slides)
                merged.Slides.AddClone(slide);
            foreach (var slide in green.Slides)
                merged.Slides.AddClone(slide);
            merged.Save("merged.pptx", SaveFormat.Pptx);
        }

        using (var merged = new Presentation("merged.pptx"))
        {
            Require(merged.Slides.Select(Text).SequenceEqual(new[] { "A1", "A2", "A3", "B1", "B2", "B3" }), "Merged order differs.");
            Require(merged.Slides[0].LayoutSlide.MasterSlide.Background.FillFormat.SolidFillColor.Color.ToArgb() == Color.LightBlue.ToArgb(), "Blue master was lost.");
            Require(merged.Slides[3].LayoutSlide.MasterSlide.Background.FillFormat.SolidFillColor.Color.ToArgb() == Color.LightGreen.ToArgb(), "Green master was lost.");
            Require(merged.Slides[3].NotesSlideManager.NotesSlide.NotesTextFrame.Text.Contains(Context.ExpectedText("Notes for B1")), "Speaker notes were lost.");
            using var first = merged.Slides[0].GetImage(new Size(640, 360));
            first.Save("source-design-blue.png", Aspose.Slides.ImageFormat.Png);
            using var fourth = merged.Slides[3].GetImage(new Size(640, 360));
            fourth.Save("source-design-green.png", Aspose.Slides.ImageFormat.Png);
        }

        using (var selected = new Presentation())
        {
            selected.Slides.RemoveAt(0);
            selected.Slides.AddClone(blue.Slides[2]);
            selected.Slides.AddClone(green.Slides[0]);
            selected.Save("selected.pptx", SaveFormat.Pptx);
        }

        CheckOrder("selected.pptx", "A3", "B1");
        using (var destination = new Presentation("blue.pptx"))
        {
            // Remove slides in reverse order, retaining the blue master and layouts.
            for (int i = destination.Slides.Count - 1; i >= 0; i--)
                destination.Slides.RemoveAt(i);
            var destinationLayout = destination.LayoutSlides.GetByType(SlideLayoutType.Blank);
            destination.Slides.AddClone(green.Slides[0], destinationLayout);
            destination.Save("destination-design.pptx", SaveFormat.Pptx);
        }

        using (var result = new Presentation("destination-design.pptx"))
        {
            Require(result.Slides.Count == 1 && Text(result.Slides[0]) == "B1", "Destination slide differs.");
            Require(result.Slides[0].LayoutSlide.MasterSlide.Background.FillFormat.SolidFillColor.Color.ToArgb() == Color.LightBlue.ToArgb(), "Destination layout was not applied.");
            using var image = result.Slides[0].GetImage(new Size(640, 360));
            image.Save("destination-design.png", Aspose.Slides.ImageFormat.Png);
        }

        Require(Hash("blue.pptx") == blueHash && Hash("green.pptx") == greenHash, "A source file changed.");
        Report(new { merged_slides = 6, selected_slides = 2, order_verified = true, source_masters_retained = true, destination_layout_applied = true, notes_retained = true, originals_unchanged = true });
    }
}
