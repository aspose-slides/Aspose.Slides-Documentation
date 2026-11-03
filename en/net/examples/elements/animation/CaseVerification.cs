using Aspose.Slides.Animation;
using Aspose.Slides.Export;
using Aspose.Slides;
using System.IO;
using System.Linq;
using System;

internal static partial class Program
{
    private static void VerifyCase01(Presentation presentation)
    {
        RoundTrip(presentation, "block-001", p =>
        {
            Context.Require(p.Slides[0].Timeline.MainSequence.Count == 1 && p.Slides[0].Timeline.MainSequence[0].Type == EffectType.Fade, "AddAnimation: semantic check 1 failed.");
        });
        Context.Pass("elements/animation/block-001", "AddAnimation", "save-reopen-structure");
    }

    private static void VerifyCase02(Presentation presentation)
    {
        RoundTrip(presentation, "block-002", p =>
        {
            Context.Require(p.Slides[0].Timeline.MainSequence.Count == 1 && p.Slides[0].Timeline.MainSequence[0].Type == EffectType.Fade, "AccessAnimation: semantic check 1 failed.");
        });
        Context.Pass("elements/animation/block-002", "AccessAnimation", "save-reopen-structure");
    }

    private static void VerifyCase03(Presentation presentation)
    {
        RoundTrip(presentation, "block-003", p =>
        {
            Context.Require(p.Slides[0].Timeline.MainSequence.Count == 0, "RemoveAnimation: semantic check 1 failed.");
        });
        Context.Pass("elements/animation/block-003", "RemoveAnimation", "save-reopen-structure");
    }

    private static void VerifyCase04(Presentation presentation)
    {
        RoundTrip(presentation, "block-004", p =>
        {
            Context.Require(p.Slides[0].Timeline.MainSequence.Count == 2 && ((IAutoShape)p.Slides[0].Timeline.MainSequence[0].TargetShape).ShapeType == ShapeType.Rectangle && ((IAutoShape)p.Slides[0].Timeline.MainSequence[1].TargetShape).ShapeType == ShapeType.Ellipse, "SequenceAnimations: semantic check 1 failed.");
        });
        Context.Pass("elements/animation/block-004", "SequenceAnimations", "save-reopen-structure");
    }
}
