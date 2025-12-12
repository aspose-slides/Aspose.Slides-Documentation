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
description: "Erstellen Sie dynamischen, animierten Text in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Android, anhand leicht verständlicher, optimierter Java-Codebeispiele."
---

## **Animations‑Effekte zu Absätzen hinzufügen**

Wir haben die [**addEffect()**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-)‑Methode zu den Klassen [**Sequence**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Sequence) und [**ISequence**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISequence) hinzugefügt. Diese Methode ermöglicht es Ihnen, Animations‑Effekte zu einem einzelnen Absatz hinzuzufügen. Dieser Beispielcode zeigt, wie Sie einem einzelnen Absatz einen Animations‑Effekt hinzufügen:
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

Möglicherweise möchten Sie die zu einem Absatz hinzugefügten Animations‑Effekte herausfinden – zum Beispiel in einem Szenario, in dem Sie die Effekte eines Absatzes erhalten, weil Sie diese auf einen anderen Absatz oder ein Shape anwenden wollen.

Aspose.Slides für Android via Java ermöglicht das Abrufen aller auf Absätze in einem Textfeld (Shape) angewendeten Animations‑Effekte. Dieser Beispielcode zeigt, wie Sie die Animations‑Effekte in einem Absatz abrufen:
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

**Wie unterscheiden sich Textanimationen von Folienübergängen und können sie kombiniert werden?**

Textanimationen steuern das Verhalten von Objekten über die Zeit auf einer Folie, während [transitions](/slides/de/androidjava/slide-transition/) steuern, wie Folien wechseln. Sie sind unabhängig und können zusammen verwendet werden; die Wiedergabereihenfolge wird vom Animations‑Zeitplan und den Übergangseinstellungen bestimmt.

**Werden Textanimationen beim Exportieren in PDF oder Bilder beibehalten?**

Nein. PDF und Rasterbilder sind statisch, sodass Sie nur einen einzelnen Zustand der Folie ohne Bewegung sehen. Um Bewegung zu erhalten, verwenden Sie den Export nach [video](/slides/de/androidjava/convert-powerpoint-to-video/) oder [HTML](/slides/de/androidjava/export-to-html5/).

**Funktionieren Textanimationen in Layouts und der Folienmaster?**

Effekte, die auf Layout‑/Master‑Objekte angewendet werden, werden von Folien geerbt, aber ihr Timing und ihre Interaktion mit Folien‑Animationen hängen von der endgültigen Reihenfolge auf der Folie ab.