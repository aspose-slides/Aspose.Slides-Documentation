---
title: Texto Animado
type: docs
weight: 60
url: /es/php-java/animated-text/
keywords: "Texto animado en PowerPoint"
description: "Texto animado en PowerPoint con Java"
---

## Agregar Efectos de Animación a Párrafos

Hemos añadido el método [**addEffect()**](https://reference.aspose.com/slides/php-java/aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) a las clases [**Sequence**](https://reference.aspose.com/slides/php-java/aspose.slides/Sequence) y [**ISequence**](https://reference.aspose.com/slides/php-java/aspose.slides/ISequence). Este método te permite añadir efectos de animación a un solo párrafo. Este código de ejemplo te muestra cómo agregar un efecto de animación a un solo párrafo:

```php
  $presentation = new Presentation("Presentation.pptx");
  try {
    # seleccionar párrafo para añadir efecto
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    # agregar efecto de animación Fly al párrafo seleccionado
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->addEffect($paragraph, EffectType::Fly, EffectSubType::Left, EffectTriggerType::OnClick);
    $presentation->save("AnimationEffectinParagraph.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## Obtener los Efectos de Animación en Párrafos

Puedes decidir averiguar los efectos de animación añadidos a un párrafo; por ejemplo, en un escenario, deseas obtener los efectos de animación en un párrafo porque planeas aplicar esos efectos a otro párrafo o forma.

Aspose.Slides para PHP a través de Java te permite obtener todos los efectos de animación aplicados a párrafos contenidos en un marco de texto (forma). Este código de ejemplo te muestra cómo obtener los efectos de animación en un párrafo:

```php
  $pres = new Presentation("Presentation.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
      $effects = $sequence->getEffectsByParagraph($paragraph);
      if (java_values($Array->getLength($effects)) > 0) {
        echo("El párrafo \"" . $paragraph->getText() . "\" tiene el efecto " . $effects[0]->getType() . ".");
      }
    }
  } finally {
    $pres->dispose();
  }
```