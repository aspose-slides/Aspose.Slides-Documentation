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
description: "Cree texto animado dinámico en presentaciones de PowerPoint y OpenDocument usando Aspose.Slides para PHP via Java, con ejemplos de código fáciles de seguir y optimizados."
---

## **Agregar efectos de animación a los párrafos**

Agregamos el método [**addEffect()**](https://reference.aspose.com/slides/php-java/aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) a las clases [**Sequence**](https://reference.aspose.com/slides/php-java/aspose.slides/Sequence) y [**ISequence**](https://reference.aspose.com/slides/php-java/aspose.slides/ISequence). Este método le permite agregar efectos de animación a un solo párrafo. Este código de ejemplo le muestra cómo agregar un efecto de animación a un solo párrafo:
```php
  $presentation = new Presentation("Presentation.pptx");
  try {
    # seleccionar párrafo para agregar efecto
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


## **Obtener efectos de animación de los párrafos**

Puede decidir descubrir los efectos de animación agregados a un párrafo—por ejemplo, en un escenario, quiere obtener los efectos de animación de un párrafo porque planea aplicar esos efectos a otro párrafo u objeto.

Aspose.Slides for PHP via Java le permite obtener todos los efectos de animación aplicados a los párrafos contenidos en un marco de texto (forma). Este código de ejemplo le muestra cómo obtener los efectos de animación en un párrafo:
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

**¿En qué se diferencian las animaciones de texto de las transiciones de diapositiva, y pueden combinarse?**

Las animaciones de texto controlan el comportamiento de los objetos a lo largo del tiempo en una diapositiva, mientras que [transitions](/slides/es/php-java/slide-transition/) controlan cómo cambian las diapositivas. Son independientes y pueden usarse juntas; el orden de reproducción lo determina la línea de tiempo de la animación y la configuración de la transición.

**¿Se conservan las animaciones de texto al exportar a PDF o imágenes?**

No. Los PDF y las imágenes raster son estáticos, por lo que verá un único estado de la diapositiva sin movimiento. Para mantener el movimiento, use la exportación a [video](/slides/es/php-java/convert-powerpoint-to-video/) o [HTML](/slides/es/php-java/export-to-html5/).

**¿Funcionan las animaciones de texto en diseños y en la diapositiva maestra?**

Los efectos aplicados a objetos de diseño/maestra se heredan en las diapositivas, pero su sincronización e interacción con las animaciones a nivel de diapositiva dependen de la secuencia final en la diapositiva.