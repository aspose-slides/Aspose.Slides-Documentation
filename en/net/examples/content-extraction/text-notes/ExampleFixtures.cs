using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    private static void CreateInput()
    {
        Example.Setup();
        using (var p = new Presentation())
        {
            var slide = p.Slides[0];
            Example.Text(slide.Shapes, "Title", Example.Choice("Résumé – 東京", "東京 β"));
            var group = slide.Shapes.AddGroupShape();
            Example.Text(group.Shapes, "Group text", Example.Choice("Grouped α", "α"));
            var nested = group.Shapes.AddGroupShape();
            Example.Text(nested.Shapes, "Nested text", Example.Choice("Nested β", "β"));
            Example.Text(slide.Shapes, "Empty", "");
            slide.NotesSlideManager.AddNotesSlide().NotesTextFrame.Text = Example.Choice("Speaker notes ✓", "✓");
            var hidden = p.Slides.AddEmptySlide(p.LayoutSlides[0]);
            hidden.Hidden = true;
            Example.Text(hidden.Shapes, "Hidden text", Example.Choice("Hidden slide", "Hide"));
            p.Save("output/input.pptx", SaveFormat.Pptx);
        }
    }
}
