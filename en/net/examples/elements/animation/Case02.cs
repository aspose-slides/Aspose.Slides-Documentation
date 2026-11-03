using Aspose.Slides;
using Aspose.Slides.Animation;

internal static partial class Program
{
    static void Case02()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
        slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

        // Access the first animation effect.
        var effect = slide.Timeline.MainSequence[0];

        VerifyCase02(presentation);
    }
}
