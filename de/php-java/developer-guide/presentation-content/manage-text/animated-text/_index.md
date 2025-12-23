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
description: "Erstellen Sie dynamischen animierten Text in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für PHP via Java, mit leicht nachvollziehbaren, optimierten Codebeispielen."
---

## **Animationseffekte zu Absätzen hinzufügen**

Wir haben die [**addEffect()**](https://reference.aspose.com/slides/php-java/aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) Methode zu den Klassen [**Sequence**](https://reference.aspose.com/slides/php-java/aspose.slides/Sequence) und [**ISequence**](https://reference.aspose.com/slides/php-java/aspose.slides/ISequence) hinzugefügt. Diese Methode ermöglicht es Ihnen, Animations‑Effekte zu einem einzelnen Absatz hinzuzufügen. Dieser Beispielcode zeigt, wie ein Animations‑Effekt zu einem einzelnen Absatz hinzugefügt wird:
```php
  $presentation = new Presentation("Presentation.pptx");
  try {
    # Absatz auswählen, um Effekt hinzuzufügen
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    # Flug-Animationseffekt zum ausgewählten Absatz hinzufügen
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->addEffect($paragraph, EffectType::Fly, EffectSubType::Left, EffectTriggerType::OnClick);
    $presentation->save("AnimationEffectinParagraph.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **Animations‑Effekte von Absätzen abrufen**

Möglicherweise möchten Sie die zu einem Absatz hinzugefügten Animations‑Effekte ermitteln – zum Beispiel, wenn Sie die Effekte eines Absatzes abrufen wollen, um sie auf einen anderen Absatz oder ein anderes Shape anzuwenden.  
Aspose.Slides for PHP via Java ermöglicht es Ihnen, alle auf Absätze in einem Textfeld (Shape) angewendeten Animations‑Effekte abzurufen. Dieser Beispielcode zeigt, wie man die Animations‑Effekte in einem Absatz erhält:
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
Textanimationen steuern das Verhalten von Objekten über die Zeit auf einer Folie, während [Übergänge](/slides/de/php-java/slide-transition/) bestimmen, wie Folien wechseln. Sie sind unabhängig und können zusammen verwendet werden; die Abspielreihenfolge wird durch die Animations‑Zeitleiste und die Übergangseinstellungen festgelegt.

**Werden Textanimationen beim Exportieren in PDF oder Bilder beibehalten?**  
Nein. PDF‑ und Rasterbilder sind statisch, sodass Sie nur einen einzelnen Folienzustand ohne Bewegung sehen. Um die Bewegung zu erhalten, verwenden Sie den Export als [video](/slides/de/php-java/convert-powerpoint-to-video/) oder als [HTML](/slides/de/php-java/export-to-html5/).

**Funktionieren Textanimationen in Layouts und im Folienmaster?**  
Auf Layout‑/Master‑Objekte angewendete Effekte werden von den Folien geerbt, jedoch hängen ihr Timing und ihre Interaktion mit Folien‑Animationen von der endgültigen Sequenz auf der Folie ab.