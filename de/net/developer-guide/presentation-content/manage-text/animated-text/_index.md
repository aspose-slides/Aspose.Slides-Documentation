---
title: Animierter Text
type: docs
weight: 60
url: /net/animierter-text/
keywords: "Animierter Text, Animationseffekte, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "Fügen Sie animierten Text und Effekte zu einer PowerPoint-Präsentation in C# oder .NET hinzu"
---

## Hinzufügen von Animationseffekten zu Absätzen

Wir haben die [**AddEffect()**](https://reference.aspose.com/slides/net/aspose.slides.animation/sequence/methods/addeffect/index) Methode zu den [**Sequence**](https://reference.aspose.com/slides/net/aspose.slides.animation/sequence) und [**ISequence**](https://reference.aspose.com/slides/net/aspose.slides.animation/isequence) Klassen hinzugefügt. Diese Methode ermöglicht es Ihnen, Animationseffekte zu einem einzelnen Absatz hinzuzufügen. Dieser Beispielcode zeigt Ihnen, wie Sie einen Animationseffekt zu einem einzelnen Absatz hinzufügen:

```c#
using (Presentation presentation = new Presentation(dataDir + "Presentation1.pptx"))
{
    // Absatz zum Hinzufügen eines Effekts auswählen
    IAutoShape autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];

    // Fly-Animationseffekt zum ausgewählten Absatz hinzufügen
    IEffect effect = presentation.Slides[0].Timeline.MainSequence.AddEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    presentation.Save(dataDir + "AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
}
```



## Abrufen der Animationseffekte in Absätzen

Sie möchten möglicherweise herausfinden, welche Animationseffekte einem Absatz hinzugefügt wurden – zum Beispiel in einem Szenario, in dem Sie die Animationseffekte in einem Absatz abrufen möchten, weil Sie planen, diese Effekte auf einen anderen Absatz oder eine andere Form anzuwenden.

Aspose.Slides für .NET ermöglicht es Ihnen, alle Animationseffekte abzurufen, die auf die Absätze in einem Textfeld (Form) angewendet wurden. Dieser Beispielcode zeigt Ihnen, wie Sie die Animationseffekte in einem Absatz abrufen:

```c#
using (Presentation pres = new Presentation("Test.pptx"))
{
	ISequence sequence = pres.Slides[0].Timeline.MainSequence;
	IAutoShape autoShape = (IAutoShape)pres.Slides[0].Shapes[1];

	foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs)
	{
		IEffect[] effects = sequence.GetEffectsByParagraph(paragraph);

		if (effects.Length > 0)
			Console.WriteLine("Absatz \"" + paragraph.Text + "\" hat " + effects[0].Type + " Effekt.");
	}
}
```