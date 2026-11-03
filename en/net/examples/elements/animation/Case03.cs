using Aspose.Slides;
using Aspose.Slides.Animation;

internal static partial class Program
{
    static void Case03()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
        var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

        // Remove the effect.
        slide.Timeline.MainSequence.Remove(effect);

        VerifyCase03(presentation);
    }
}
