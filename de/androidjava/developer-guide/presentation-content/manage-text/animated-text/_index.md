---
title: PowerPoint-Text auf Android animieren
linktitle: Animierter Text
type: docs
weight: 60
url: /de/androidjava/animated-text/
keywords:
- animierter Text
- Textanimation
- animierter Absatz
- Absatzanimation
- Animationseffekt
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erstellen Sie dynamischen animierten Text in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Android, anhand leicht nachvollziehbarer, optimierter Java-Codebeispiele."
---

## **Animations‑Effekte zu Absätzen hinzufügen**

Wir haben die Methode [**addEffect()**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) zu den Klassen [**Sequence**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Sequence) und [**ISequence**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISequence) hinzugefügt. Diese Methode ermöglicht es Ihnen, Animations‑Effekte zu einem einzelnen Absatz hinzuzufügen. Dieser Beispielcode zeigt, wie Sie einen Animations‑Effekt zu einem einzelnen Absatz hinzufügen:
```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Absatz auswählen, um Effekt hinzuzufügen
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Fly-Animationseffekt zum ausgewählten Absatz hinzufügen
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().
            addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **Animations‑Effekte von Absätzen abrufen**

Möglicherweise möchten Sie die zu einem Absatz hinzugefügten Animations‑Effekte ermitteln – zum Beispiel, wenn Sie die Effekte eines Absatzes erhalten wollen, um sie auf einen anderen Absatz oder ein Shape anzuwenden.

Aspose.Slides für Android via Java ermöglicht es Ihnen, alle auf Absätze in einem Textfeld (Shape) angewendeten Animations‑Effekte abzurufen. Dieser Beispielcode zeigt, wie Sie die Animations‑Effekte in einem Absatz erhalten:
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    IAutoShape autoShape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs())
    {
        IEffect[] effects = sequence.getEffectsByParagraph(paragraph);

        if (effects.length > 0)
            System.out.println("Paragraph \"" + paragraph.getText() + "\" has " + effects[0].getType() + " effect.");
    }
} finally {
    pres.dispose();
}
```


## **FAQ**

**Wie unterscheiden sich Textanimationen von Folienübergängen, und können sie kombiniert werden?**

Textanimationen steuern das Verhalten eines Objekts über die Zeit auf einer Folie, während [transitions](/slides/de/androidjava/slide-transition/) festlegen, wie Folien wechseln. Sie sind unabhängig und können zusammen verwendet werden; die Wiedergabereihenfolge wird vom Animations‑Zeitstrahl und den Transition‑Einstellungen bestimmt.

**Werden Textanimationen beim Exportieren in PDF oder Bilder beibehalten?**

Nein. PDF und Rasterbilder sind statisch, sodass Sie nur einen einzelnen Zustand der Folie ohne Bewegung sehen. Um die Bewegung beizubehalten, verwenden Sie den Export als [video](/slides/de/androidjava/convert-powerpoint-to-video/) oder [HTML](/slides/de/androidjava/export-to-html5/).

**Funktionieren Textanimationen in Layouts und im Folienmaster?**

Auf Layout‑/Master‑Objekte angewendete Effekte werden von Folien geerbt, wobei deren Timing und Interaktion mit Folien‑Animationen von der endgültigen Sequenz auf der Folie abhängen.