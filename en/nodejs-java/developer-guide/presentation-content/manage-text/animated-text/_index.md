---
title: Animated Text
type: docs
weight: 60
url: /nodejs-java/animated-text/
keywords: "Animated text in PowerPoint"
description: "Animated text in PowerPoint with Java"
---

## **Adding Animation Effects to Paragraphs**

We added the [**addEffect()**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Sequence#addEffect-aspose.slides.IParagraph-int-int-int-) method to the [**Sequence**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Sequence) and [**Sequence**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Sequence) classes. This method allows you to add animation effects to a single paragraph. This sample code shows you how to add an animation effect to a single paragraph:

```javascript
var presentation = new aspose.slides.Presentation("Presentation.pptx");
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

## **Getting the Animation Effects in Paragraphs**

You may decide to find out the animation effects added to a paragraph—for example, in one scenario, you want to get the animation effects in a paragraph because you plan to apply those effects to another paragraph or shape.

Aspose.Slides for Node.js via Java allows you to get all the animation effects applied to paragraphs contained in a text frame (shape). This sample code shows you how to get the animation effects in a paragraph:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    var autoShape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    for (let i = 0; i < autoShape.getTextFrame().getParagraphs().getCount(); i++) {
        let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(i);
        var effects = sequence.getEffectsByParagraph(paragraph);
        if (effects.length > 0) {
            console.log("Paragraph \"" + paragraph.getText() + "\" has " + effects[0].getType() + " effect.");
        }
    }
} finally {
    pres.dispose();
}

```

## **FAQ**

**How do text animations differ from slide transitions, and can they be combined?**

Text animations control object behavior over time on a slide, while [transitions](/slides/nodejs-java/slide-transition/) control how slides change. They’re independent and can be used together; playback order is governed by the animation timeline and the transition settings.

**Are text animations preserved when exporting to PDF or images?**

No. PDF and raster images are static, so you’ll see a single state of the slide without motion. To keep movement, use [video](/slides/nodejs-java/convert-powerpoint-to-video/) or [HTML](/slides/nodejs-java/export-to-html5/) export.

**Do text animations work in layouts and the slide master?**

Effects applied to layout/master objects are inherited by slides, but their timing and interaction with slide-level animations depend on the final sequence on the slide.
