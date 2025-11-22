---
title: Animierter Text
type: docs
weight: 60
url: /de/net/animated-text/
keywords: "Animierter Text, Animationseffekte, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides for .NET"
description: "Animierten Text und Effekte zu einer PowerPoint-Präsentation in C# oder .NET hinzufügen"
---

## **Hinzufügen von Animationseffekten zu Absätzen**

Wir haben die [**AddEffect()**](https://reference.aspose.com/slides/net/aspose.slides.animation/sequence/methods/addeffect/index) Methode zur [**Sequence**](https://reference.aspose.com/slides/net/aspose.slides.animation/sequence) und [**ISequence**](https://reference.aspose.com/slides/net/aspose.slides.animation/isequence) Klasse hinzugefügt. Mit dieser Methode können Sie einem einzelnen Absatz Animations­effekte hinzufügen. Der folgende Beispielcode zeigt, wie Sie einem einzelnen Absatz einen Animations­effekt hinzufügen:
```c#
using (Presentation presentation = new Presentation(dataDir + "Presentation1.pptx"))
{
    // Absatz auswählen, um Effekt hinzuzufügen
    IAutoShape autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];

    // Fly-Animationseffekt zum ausgewählten Absatz hinzufügen
    IEffect effect = presentation.Slides[0].Timeline.MainSequence.AddEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);


    presentation.Save(dataDir + "AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
}
```


## **Abrufen der Animationseffekte in Absätzen**

Sie möchten möglicherweise die zu einem Absatz hinzugefügten Animations­effekte herausfinden – zum Beispiel, wenn Sie die Animations­effekte eines Absatzes erhalten wollen, um sie auf einen anderen Absatz oder ein Shape anzuwenden.

Aspose.Slides for .NET ermöglicht es Ihnen, alle auf Absätze in einem Textfeld (Shape) angewendeten Animations­effekte abzurufen. Der folgende Beispielcode zeigt, wie Sie die Animations­effekte in einem Absatz abrufen:
```c#
using (Presentation pres = new Presentation("Test.pptx"))
{
	ISequence sequence = pres.Slides[0].Timeline.MainSequence;
	IAutoShape autoShape = (IAutoShape)pres.Slides[0].Shapes[1];

	foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs)
	{
		IEffect[] effects = sequence.GetEffectsByParagraph(paragraph);

		if (effects.Length > 0)
			Console.WriteLine("Paragraph \"" + paragraph.Text + "\" has " + effects[0].Type + " effect.");
	}
}
```


## **FAQ**

**Wie unterscheiden sich Textanimationen von Folienübergängen, und können sie kombiniert werden?**

Textanimationen steuern das Verhalten von Objekten über die Zeit auf einer Folie, während [transitions](/slides/de/net/slide-transition/) kontrollieren, wie Folien wechseln. Sie sind unabhängig und können zusammen verwendet werden; die Wiedergabereihenfolge wird durch die Animations­zeitlinie und die Übergangseinstellungen bestimmt.

**Werden Textanimationen beim Exportieren in PDF oder Bilder beibehalten?**

Nein. PDF und Rasterbilder sind statisch, sodass Sie einen einzelnen Zustand der Folie ohne Bewegung sehen. Um die Bewegung zu erhalten, verwenden Sie den Export als [video](/slides/de/net/convert-powerpoint-to-video/) oder [HTML](/slides/de/net/export-to-html5/).

**Funktionieren Textanimationen in Layouts und im Folienmaster?**

Auf Layout-/Master‑Objekte angewendete Effekte werden von den Folien geerbt, jedoch hängen ihr Timing und ihre Interaktion mit Folien‑Ebene‑Animationen von der endgültigen Reihenfolge auf der Folie ab.