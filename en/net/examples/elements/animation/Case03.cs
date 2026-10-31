using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;
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

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-003", p =>
        {
            Context.Require(p.Slides[0].Timeline.MainSequence.Count == 0, "RemoveAnimation: semantic check 1 failed.");
        });
        Context.Pass("elements/animation/block-003", "RemoveAnimation", "save-reopen-structure");
    }
}
