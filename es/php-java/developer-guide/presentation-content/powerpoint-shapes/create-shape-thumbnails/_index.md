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
- límites visuales
- límites de forma
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Genera miniaturas de forma de alta calidad a partir de diapositivas de PowerPoint con Aspose.Slides for PHP via Java – crea y exporta fácilmente miniaturas de presentaciones."
---
## **Introducción**

Aspose.Slides se utiliza para crear archivos de presentación donde cada página es una diapositiva. Estas diapositivas pueden verse abriendo los archivos de presentación con Microsoft PowerPoint. Pero a veces, los desarrolladores pueden necesitar ver las imágenes de las formas por separado en un visor de imágenes. En esos casos, Aspose.Slides le ayuda a generar imágenes en miniatura de las formas de la diapositiva. Cómo usar esta función se describe en este artículo.  
Este artículo explica cómo generar miniaturas de diapositivas de diferentes maneras:

- Generar una miniatura de forma dentro de una diapositiva.  
- Generar una miniatura de forma para una forma de diapositiva con dimensiones definidas por el usuario.  
- Generar una miniatura de forma en los límites de la apariencia de una forma.

## **Generar una miniatura de forma a partir de una diapositiva**

Para generar una miniatura de forma a partir de cualquier diapositiva usando Aspose.Slides for PHP via Java, haga lo siguiente:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation).  
1. Obtener la referencia de cualquier diapositiva usando su ID o índice.  
1. [Obtener la imagen en miniatura de la forma](https://reference.aspose.com/slides/es/php-java/aspose.slides/shape/#getImage) del slide referenciado a escala predeterminada.  
1. Guardar la imagen en miniatura en el formato de imagen que prefiera.

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

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation).  
1. Obtener la referencia de cualquier diapositiva usando su ID o índice.  
1. [Obtener la imagen en miniatura de la forma](https://reference.aspose.com/slides/es/php-java/aspose.slides/shape/#getImage) del slide referenciado con dimensiones definidas por el usuario.  
1. Guardar la imagen en miniatura en el formato de imagen que prefiera.

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

Este método para crear miniaturas de formas permite a los desarrolladores generar una miniatura dentro de los límites de la apariencia de la forma. Tiene en cuenta todos los efectos de la forma. La miniatura de la forma generada está limitada por los límites de la diapositiva. Para generar una miniatura de una forma de diapositiva dentro de los límites de su apariencia, haga lo siguiente:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation).  
1. Obtener la referencia de cualquier diapositiva usando su ID o índice.  
1. Obtener la imagen en miniatura del slide referenciado con los límites de la forma como apariencia.  
1. Guardar la imagen en miniatura en el formato de imagen que prefiera.

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

## **Obtener los límites visuales reales de una forma**

Las propiedades de marco de [Shape](https://reference.aspose.com/slides/es/php-java/aspose.slides/shape/)—`Shape::getX()`, `Shape::getY()`, `Shape::getWidth()` y `Shape::getHeight()`—describen el rectángulo almacenado en el modelo de la presentación. El contenido que realmente se renderiza puede extenderse más allá de ese marco o ocupar un rectángulo alineado a los ejes diferente. La rotación, los contornos, las puntas de flecha, la disposición y desbordamiento del texto, la geometría generada de SmartArt y otros efectos de renderizado pueden modificar el área ocupada.

Use [Shape::getVisualBounds](https://reference.aspose.com/slides/es/php-java/aspose.slides/shape/#getVisualBounds) para calcular esa área ocupada sin crear una imagen. El método devuelve un [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) en coordenadas de la diapositiva. El rectángulo devuelto no está recortado a la diapositiva, por lo que sus coordenadas pueden ser negativas cuando el contenido se extiende más allá del origen de la diapositiva.

El siguiente ejemplo obtiene y compara los límites de marco y visual:

```php
  $presentation = new Presentation("example.pptx");
  try {
      $slide = $presentation->getSlides()->get_Item(0);
      $shape = $slide->getShapes()->get_Item(0);

      $visualBounds = $shape->getVisualBounds();

      $frameX = $shape->getX();
      $frameY = $shape->getY();
      $frameWidth = $shape->getWidth();
      $frameHeight = $shape->getHeight();

      $visualX = $visualBounds->getX();
      $visualY = $visualBounds->getY();
      $visualWidth = $visualBounds->getWidth();
      $visualHeight = $visualBounds->getHeight();

      echo "Frame bounds (x, y, width, height): $frameX, $frameY, $frameWidth, $frameHeight\n";
      echo "Visual bounds (x, y, width, height): $visualX, $visualY, $visualWidth, $visualHeight\n";
  } finally {
      $presentation->dispose();
  }
```

El mismo [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) puede usarse para alinear formas cercanas a su borde izquierdo, derecho, superior o inferior; reservar suficiente espacio en un diseño generado; o detectar contenido fuera de una zona permitida. Los límites visuales son especialmente útiles para SmartArt, cuadros de texto, flechas, imágenes, formas rotadas y formas agrupadas, donde el marco almacenado puede no representar el resultado renderizado completo.

Utilice [Shape::getVisualBounds] cuando necesite coordenadas para el diseño o la validación y no requiera un mapa de bits. Utilice [Shape::getImage] cuando necesite renderizar la forma. Con [ShapeThumbnailBounds], `ShapeThumbnailBounds::Shape` dimensiona la imagen a partir de los límites de la forma, incluyendo la configuración de contorno, mientras que `ShapeThumbnailBounds::Appearance` la dimensiona a partir de la apariencia de la forma y restringe el resultado a los límites de la diapositiva. En contraste, `Shape::getVisualBounds` solo devuelve el rectángulo calculado y no lo recorta a la diapositiva.

## **Preguntas frecuentes**

**¿Qué formatos de imagen se pueden usar al guardar miniaturas de forma?**  
[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/es/php-java/aspose.slides/imageformat/), y otros. Las formas también pueden ser [exportadas como SVG vectorial](https://reference.aspose.com/slides/es/php-java/aspose.slides/shape/writeassvg/) al guardar el contenido de la forma como SVG.

**¿Cuál es la diferencia entre los límites Shape y Appearance al renderizar una miniatura?**  
`Shape` utiliza la geometría de la forma; `Appearance` tiene en cuenta los [efectos visuales](/slides/es/php-java/shape-effect/) (sombras, resplandores, etc.).

**¿Qué ocurre si una forma está marcada como oculta? ¿Se seguirá renderizando como miniatura?**  
Una forma oculta sigue formando parte del modelo y puede renderizarse; la bandera oculta afecta la visualización de la presentación pero no impide generar la imagen de la forma.

**¿Se admiten formas agrupadas, gráficos, SmartArt y otros objetos complejos?**  
Sí. Cualquier objeto representado como [Shape](https://reference.aspose.com/slides/es/php-java/aspose.slides/shape/) (incluyendo [GroupShape](https://reference.aspose.com/slides/es/php-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/es/php-java/aspose.slides/chart/) y [SmartArt](https://reference.aspose.com/slides/es/php-java/aspose.slides/smartart/)) puede guardarse como una miniatura o como SVG.

**¿Afectan las fuentes instaladas en el sistema a la calidad de las miniaturas de formas de texto?**  
Sí. Debe [proporcionar las fuentes necesarias](/slides/es/php-java/custom-font/) (o [configurar sustituciones de fuentes](/slides/es/php-java/font-substitution/)) para evitar sustituciones no deseadas y reflujo de texto.