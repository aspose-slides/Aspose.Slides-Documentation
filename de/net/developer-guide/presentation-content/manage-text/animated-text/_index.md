---
title: PowerPoint-Text in .NET animieren
linktitle: Animierter Text
type: docs
weight: 60
url: /de/net/animated-text/
keywords:
- animierter Text
- Textanimation
- animierter Absatz
- Absatzanimation
- Animationseffekt
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erstellen Sie dynamischen animierten Text in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für .NET, anhand leicht nachvollziehbarer, optimierter C#-Codebeispiele."
---

## **Hinzufügen von Animationseffekten zu Absätzen**

Wir haben die Methode [**AddEffect()**](https://reference.aspose.com/slides/net/aspose.slides.animation/sequence/methods/addeffect/index) zur Klasse [**Sequence**](https://reference.aspose.com/slides/net/aspose.slides.animation/sequence) und zur Klasse [**ISequence**](https://reference.aspose.com/slides/net/aspose.slides.animation/isequence) hinzugefügt. Diese Methode ermöglicht es, einem einzelnen Absatz Animations‑Effekte hinzuzufügen. Der Beispielcode zeigt, wie man einem einzelnen Absatz einen Animations‑Effekt hinzufügt:
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


## **Abrufen der Animations‑Effekte in Absätzen**

Vielleicht möchten Sie die zu einem Absatz hinzugefügten Animations‑Effekte ermitteln – zum Beispiel, wenn Sie die Animations‑Effekte eines Absatzes erhalten wollen, um sie auf einen anderen Absatz oder eine Form anzuwenden. Aspose.Slides for .NET ermöglicht es, alle auf in einem Textfeld (Form) enthaltenen Absätzen angewendeten Animations‑Effekte abzurufen. Der Beispielcode zeigt, wie man die Animations‑Effekte in einem Absatz abruft:
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

Textanimationen steuern das Verhalten von Objekten im Zeitverlauf einer Folie, während [transitions](/slides/de/net/slide-transition/) festlegen, wie Folien wechseln. Sie sind unabhängig und können gemeinsam verwendet werden; die Wiedergabereihenfolge wird vom Animations‑Zeitplan und den Übergangseinstellungen bestimmt.

**Werden Textanimationen beim Exportieren in PDF oder Bilder beibehalten?**

Nein. PDF‑Dateien und Rasterbilder sind statisch, sodass Sie nur einen einzelnen Zustand der Folie ohne Bewegung sehen. Um die Animation beizubehalten, verwenden Sie den Export als [video](/slides/de/net/convert-powerpoint-to-video/) oder als [HTML](/slides/de/net/export-to-html5/).

**Funktionieren Textanimationen in Layouts und im Folienmaster?**

Auf Layout‑/Master‑Objekte angewendete Effekte werden von den Folien geerbt, jedoch hängen ihr Timing und ihre Interaktion mit Folien‑Animationen von der endgültigen Reihenfolge auf der Folie ab.