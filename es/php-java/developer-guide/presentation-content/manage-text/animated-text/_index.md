---
title: Animar texto de PowerPoint en PHP
linktitle: Texto animado
type: docs
weight: 60
url: /es/php-java/animated-text/
keywords:
- texto animado
- animación de texto
- párrafo animado
- animación de párrafo
- efecto de animación
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Crea texto animado dinámico en presentaciones de PowerPoint y OpenDocument usando Aspose.Slides para PHP a través de Java, con ejemplos de código optimizados y fáciles de seguir."
---

## **Agregar efectos de animación a los párrafos**

Añadimos el método [**addEffect()**](https://reference.aspose.com/slides/php-java/aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) a la clase [**Sequence**](https://reference.aspose.com/slides/php-java/aspose.slides/Sequence). Este método permite agregar efectos de animación a un solo párrafo. El código de ejemplo muestra cómo agregar un efecto de animación a un párrafo único:
```php
  $presentation = new Presentation("Presentation.pptx");
  try {
    # seleccionar párrafo para añadir efecto
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    # añadir efecto de animación Fly al párrafo seleccionado
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->addEffect($paragraph, EffectType::Fly, EffectSubType::Left, EffectTriggerType::OnClick);
    $presentation->save("AnimationEffectinParagraph.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **Obtener los efectos de animación de los párrafos**

Puede que necesite averiguar los efectos de animación añadidos a un párrafo; por ejemplo, en un escenario quiere obtener los efectos de animación de un párrafo porque planea aplicar esos efectos a otro párrafo o forma.

Aspose.Slides for PHP via Java le permite obtener todos los efectos de animación aplicados a los párrafos contenidos en un marco de texto (forma). El código de ejemplo muestra cómo obtener los efectos de animación de un párrafo:
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

**¿En qué se diferencian las animaciones de texto de las transiciones de diapositiva y pueden combinarse?**

Las animaciones de texto controlan el comportamiento del objeto a lo largo del tiempo en una diapositiva, mientras que las [transitions](/slides/es/php-java/slide-transition/) controlan cómo cambian las diapositivas. Son independientes y pueden usarse juntas; el orden de reproducción lo rige la línea de tiempo de la animación y la configuración de la transición.

**¿Se conservan las animaciones de texto al exportar a PDF o imágenes?**

No. PDF e imágenes raster están estáticas, por lo que verá un único estado de la diapositiva sin movimiento. Para mantener el movimiento, use la exportación a [video](/slides/es/php-java/convert-powerpoint-to-video/) o [HTML](/slides/es/php-java/export-to-html5/).

**¿Funcionan las animaciones de texto en diseños y la diapositiva maestra?**

Los efectos aplicados a objetos de diseño/maestra se heredan por las diapositivas, pero su temporización e interacción con animaciones a nivel de diapositiva dependen de la secuencia final en la diapositiva.