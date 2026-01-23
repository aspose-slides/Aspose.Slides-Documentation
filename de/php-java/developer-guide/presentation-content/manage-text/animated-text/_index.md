---
title: PowerPoint-Text in PHP animieren
linktitle: Animierter Text
type: docs
weight: 60
url: /de/php-java/animated-text/
keywords:
- animierter Text
- Textanimation
- animierter Absatz
- Absatzanimation
- Animationseffekt
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Erstellen Sie dynamischen, animierten Text in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für PHP via Java, mit leicht nachvollziehbaren, optimierten Codebeispielen."
---

## **Animations‑Effekte zu Absätzen hinzufügen**

Wir haben die Methode [**addEffect()**](https://reference.aspose.com/slides/php-java/aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) zur Klasse [**Sequence**](https://reference.aspose.com/slides/php-java/aspose.slides/Sequence) hinzugefügt. Diese Methode ermöglicht das Hinzufügen von Animationseffekten zu einem einzelnen Absatz. Der folgende Beispielcode zeigt, wie ein Animationseffekt zu einem einzelnen Absatz hinzugefügt wird:
```php
  $presentation = new Presentation("Presentation.pptx");
  try {
    # Absatz zum Hinzufügen des Effekts auswählen
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    # Fly-Animationseffekt zum ausgewählten Absatz hinzufügen
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->addEffect($paragraph, EffectType::Fly, EffectSubType::Left, EffectTriggerType::OnClick);
    $presentation->save("AnimationEffectinParagraph.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **Animations‑Effekte von Absätzen abrufen**

Sie möchten möglicherweise die zu einem Absatz hinzugefügten Animationseffekte ermitteln – zum Beispiel, wenn Sie die Effekte eines Absatzes auf einen anderen Absatz oder ein Shape anwenden wollen.

Aspose.Slides für PHP via Java ermöglicht das Abrufen aller auf Absätze in einem Textfeld (Shape) angewendeten Animationseffekte. Der folgende Beispielcode zeigt, wie die Animationseffekte in einem Absatz abgerufen werden:
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

**Wie unterscheiden sich Textanimationen von Folienübergängen und können sie kombiniert werden?**

Textanimationen steuern das Verhalten von Objekten über die Zeit auf einer Folie, während [Übergänge](/slides/de/php-java/slide-transition/) bestimmen, wie Folienwechsel erfolgen. Sie sind unabhängig und können zusammen verwendet werden; die Reihenfolge der Wiedergabe wird durch die Animations‑Timeline und die Übergangseinstellungen gesteuert.

**Werden Textanimationen beim Exportieren in PDF oder Bilder beibehalten?**

Nein. PDF und Rasterbilder sind statisch, sodass Sie nur einen einzelnen Zustand der Folie ohne Bewegung sehen. Um die Bewegung zu erhalten, verwenden Sie den Export nach [Video](/slides/de/php-java/convert-powerpoint-to-video/) oder [HTML](/slides/de/php-java/export-to-html5/).

**Funktionieren Textanimationen in Layouts und der Folienmaster?**

Auf Layout‑/Master‑Objekte angewandte Effekte werden von Folien geerbt, jedoch hängen ihr Timing und ihre Interaktion mit Folien‑Animationen von der endgültigen Reihenfolge auf der jeweiligen Folie ab.