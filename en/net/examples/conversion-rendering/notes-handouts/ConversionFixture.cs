using System.Drawing;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Charts;
using Aspose.Slides.SlideShow;

internal static partial class Program
{
    private static Presentation CreateSource(bool licensed)
    {
        var deck = new Presentation();
        deck.SlideSize.SetSize(640, 360, SlideSizeScaleType.DoNotScale);
        var layout = deck.LayoutSlides.GetByType(SlideLayoutType.Blank);
        string[] labels = licensed ? new[] { "Alpha", "Bravo", "Charlie", "Hidden" } : new[] { "Alpha", "Bravo", "C", "Hide" };
        for (int i = 0; i < labels.Length; i++)
        {
            var slide = i == 0 ? deck.Slides[0] : deck.Slides.AddEmptySlide(layout);
            var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 20, 580, 55);
            shape.Name = "RecipeTitle";
            shape.TextFrame.Text = labels[i];
            shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData("Noto Sans");
            shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 26;
            slide.NotesSlideManager.AddNotesSlide().NotesTextFrame.Text = licensed ? "Speaker note " + labels[i] : labels[i];
            slide.Hidden = i == 3;
        }
        var table = deck.Slides[0].Shapes.AddTable(30, 100, new double[] { 140, 100 }, new double[] { 35, 35 });
        table[0, 0].TextFrame.Text = "Product";
        table[1, 0].TextFrame.Text = "Units";
        table[0, 1].TextFrame.Text = "Pens";
        table[1, 1].TextFrame.Text = "12";
        deck.Slides[1].Shapes.AddChart(ChartType.ClusteredColumn, 30, 100, 400, 220);
        var image = deck.Images.AddImage(PortableImage.Png(100,60,Color.CornflowerBlue));
        deck.Slides[2].Shapes.AddPictureFrame(ShapeType.Rectangle,50,120,200,120,image);
        deck.Slides[0].Timeline.MainSequence.AddEffect(deck.Slides[0].Shapes.OfType<IAutoShape>().Single(s => s.Name == "RecipeTitle"), EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);
        deck.Slides[0].SlideShowTransition.Type = TransitionType.Fade;
        return deck;
    }
}
