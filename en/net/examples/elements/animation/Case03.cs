using Aspose.Slides;
using Aspose.Slides.Animation;

internal static partial class Program
{
    static void Case03()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var sequence = slide.Timeline.MainSequence;
        var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
        var effect = sequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

        // Remove the effect.
        sequence.Remove(effect);

        VerifyCase03(presentation);
    }
}
