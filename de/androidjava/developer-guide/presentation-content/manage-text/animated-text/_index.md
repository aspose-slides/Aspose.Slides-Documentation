---
title: Animierter Text
type: docs
weight: 60
url: /androidjava/animated-text/
keywords: "Animierter Text in PowerPoint"
description: "Animierter Text in PowerPoint mit Java"
---

## Hinzufügen von Animationseffekten zu Absätzen

Wir haben die [**addEffect()**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) Methode zu den [**Sequence**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Sequence) und [**ISequence**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISequence) Klassen hinzugefügt. Mit dieser Methode können Sie Animationseffekte zu einem einzelnen Absatz hinzufügen. Dieser Beispielcode zeigt Ihnen, wie Sie einen Animationseffekt zu einem einzelnen Absatz hinzufügen:

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Absatz auswählen, um den Effekt hinzuzufügen
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

## Abrufen der Animationseffekte in Absätzen

Sie können beschließen, die Animationseffekte, die einem Absatz hinzugefügt wurden, herauszufinden—zum Beispiel in einem Szenario, in dem Sie die Animationseffekte in einem Absatz abrufen möchten, weil Sie planen, diese Effekte auf einen anderen Absatz oder eine Form anzuwenden.

Aspose.Slides für Android über Java ermöglicht es Ihnen, alle Animationseffekte abzurufen, die auf Absätze in einem Textfeld (Form) angewendet wurden. Dieser Beispielcode zeigt Ihnen, wie Sie die Animationseffekte in einem Absatz abrufen:

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