---
title: Añadir rectángulos a presentaciones en PHP
linktitle: Rectángulo
type: docs
weight: 80
url: /es/php-java/rectangle/
keywords:
- añadir rectángulo
- crear rectángulo
- forma de rectángulo
- rectángulo sencillo
- rectángulo con formato
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Mejora tus presentaciones de PowerPoint añadiendo rectángulos con Aspose.Slides para PHP a través de Java — diseña y modifica formas de forma programática fácilmente."
---

{{% alert color="primary" %}} 

Al igual que los temas anteriores, este también trata sobre añadir una forma y, en esta ocasión, la forma que vamos a tratar es **Rectangle**. En este tema, hemos descrito cómo los desarrolladores pueden añadir rectángulos simples o con formato a sus diapositivas usando Aspose.Slides para PHP a través de Java.

{{% /alert %}} 

## **Add a Rectangle to a Slide**
Para añadir un rectángulo sencillo a una diapositiva seleccionada de la presentación, siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- Obtenga la referencia de una diapositiva mediante su Index.
- Añada un [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) de tipo Rectangle usando el método [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addAutoShape) expuesto por el objeto [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/).
- Guarde la presentación modificada como archivo PPTX.

En el ejemplo que se muestra a continuación, hemos añadido un rectángulo sencillo a la primera diapositiva de la presentación.
```php
  # Instanciar la clase Presentation que representa el PPTX
  # Obtener la primera diapositiva
  # Añadir AutoShape de tipo elipse
  # Escribir el archivo PPTX en disco
  $pres = new Presentation();
  try {
    # Obtener la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Añadir AutoShape de tipo elipse
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # Escribir el archivo PPTX en disco
    $pres->save("RecShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Add a Formatted Rectangle to a Slide**
Para añadir un rectángulo con formato a una diapositiva, siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- Obtenga la referencia de una diapositiva mediante su Index.
- Añada un [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) de tipo Rectangle usando el método [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addAutoShape) expuesto por el objeto [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/).
- Establezca el [Fill Type](https://reference.aspose.com/slides/php-java/aspose.slides/FillType) del rectángulo a Solid.
- Defina el color del rectángulo mediante el método [ColorFormat::setColor](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#setColor) expuesto por el objeto [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) asociado al objeto [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/).
- Establezca el color de las líneas del rectángulo.
- Establezca el ancho de las líneas del rectángulo.
- Guarde la presentación modificada como archivo PPTX.

Los pasos anteriores se implementan en el ejemplo que se muestra a continuación.
```php
  # Instanciar la clase Presentation que representa el PPTX
  $pres = new Presentation();
  try {
    # Obtener la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Añadir AutoShape de tipo elipse
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # Aplicar algo de formato a la forma elipse
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    # Aplicar algo de formato a la línea de la elipse
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp->getLineFormat()->setWidth(5);
    # Guardar el archivo PPTX en disco
    $pres->save("RecShp2.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**How do I add a rectangle with rounded corners?**

Use the rounded-corner [shape type](https://reference.aspose.com/slides/php-java/aspose.slides/shapetype/) and adjust the corner radius in the shape’s properties; rounding can also be applied per corner via geometry adjustments.

**How do I fill a rectangle with an image (texture)?**

Select the picture [fill type](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/), provide the image source, and configure [stretching/tiling modes](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/).

**Can a rectangle have shadow and glow?**

Yes. [Outer/inner shadow, glow, and soft edges](/slides/es/php-java/shape-effect/) are available with adjustable parameters.

**Can I turn a rectangle into a button with a hyperlink?**

Yes. [Assign a hyperlink](/slides/es/php-java/manage-hyperlinks/) to the shape click (jump to a slide, file, web address, or e-mail).

**How can I protect a rectangle from moving and changes?**

Use shape locks: you can forbid moving, resizing, selection, or text editing to preserve the layout.

**Can I convert a rectangle to a raster image or SVG?**

Yes. You can [render the shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) to an image with a specified size/scale or [export it as SVG](https://reference.aspose.com/slides/php-java/aspose.slides/shape/writeassvg/) for vector use.

**How do I quickly get the actual (effective) properties of a rectangle considering theme and inheritance?**

[Use the shape’s effective properties](/slides/es/php-java/shape-effective-properties/): the API returns computed values that account for theme styles, layout, and local settings, simplifying formatting analysis.