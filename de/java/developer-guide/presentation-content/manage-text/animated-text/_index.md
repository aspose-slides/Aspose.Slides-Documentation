---
title: PowerPoint-Text in Java animieren
linktitle: Animierter Text
type: docs
weight: 60
url: /de/java/animated-text/
keywords:
- animierter Text
- Textanimation
- animierter Absatz
- Absatzanimation
- Animationseffekt
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Erstellen Sie dynamischen, animierten Text in PowerPoint- und OpenDocument-Präsentationen mithilfe von Aspose.Slides für Java, mit leicht nachvollziehbaren, optimierten Java-Codebeispielen."
---

## **Animations-Effekte zu Absätzen hinzufügen**

Wir haben die [**addEffect()**](https://reference.aspose.com/slides/java/com.aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) Methode zu den Klassen [**Sequence**](https://reference.aspose.com/slides/java/com.aspose.slides/Sequence) und [**ISequence**](https://reference.aspose.com/slides/java/com.aspose.slides/ISequence) hinzugefügt. Diese Methode ermöglicht das Hinzufügen von Animations‑Effekten zu einem einzelnen Absatz. Der Beispielcode zeigt, wie man einen Animations‑Effekt zu einem einzelnen Absatz hinzufügt:
```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Absatz auswählen, dem ein Effekt hinzugefügt werden soll
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

Möglicherweise möchten Sie die zu einem Absatz hinzugefügten Animations‑Effekte herausfinden – zum Beispiel, wenn Sie die Animations‑Effekte eines Absatzes erhalten wollen, weil Sie diese Effekte einem anderen Absatz oder einer anderen Form zuweisen möchten.

Aspose.Slides für Java ermöglicht es Ihnen, alle auf Absätze in einem Textfeld (Form) angewendeten Animations‑Effekte abzurufen. Der Beispielcode zeigt, wie man die Animations‑Effekte in einem Absatz erhält:
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

Textanimationen steuern das Verhalten von Objekten im Laufe der Zeit auf einer Folie, während [Übergänge](/slides/de/java/slide-transition/) bestimmen, wie Folien wechseln. Sie sind unabhängig voneinander und können zusammen verwendet werden; die Abspielreihenfolge wird vom Animations‑Zeitplan und den Übergangseinstellungen bestimmt.

**Werden Textanimationen beim Exportieren zu PDF oder Bildern beibehalten?**

Nein. PDF‑ und Rasterbilder sind statisch, daher sehen Sie nur einen einzelnen Zustand der Folie ohne Bewegung. Um die Bewegung beizubehalten, verwenden Sie den Export als [Video](/slides/de/java/convert-powerpoint-to-video/) oder [HTML](/slides/de/java/export-to-html5/).

**Funktionieren Textanimationen in Layouts und im Folienmaster?**

Auf Layout‑/Master‑Objekte angewendete Effekte werden von den Folien übernommen, aber ihr Timing und die Interaktion mit Folien‑Animationen hängen von der endgültigen Reihenfolge auf der Folie ab.