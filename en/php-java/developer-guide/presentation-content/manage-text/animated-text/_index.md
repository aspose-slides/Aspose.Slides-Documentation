---
title: Animate PowerPoint Text in PHP
linktitle: Animated Text
type: docs
weight: 60
url: /php-java/animated-text/
keywords:
- animated text
- text animation
- animated paragraph
- paragraph animation
- animation effect
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Create dynamic animated text in PowerPoint and OpenDocument presentations using Aspose.Slides for PHP via Java, with easy-to-follow, optimized code examples."
---

## **Add Animation Effects to Paragraphs**

We added the [**addEffect()**](https://reference.aspose.com/slides/php-java/aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) method to the [**Sequence**](https://reference.aspose.com/slides/php-java/aspose.slides/Sequence) class. This method allows you to add animation effects to a single paragraph. This sample code shows you how to add an animation effect to a single paragraph:

```php
  $presentation = new Presentation("Presentation.pptx");
  try {
    # select paragraph to add effect
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    # add Fly animation effect to selected paragraph
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->addEffect($paragraph, EffectType::Fly, EffectSubType::Left, EffectTriggerType::OnClick);
    $presentation->save("AnimationEffectinParagraph.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Get Animation Effects of Paragraphs**

You may decide to find out the animation effects added to a paragraph—for example, in one scenario, you want to get the animation effects in a paragraph because you plan to apply those effects to another paragraph or shape.

Aspose.Slides for PHP via Java allows you to get all the animation effects applied to paragraphs contained in a text frame (shape). This sample code shows you how to get the animation effects in a paragraph:

```php
  $pres = new Presentation("Presentation.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
      $effects = $sequence->getEffectsByParagraph($paragraph);
      if (java_values($Array->getLength($effects)) > 0) {
        echo("Paragraph \"" . $paragraph->getText() . "\" has " . $effects[0]->getType() . " effect.");
      }
    }
  } finally {
    $pres->dispose();
  }
```

## **FAQ**

**How do text animations differ from slide transitions, and can they be combined?**

Text animations control object behavior over time on a slide, while [transitions](/slides/php-java/slide-transition/) control how slides change. They’re independent and can be used together; playback order is governed by the animation timeline and the transition settings.

**Are text animations preserved when exporting to PDF or images?**

No. PDF and raster images are static, so you’ll see a single state of the slide without motion. To keep movement, use [video](/slides/php-java/convert-powerpoint-to-video/) or [HTML](/slides/php-java/export-to-html5/) export.

**Do text animations work in layouts and the slide master?**

Effects applied to layout/master objects are inherited by slides, but their timing and interaction with slide-level animations depend on the final sequence on the slide.
