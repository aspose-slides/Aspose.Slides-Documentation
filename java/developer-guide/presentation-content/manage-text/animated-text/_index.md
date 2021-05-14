---
title: Animated Text
type: docs
weight: 50
url: /java/animated-text/
keywords: "Animated text in PowerPoint"
description: "Animated text in PowerPoint with Java"
---

## **Add Animation Effect to Paragraph**
The [**addEffect()**](https://apireference.aspose.com/slides/java/com.aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) method has been added to the [**Sequence**](https://apireference.aspose.com/slides/java/com.aspose.slides/Sequence) and [**ISequence**](https://apireference.aspose.com/slides/java/com.aspose.slides/ISequence) classes. It allows to add a new animation effect for a single paragraph. The following example shows how to add animation effect for a single paragraph.

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // select paragraph to add effect
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // add Fly animation effect to selected paragraph
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().
            addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Get Animation Effects of Paragraph**
Aspose.Slides for Java provides support for getting all animation effects applied to paragraphs of text frame (shape). Below is the sample code given.

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
