using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;

internal static partial class Program
{
    static void Case04()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
        var shape2 = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 200, 50, 100, 100);

        var sequence = slide.Timeline.MainSequence;
        sequence.AddEffect(shape1, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);
        sequence.AddEffect(shape2, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-004", p =>
        {
            Context.Require(p.Slides[0].Timeline.MainSequence.Count == 2 && ((IAutoShape)p.Slides[0].Timeline.MainSequence[0].TargetShape).ShapeType == ShapeType.Rectangle && ((IAutoShape)p.Slides[0].Timeline.MainSequence[1].TargetShape).ShapeType == ShapeType.Ellipse, "SequenceAnimations: semantic check 1 failed.");
        });
        Context.Pass("elements/animation/block-004", "SequenceAnimations", "save-reopen-structure");
    }
}
