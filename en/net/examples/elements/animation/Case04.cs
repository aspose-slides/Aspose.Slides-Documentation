using Aspose.Slides;
using Aspose.Slides.Animation;

internal static partial class Program
{
    static void Case04()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var rectangle = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
        var ellipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 200, 50, 100, 100);

        var sequence = slide.Timeline.MainSequence;
        sequence.AddEffect(rectangle, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);
        sequence.AddEffect(ellipse, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);

        VerifyCase04(presentation);
    }
}
