---
title: Crear miniaturas de formas de presentación en Android
linktitle: Miniaturas de formas
type: docs
weight: 70
url: /es/androidjava/create-shape-thumbnails/
keywords:
- miniatura de forma
- imagen de forma
- renderizar forma
- renderizado de forma
- límites visuales
- límites de forma
- PowerPoint
- presentación
- Android
- Java
- Aspose.Slides
description: "Genera miniaturas de forma de alta calidad a partir de diapositivas de PowerPoint con Aspose.Slides for Android via Java – crea y exporta fácilmente miniaturas de presentaciones."
---
## **Introducción**

Aspose.Slides for Android via Java se puede usar para crear archivos de presentación en los que cada página corresponde a una diapositiva. Las diapositivas pueden ser vistas abriendo los archivos de presentación con Microsoft PowerPoint. Sin embargo, los desarrolladores a veces necesitan ver las imágenes de las formas por separado en un visor de imágenes. En tales casos, Aspose.Slides for Android via Java les ayuda a generar imágenes en miniatura de las formas de la diapositiva.

En este tema, mostraremos cómo generar miniaturas de diapositivas en diferentes situaciones:

- Generar una miniatura de forma dentro de una diapositiva.
- Generar una miniatura de forma para una forma de diapositiva con dimensiones definidas por el usuario.
- Generar una miniatura de forma dentro de los límites de la apariencia de una forma.

## **Generar una miniatura de forma a partir de una diapositiva**
Para generar una miniatura de forma a partir de cualquier diapositiva usando Aspose.Slides for Android via Java, haga lo siguiente:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation).
1. Obtenga la referencia de cualquier diapositiva usando su ID o índice.
1. [Obtener la imagen en miniatura de la forma](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IShape#getImage--) de la diapositiva referenciada con la escala predeterminada.
1. Guarde la imagen en miniatura en el formato de imagen que prefiera.

Este fragmento de código muestra cómo generar una miniatura de forma a partir de una diapositiva:

```java
// Instanciar una clase Presentation que representa el archivo de presentación
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Crear una imagen a escala completa
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    
    // Guardar la imagen en disco en formato PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Generar una miniatura con factor de escala definido por el usuario**
Para generar la miniatura de forma de una diapositiva usando Aspose.Slides for Android via Java, haga lo siguiente:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation).
1. Obtenga la referencia de cualquier diapositiva usando su ID o índice.
1. [Obtener la imagen en miniatura de la forma](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IShape#getImage-int-float-float-) de la diapositiva referenciada con dimensiones definidas por el usuario.
1. Guarde la imagen en miniatura en el formato de imagen que prefiera.

Este fragmento de código muestra cómo generar una miniatura de forma basada en un factor de escala definido:

```java
// Instanciar una clase Presentation que representa el archivo de presentación
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Crear una imagen a escala completa
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 1, 1);

    // Guardar la imagen en disco en formato PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Crear una miniatura de forma basada en los límites de la apariencia**
Este método de creación de miniaturas de formas permite a los desarrolladores generar una miniatura dentro de los límites de la apariencia de la forma. Tiene en cuenta todos los efectos de la forma. La miniatura de forma generada está limitada por los límites de la diapositiva. Para generar una miniatura de una forma de diapositiva dentro del límite de su apariencia, haga lo siguiente:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation).
1. Obtenga la referencia de cualquier diapositiva usando su ID o índice.
1. Obtenga la imagen en miniatura de la diapositiva referenciada con los límites de la forma como apariencia.
1. Guarde la imagen en miniatura en el formato de imagen que prefiera.

Este fragmento de código se basa en los pasos anteriores:

```java
// Instanciar una clase Presentation que representa el archivo de presentación
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Crear una imagen a escala completa
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

    // Guardar la imagen en disco en formato PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Obtener los límites visuales reales de una forma**

Las propiedades de marco de [IShape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ishape/)—sus métodos `getX()`, `getY()`, `getWidth()` y `getHeight()`—describen el rectángulo almacenado en el modelo de la presentación. El contenido que realmente se renderiza puede extenderse más allá de ese marco o ocupar un rectángulo alineado a los ejes diferente. Rotación, contornos, puntas de flecha, distribución y desbordamiento de texto, geometría generada de SmartArt y otros efectos de renderizado pueden modificar el área ocupada.

Utilice [Shape.getVisualBounds](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/shape/#getVisualBounds--) para calcular esa área ocupada sin crear una imagen. El método devuelve un [RectF](https://developer.android.com/reference/android/graphics/RectF) en coordenadas de la diapositiva. El rectángulo devuelto no está recortado a la diapositiva, por lo que sus coordenadas pueden ser negativas cuando el contenido se extiende más allá del origen de la diapositiva.

[Shape.getVisualBounds](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/shape/#getVisualBounds--) no está declarado actualmente por la interfaz [IShape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ishape/). Por ello, mantenga la forma obtenida de la colección de formas de la diapositiva como un valor de interfaz y conviértala sólo al invocar el método.

El siguiente ejemplo obtiene y compara los límites del marco y los límites visuales:

```java
Presentation presentation = new Presentation("example.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    RectF visualBounds = ((Shape) shape).getVisualBounds();

    float frameLeft = shape.getX();
    float frameTop = shape.getY();
    float frameRight = frameLeft + shape.getWidth();
    float frameBottom = frameTop + shape.getHeight();
    RectF frameBounds = new RectF(frameLeft, frameTop, frameRight, frameBottom);

    System.out.println("Frame bounds: " + frameBounds);
    System.out.println("Visual bounds: " + visualBounds);
} finally {
    presentation.dispose();
}
```

El mismo [RectF](https://developer.android.com/reference/android/graphics/RectF) puede usarse para alinear formas cercanas a su borde izquierdo, derecho, superior o inferior; reservar suficiente espacio en un diseño generado; o detectar contenido fuera de una región permitida. Los límites visuales son especialmente útiles para SmartArt, cuadros de texto, flechas, imágenes, formas rotadas y formas agrupadas, donde el marco almacenado puede no representar el resultado renderizado completo.

Utilice [Shape.getVisualBounds](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/shape/#getVisualBounds--) cuando necesite coordenadas para diseño o validación y no requiera un bitmap. Utilice [IShape.getImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ishape/#getImage--) cuando necesite renderizar la forma. Con [ShapeThumbnailBounds](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/shapethumbnailbounds/), `ShapeThumbnailBounds.Shape` dimensiona la imagen a partir de los límites de la forma, incluidos los ajustes de contorno, mientras que `ShapeThumbnailBounds.Appearance` la dimensiona a partir de la apariencia de la forma y restringe el resultado a los límites de la diapositiva. En contraste, [Shape.getVisualBounds](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/shape/#getVisualBounds--) devuelve sólo el rectángulo calculado y no lo recorta a la diapositiva.

## **Preguntas frecuentes**

**¿Qué formatos de imagen se pueden usar al guardar miniaturas de formas?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/imageformat/), y otros. Las formas también pueden [exportarse como SVG vectorial](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) guardando el contenido de la forma como SVG.

**¿Cuál es la diferencia entre los límites Shape y Appearance al renderizar una miniatura?**

`Shape` utiliza la geometría de la forma; `Appearance` tiene en cuenta los [efectos visuales](/slides/es/androidjava/shape-effect/) (sombras, resplandores, etc.).

**¿Qué ocurre si una forma está marcada como oculta? ¿Se seguirá renderizando como miniatura?**

Una forma oculta sigue formando parte del modelo y puede renderizarse; la marca de oculto afecta la visualización en la presentación pero no impide generar la imagen de la forma.

**¿Se admiten formas agrupadas, gráficos, SmartArt y otros objetos complejos?**

Sí. Cualquier objeto representado como [Shape] (incluyendo [GroupShape], [Chart] y [SmartArt]) puede guardarse como miniatura o como SVG.

**¿Las fuentes instaladas en el sistema afectan la calidad de las miniaturas de formas de texto?**

Sí. Debe [proporcionar las fuentes necesarias](/slides/es/androidjava/custom-font/) (o [configurar sustituciones de fuentes](/slides/es/androidjava/font-substitution/)) para evitar retrocesos no deseados y reflujo de texto.