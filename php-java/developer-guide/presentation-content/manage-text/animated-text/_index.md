---
title: Animated Text
type: docs
weight: 60
url: /php-java/animated-text/
keywords: "Animated text in PowerPoint"
description: "Animated text in PowerPoint with Java"
---

## Adding Animation Effects to Paragraphs

We added the [**addEffect()**](https://reference.aspose.com/slides/php-java/com.aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) method to the [**Sequence**](https://reference.aspose.com/slides/php-java/com.aspose.slides/Sequence) and [**ISequence**](https://reference.aspose.com/slides/php-java/com.aspose.slides/ISequence) classes. This method allows you to add animation effects to a single paragraph. This sample code shows you how to add an animation effect to a single paragraph:

```php
  $presentation = new Presentation("Presentation.pptx");
  try {
    // select paragraph to add effect
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    // add Fly animation effect to selected paragraph
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->addEffect($paragraph, EffectType::Fly, EffectSubtype::Left, EffectTriggerType::OnClick);
    $presentation->save("AnimationEffectinParagraph.pptx", SaveFormat::Pptx);
  } finally {
    if ($presentation != null) {
      $presentation->dispose();
    }
  }

```

## Getting the Animation Effects in Paragraphs

You may decide to find out the animation effects added to a paragraph—for example, in one scenario, you want to get the animation effects in a paragraph because you plan to apply those effects to another paragraph or shape.

Aspose.Slides for PHP via Java allows you to get all the animation effects applied to paragraphs contained in a text frame (shape). This sample code shows you how to get the animation effects in a paragraph:

```php
  $pres = new Presentation("Presentation.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    foreach ($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
      $effects = $sequence->getEffectsByParagraph($paragraph);
      if ($Array->getLength($effects) > 0) {
        echo ("Paragraph \"" . $paragraph->getText() . "\" has " . $effects[0]->getType() . " effect.");
      }
    }
  } finally {
    $pres->dispose();
  }

```
