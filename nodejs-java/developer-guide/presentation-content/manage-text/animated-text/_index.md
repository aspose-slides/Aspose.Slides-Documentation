---
title: Animated Text
type: docs
weight: 60
url: /nodejs-java/animated-text/
keywords: "Animated text in PowerPoint"
description: "Animated text in PowerPoint with Java"
---

## Adding Animation Effects to Paragraphs

We added the [**addEffect()**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Sequence#addEffect-aspose.slides.IParagraph-int-int-int-) method to the [**Sequence**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Sequence) and [**ISequence**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ISequence) classes. This method allows you to add animation effects to a single paragraph. This sample code shows you how to add an animation effect to a single paragraph:

```javascript
    var presentation = new  aspose.slides.Presentation("Presentation.pptx");
    try {
        // select paragraph to add effect
        var autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
        var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
        // add Fly animation effect to selected paragraph
        var effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(paragraph, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.Left, aspose.slides.EffectTriggerType.OnClick);
        presentation.save("AnimationEffectinParagraph.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (presentation != null) {
            presentation.dispose();
        }
    }
```

## Getting the Animation Effects in Paragraphs

You may decide to find out the animation effects added to a paragraph—for example, in one scenario, you want to get the animation effects in a paragraph because you plan to apply those effects to another paragraph or shape.

Aspose.Slides for Java allows you to get all the animation effects applied to paragraphs contained in a text frame (shape). This sample code shows you how to get the animation effects in a paragraph:

```javascript
    var pres = new  aspose.slides.Presentation("Presentation.pptx");
    try {
        var sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
        var autoShape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
        autoShape.getTextFrame().getParagraphs().forEach(function(paragraph) {
            var effects = sequence.getEffectsByParagraph(paragraph);
            if (effects.length > 0) {
                console.log(((("Paragraph \"" + paragraph.getText()) + "\" has ") + effects[0].getType()) + " effect.");
            }
        });
    } finally {
        pres.dispose();
    }
```
