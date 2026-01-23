---
title: Crear miniaturas de formas de presentación en PHP
linktitle: Miniaturas de forma
type: docs
weight: 70
url: /es/php-java/create-shape-thumbnails/
keywords:
- miniatura de forma
- imagen de forma
- renderizar forma
- renderizado de forma
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Genere miniaturas de forma de alta calidad a partir de diapositivas de PowerPoint con Aspose.Slides para PHP mediante Java – cree y exporte fácilmente miniaturas de presentaciones."
---

## **Visión general**
{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java puede usarse para crear archivos de presentación en los que cada página corresponde a una diapositiva. Las diapositivas pueden verse abriendo los archivos de presentación con Microsoft PowerPoint. Sin embargo, a veces los desarrolladores necesitan ver las imágenes de las formas por separado en un visor de imágenes. En esos casos, Aspose.Slides for PHP via Java les ayuda a generar imágenes en miniatura de las formas de la diapositiva.

{{% /alert %}} 

En este tema, mostraremos cómo generar miniaturas de diapositivas en diferentes situaciones:

- Generar una miniatura de forma dentro de una diapositiva.
- Generar una miniatura de forma para una forma de diapositiva con dimensiones definidas por el usuario.
- Generar una miniatura de forma dentro de los límites de la apariencia de una forma.

## **Generar una miniatura de forma a partir de una diapositiva**
Para generar una miniatura de forma a partir de cualquier diapositiva usando Aspose.Slides for PHP via Java, haga lo siguiente:

1. Cree una instancia de la [Presentación](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) .
2. Obtenga la referencia de cualquier diapositiva usando su ID o índice.
3. [Obtenga la imagen en miniatura de la forma](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) de la diapositiva de referencia con la escala predeterminada.
4. Guarde la imagen en miniatura en el formato de imagen que prefiera.

Este fragmento de código le muestra cómo generar una miniatura de forma a partir de una diapositiva:
```php
  # Instanciar una clase Presentation que representa el archivo de presentación
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Crear una imagen a escala completa
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage();
    # Guardar la imagen en disco en formato PNG
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Generar una miniatura con factor de escala definido por el usuario**
Para generar la miniatura de forma de una diapositiva usando Aspose.Slides for PHP via Java, haga lo siguiente:

1. Cree una instancia de la [Presentación](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) .
2. Obtenga la referencia de cualquier diapositiva usando su ID o índice.
3. [Obtenga la imagen en miniatura de la forma](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) de la diapositiva de referencia con dimensiones definidas por el usuario.
4. Guarde la imagen en miniatura en el formato de imagen que prefiera.

Este fragmento de código le muestra cómo generar una miniatura de forma basada en un factor de escala definido:
```php
  # Instanciar una clase Presentation que representa el archivo de presentación
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Crear una imagen a escala completa
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Shape, 1, 1);
    # Guardar la imagen en disco en formato PNG
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Crear una miniatura basada en los límites de la apariencia de la forma**
Este método de creación de miniaturas de formas permite a los desarrolladores generar una miniatura dentro de los límites de la apariencia de la forma. Tiene en cuenta todos los efectos de la forma. La miniatura de forma generada está restringida por los límites de la diapositiva. Para generar una miniatura de una forma de diapositiva dentro del límite de su apariencia, haga lo siguiente:

1. Cree una instancia de la [Presentación](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) .
2. Obtenga la referencia de cualquier diapositiva usando su ID o índice.
3. Obtenga la imagen en miniatura de la diapositiva de referencia con los límites de la forma como apariencia.
4. Guarde la imagen en miniatura en el formato de imagen que prefiera.

Este fragmento de código se basa en los pasos anteriores:
```php
  # Instanciar una clase Presentation que representa el archivo de presentación
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Crear una imagen a escala completa
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Appearance, 1, 1);
    # Guardar la imagen en disco en formato PNG
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Preguntas frecuentes**

**¿Qué formatos de imagen pueden usarse al guardar miniaturas de formas?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/php-java/aspose.slides/imageformat/), y otros. Las formas también pueden [exportarse como SVG vectorial](https://reference.aspose.com/slides/php-java/aspose.slides/shape/writeassvg/) guardando el contenido de la forma como SVG.

**¿Cuál es la diferencia entre los límites de Forma y de Apariencia al renderizar una miniatura?**

`Shape` utiliza la geometría de la forma; `Appearance` tiene en cuenta los [efectos visuales](/slides/es/php-java/shape-effect/) (sombras, resplandores, etc.).

**¿Qué ocurre si una forma está marcada como oculta? ¿Se seguirá renderizando como miniatura?**

Una forma oculta sigue formando parte del modelo y puede renderizarse; la marca de oculto afecta a la visualización en la presentación, pero no impide generar la imagen de la forma.

**¿Se admiten formas agrupadas, gráficos, SmartArt y otros objetos complejos?**

Sí. Cualquier objeto representado como [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) (incluidos [GroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/) y [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/)) puede guardarse como miniatura o como SVG.

**¿Influyen las fuentes instaladas en el sistema en la calidad de las miniaturas de formas de texto?**

Sí. Debe [proporcionar las fuentes necesarias](/slides/es/php-java/custom-font/) (o [configurar sustituciones de fuentes](/slides/es/php-java/font-substitution/)) para evitar sustituciones no deseadas y reflujo de texto.