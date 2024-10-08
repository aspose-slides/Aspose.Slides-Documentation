---
title: Animierter Text
type: docs
weight: 60
url: /de/php-java/animated-text/
keywords: "Animierter Text in PowerPoint"
description: "Animierter Text in PowerPoint mit Java"
---

## Hinzufügen von Animationseffekten zu Absätzen

Wir haben die [**addEffect()**](https://reference.aspose.com/slides/php-java/aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) Methode zu den [**Sequence**](https://reference.aspose.com/slides/php-java/aspose.slides/Sequence) und [**ISequence**](https://reference.aspose.com/slides/php-java/aspose.slides/ISequence) Klassen hinzugefügt. Diese Methode ermöglicht es Ihnen, Animationseffekte zu einem einzelnen Absatz hinzuzufügen. Dieser Beispielcode zeigt Ihnen, wie Sie einen Animationseffekt zu einem einzelnen Absatz hinzufügen:

```php
  $presentation = new Presentation("Presentation.pptx");
  try {
    # Wählen Sie den Absatz aus, um einen Effekt hinzuzufügen
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    # Fügen Sie den Fly-Animationseffekt zum ausgewählten Absatz hinzu
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->addEffect($paragraph, EffectType::Fly, EffectSubType::Left, EffectTriggerType::OnClick);
    $presentation->save("AnimationEffectinParagraph.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## Abrufen der Animationseffekte in Absätzen

Sie können sich entscheiden, die Animationseffekte, die einem Absatz hinzugefügt wurden, herauszufinden—zum Beispiel in einem Szenario, in dem Sie die Animationseffekte in einem Absatz abrufen möchten, weil Sie planen, diese Effekte auf einen anderen Absatz oder ein Formelement anzuwenden.

Aspose.Slides für PHP über Java ermöglicht es Ihnen, alle Animationseffekte abzurufen, die auf Absätze angewendet wurden, die in einem Textfeld (Formelement) enthalten sind. Dieser Beispielcode zeigt Ihnen, wie Sie die Animationseffekte in einem Absatz abrufen:

```php
  $pres = new Presentation("Presentation.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
      $effects = $sequence->getEffectsByParagraph($paragraph);
      if (java_values($Array->getLength($effects)) > 0) {
        echo("Absatz \"" . $paragraph->getText() . "\" hat " . $effects[0]->getType() . " Effekt.");
      }
    }
  } finally {
    $pres->dispose();
  }
```