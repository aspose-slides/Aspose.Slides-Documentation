---
title: Animierter Text
type: docs
weight: 60
url: /de/java/animated-text/
keywords: "Animierter Text in PowerPoint"
description: "Animierter Text in PowerPoint mit Java"
---

## Hinzufügen von Animationseffekten zu Absätzen

Wir haben die [**addEffect()**](https://reference.aspose.com/slides/java/com.aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) Methode zu den [**Sequence**](https://reference.aspose.com/slides/java/com.aspose.slides/Sequence) und [**ISequence**](https://reference.aspose.com/slides/java/com.aspose.slides/ISequence) Klassen hinzugefügt. Diese Methode ermöglicht es Ihnen, Animationseffekte zu einem einzelnen Absatz hinzuzufügen. Dieser Beispielcode zeigt Ihnen, wie man einen Animationseffekt zu einem einzelnen Absatz hinzufügt:

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // wählen Sie den Absatz aus, um den Effekt hinzuzufügen
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Fügen Sie den Fly-Animationseffekt zum ausgewählten Absatz hinzu
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().
            addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## Abrufen der Animationseffekte in Absätzen

Sie können entscheiden, die Animationseffekte, die zu einem Absatz hinzugefügt wurden, zu finden – zum Beispiel, in einem Szenario möchten Sie die Animationseffekte in einem Absatz abrufen, weil Sie planen, diese Effekte auf einen anderen Absatz oder eine Form anzuwenden.

Aspose.Slides für Java ermöglicht es Ihnen, alle Animationseffekte abzurufen, die auf Absätze angewendet wurden, die sich in einem Textfeld (Form) befinden. Dieser Beispielcode zeigt Ihnen, wie man die Animationseffekte in einem Absatz abruft:

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    IAutoShape autoShape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs())
    {
        IEffect[] effects = sequence.getEffectsByParagraph(paragraph);

        if (effects.length > 0)
            System.out.println("Absatz \"" + paragraph.getText() + "\" hat " + effects[0].getType() + " Effekt.");
    }
} finally {
    pres.dispose();
}
```