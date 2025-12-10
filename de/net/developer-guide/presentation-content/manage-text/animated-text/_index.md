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
description: "Erstellen Sie dynamischen, animierten Text in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für .NET, mit leicht nachvollziehbaren, optimierten C#-Codebeispielen."
---

## **Animations‑Effekte zu Absätzen hinzufügen**

Wir haben die Methode [**AddEffect()**](https://reference.aspose.com/slides/net/aspose.slides.animation/sequence/methods/addeffect/index) zu den Klassen [**Sequence**](https://reference.aspose.com/slides/net/aspose.slides.animation/sequence) und [**ISequence**](https://reference.aspose.com/slides/net/aspose.slides.animation/isequence) hinzugefügt. Diese Methode ermöglicht es Ihnen, Animations‑Effekte zu einem einzelnen Absatz hinzuzufügen. Der folgende Beispielcode zeigt, wie Sie einen Animations‑Effekt zu einem einzelnen Absatz hinzufügen:
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


## **Animations‑Effekte für Absätze abrufen**

Möglicherweise möchten Sie die zu einem Absatz hinzugefügten Animations‑Effekte herausfinden – zum Beispiel, wenn Sie die Animations‑Effekte eines Absatzes erhalten wollen, weil Sie diese auf einen anderen Absatz oder ein anderes Shape anwenden möchten.

Aspose.Slides für .NET ermöglicht es Ihnen, alle auf Absätze in einem Textfeld (Shape) angewendeten Animations‑Effekte zu erhalten. Der folgende Beispielcode zeigt, wie Sie die Animations‑Effekte in einem Absatz abrufen:
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

**Wie unterscheiden sich Textanimationen von Folienübergängen und können sie kombiniert werden?**

Textanimationen steuern das Verhalten von Objekten über die Zeit auf einer Folie, während [transitions](/slides/de/net/slide-transition/) steuern, wie Folien wechseln. Sie sind unabhängig und können zusammen verwendet werden; die Wiedergabereihenfolge wird durch die Animations‑Zeitleiste und die Übergangseinstellungen bestimmt.

**Werden Textanimationen beim Exportieren in PDF oder Bilder beibehalten?**

Nein. PDF und Rasterbilder sind statisch, sodass Sie nur einen einzelnen Zustand der Folie ohne Bewegung sehen. Um die Bewegung zu erhalten, verwenden Sie den Export nach [video](/slides/de/net/convert-powerpoint-to-video/) oder [HTML](/slides/de/net/export-to-html5/).

**Funktionieren Textanimationen in Layouts und im Folienmaster?**

Auf Layout‑/Master‑Objekte angewendete Effekte werden von den Folien geerbt, aber ihr Timing und die Interaktion mit Folien‑Animationen hängen von der endgültigen Sequenz auf der Folie ab.