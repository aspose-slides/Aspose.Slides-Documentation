---
title: Obtener límites de párrafo de presentaciones en PHP
linktitle: Párrafo
type: docs
weight: 60
url: /es/php-java/paragraph/
keywords:
- límites de párrafo
- límites de porción de texto
- coordenada de párrafo
- coordenada de porción
- tamaño de párrafo
- tamaño de porción de texto
- marco de texto
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Aprenda a obtener los límites de párrafos y de porciones de texto en Aspose.Slides para PHP mediante Java para optimizar la posición del texto en presentaciones de PowerPoint."
---

## **Obtener coordenadas de párrafo y porción en un TextFrame**
Usando Aspose.Slides para PHP a través de Java, los desarrolladores ahora pueden obtener las coordenadas rectangulares de un Paragraph dentro de la colección de párrafos de un TextFrame. También permite obtener [las coordenadas de la porción](https://reference.aspose.com/slides/php-java/aspose.slides/IPortion#getCoordinates--) dentro de la colección de porciones de un párrafo. En este tema, vamos a demostrar con la ayuda de un ejemplo cómo obtener las coordenadas rectangulares de un párrafo junto con la posición de la porción dentro de un párrafo.
```php
  $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $textFrame = $shape->getTextFrame();
  foreach($textFrame->getParagraphs() as $paragraph) {
    foreach($paragraph->getPortions() as $portion) {
      $point = $portion->getCoordinates();
    }
  }
```


## **Obtener coordenadas rectangulares de un párrafo**
Usando el método [**getRect()**](https://reference.aspose.com/slides/php-java/aspose.slides/IParagraph#getRect--) los desarrolladores pueden obtener el rectángulo de límites del párrafo.
```php
  $pres = new Presentation("HelloWorld.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $textFrame = $shape->getTextFrame();
    $rect = $textFrame->getParagraphs()->get_Item(0)->getRect();
    echo("X: " . $rect->$x . " Y: " . $rect->$y . " Width: " . $rect->$width . " Height: " . $rect->$height);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Obtener el tamaño de un párrafo y una porción dentro de un TextFrame de celda de tabla**
Para obtener el tamaño y las coordenadas de la [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/Portion) o del [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/Paragraph) en un TextFrame de celda de tabla, puede usar los métodos [IPortion.getRect](https://reference.aspose.com/slides/php-java/aspose.slides/IPortion#getRect--) y [IParagraph.getRect](https://reference.aspose.com/slides/php-java/aspose.slides/IParagraph#getRect--).
Este código de ejemplo demuestra la operación descrita:
```php
  $pres = new Presentation("source.pptx");
  try {
    $tbl = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $cell = $tbl->getRows()->get_Item(1)->get_Item(1);
    $x = $tbl->getX() + $tbl->getRows()->get_Item(1)->get_Item(1)->getOffsetX();
    $y = $tbl->getY() + $tbl->getRows()->get_Item(1)->get_Item(1)->getOffsetY();
    foreach($cell->getTextFrame()->getParagraphs() as $para) {
      if ($para->getText()->equals("")) {
        continue;
      }
      $rect = $para->getRect();
      $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, $rect->getX() + $x, $rect->getY() + $y, $rect->getWidth(), $rect->getHeight());
      $shape->getFillFormat()->setFillType(FillType::NoFill);
      $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
      $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
      foreach($para->getPortions() as $portion) {
        if ($portion->getText()->contains("0")) {
          $rect = $portion->getRect();
          $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, $rect->getX() + $x, $rect->getY() + $y, $rect->getWidth(), $rect->getHeight());
          $shape->getFillFormat()->setFillType(FillType::NoFill);
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Preguntas frecuentes**

**¿En qué unidades se devuelven las coordenadas de un párrafo y de las porciones de texto?**  
En puntos, donde 1 pulgada = 72 puntos. Esto se aplica a todas las coordenadas y dimensiones en la diapositiva.

**¿Afecta el ajuste de línea a los límites de un párrafo?**  
Sí. Si el [wrapping](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/setwraptext/) está habilitado en el [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/), el texto se ajusta para adaptarse al ancho del área, lo que cambia los límites reales del párrafo.

**¿Se pueden mapear de forma fiable las coordenadas del párrafo a píxeles en la imagen exportada?**  
Sí. Convierta puntos a píxeles usando: píxeles = puntos × (DPI / 72). El resultado depende del DPI elegido para el renderizado/expresión.

**¿Cómo obtener los parámetros de formato “effective” del párrafo, teniendo en cuenta la herencia de estilos?**  
Utilice la [effective paragraph formatting data structure](/slides/es/php-java/shape-effective-properties/); devuelve los valores consolidados finales para sangrías, espaciado, ajuste, RTL y más.