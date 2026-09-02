---
title: Crear miniaturas de formas de presentación en Java
linktitle: Miniaturas de formas
type: docs
weight: 70
url: /es/java/create-shape-thumbnails/
keywords:
- miniatura de forma
- imagen de forma
- renderizar forma
- renderizado de forma
- límites visuales
- límites de forma
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Genera miniaturas de forma de alta calidad a partir de diapositivas de PowerPoint con Aspose.Slides for Java – crea y exporta miniaturas de presentaciones fácilmente."
---
## **Introducción**

Aspose.Slides for Java se puede usar para crear archivos de presentación en los que cada página corresponde a una diapositiva. Las diapositivas pueden visualizarse abriendo los archivos de presentación con Microsoft PowerPoint. Sin embargo, a veces los desarrolladores necesitan ver las imágenes de las formas por separado en un visor de imágenes. En esos casos, Aspose.Slides for Java les ayuda a generar imágenes en miniatura de las formas de la diapositiva.

Este artículo explica cómo generar miniaturas de diapositivas de diferentes maneras:

- Generar una miniatura de forma dentro de una diapositiva.
- Generar una miniatura de forma para una forma de diapositiva con dimensiones definidas por el usuario.
- Generar una miniatura de forma dentro de los límites de la apariencia de una forma.

## **Generar una miniatura de forma a partir de una diapositiva**
Para generar una miniatura de forma a partir de cualquier diapositiva usando Aspose.Slides for Java, haga lo siguiente:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/).
2. Obtener la referencia de cualquier diapositiva usando su ID o índice.
3. [Obtener la imagen en miniatura de la forma](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishape/#getImage--) de la diapositiva referenciada a escala predeterminada.
4. Guardar la imagen en miniatura en el formato de imagen que prefiera.

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
Para generar la miniatura de forma de una diapositiva usando Aspose.Slides for Java, haga lo siguiente:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/).
2. Obtener la referencia de cualquier diapositiva usando su ID o índice.
3. [Obtener la imagen en miniatura de la forma](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishape/#getImage-int-float-float-) de la diapositiva referenciada con dimensiones definidas por el usuario.
4. Guardar la imagen en miniatura en el formato de imagen que prefiera.

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

## **Crear una miniatura de forma basada en límites de apariencia**
Este método de creación de miniaturas de formas permite a los desarrolladores generar una miniatura dentro de los límites de la apariencia de la forma. Tiene en cuenta todos los efectos de la forma. La miniatura de la forma generada está restringida por los límites de la diapositiva. Para generar una miniatura de una forma de diapositiva dentro de sus límites de apariencia, haga lo siguiente:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/).
2. Obtener la referencia de cualquier diapositiva usando su ID o índice.
3. Obtener la imagen en miniatura de la diapositiva referenciada con los límites de la forma como apariencia.
4. Guardar la imagen en miniatura en el formato de imagen que prefiera.

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

Las propiedades del marco de [IShape](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishape/) — sus métodos `getX()`, `getY()`, `getWidth()` y `getHeight()` — describen el rectángulo almacenado en el modelo de la presentación. El contenido que realmente se renderiza puede extenderse más allá de ese marco o ocupar un rectángulo alineado a los ejes diferente. La rotación, los contornos, las puntas de flecha, el diseño y desbordamiento del texto, la geometría generada de SmartArt y otros efectos de renderizado pueden modificar el área ocupada.

Utilice [Shape.getVisualBounds](https://reference.aspose.com/slides/es/java/com.aspose.slides/shape/#getVisualBounds--) para calcular esa zona ocupada sin crear una imagen. El método devuelve un [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) en coordenadas de la diapositiva. El rectángulo devuelto no está recortado a la diapositiva, por lo que sus coordenadas pueden ser negativas cuando el contenido se extiende más allá del origen de la diapositiva.

[Shape.getVisualBounds](https://reference.aspose.com/slides/es/java/com.aspose.slides/shape/#getVisualBounds--) no está declarado actualmente por la interfaz [IShape](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishape/). Por lo tanto, mantenga la forma obtenida de la colección de formas de la diapositiva como un valor de interfaz y conviértala (cast) sólo al invocar el método.

El siguiente ejemplo obtiene y compara los límites del marco y los límites visuales:

```java
Presentation presentation = new Presentation("example.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    Rectangle2D.Float visualBounds = ((Shape) shape).getVisualBounds();

    Rectangle2D.Float frameBounds = new Rectangle2D.Float(
        shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight());

    System.out.println("Frame bounds: " + frameBounds);
    System.out.println("Visual bounds: " + visualBounds);
} finally {
    presentation.dispose();
}
```

El mismo [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) puede usarse para alinear formas cercanas a su borde izquierdo, derecho, superior o inferior; reservar suficiente espacio en un diseño generado; o detectar contenido fuera de una región permitida. Los límites visuales son especialmente útiles para SmartArt, cuadros de texto, flechas, imágenes, formas rotadas y grupos de formas, donde el marco almacenado puede no representar el resultado renderizado completo.

Utilice [Shape.getVisualBounds](https://reference.aspose.com/slides/es/java/com.aspose.slides/shape/#getVisualBounds--) cuando necesite coordenadas para el diseño o la validación y no requiera un mapa de bits. Utilice [IShape.getImage](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishape/#getImage--) cuando necesite renderizar la forma. Con [ShapeThumbnailBounds](https://reference.aspose.com/slides/es/java/com.aspose.slides/shapethumbnailbounds/), `ShapeThumbnailBounds.Shape` dimensiona la imagen a partir de los límites de la forma, incluidos los ajustes de contorno, mientras que `ShapeThumbnailBounds.Appearance` la dimensiona a partir de la apariencia de la forma y restringe el resultado a los límites de la diapositiva. En contraste, [Shape.getVisualBounds](https://reference.aspose.com/slides/es/java/com.aspose.slides/shape/#getVisualBounds--) solo devuelve el rectángulo calculado y no lo recorta a la diapositiva.

## **Preguntas frecuentes**

**¿Qué formatos de imagen pueden usarse al guardar miniaturas de forma?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/es/java/com.aspose.slides/imageformat/), y otros. Las formas también pueden [exportarse como SVG vectorial](https://reference.aspose.com/slides/es/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) guardando el contenido de la forma como SVG.

**¿Cuál es la diferencia entre los límites Shape y Appearance al renderizar una miniatura?**

`Shape` utiliza la geometría de la forma; `Appearance` tiene en cuenta los [efectos visuales](/slides/es/java/shape-effect/) (sombras, brillos, etc.).

**¿Qué ocurre si una forma está marcada como oculta? ¿Se seguirá renderizando como miniatura?**

Una forma oculta sigue formando parte del modelo y puede renderizarse; la marca oculta afecta la visualización en la presentación pero no impide generar la imagen de la forma.

**¿Se admiten formas grupales, gráficos, SmartArt y otros objetos complejos?**

Sí. Cualquier objeto representado como [Shape](https://reference.aspose.com/slides/es/java/com.aspose.slides/shape/) (incluidos [GroupShape](https://reference.aspose.com/slides/es/java/com.aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/es/java/com.aspose.slides/chart/), y [SmartArt](https://reference.aspose.com/slides/es/java/com.aspose.slides/smartart/)) puede guardarse como miniatura o como SVG.

**¿Afectan las fuentes instaladas en el sistema a la calidad de las miniaturas de formas de texto?**

Sí. Debe [proveer las fuentes requeridas](/slides/es/java/custom-font/) (o [configurar sustituciones de fuentes](/slides/es/java/font-substitution/)) para evitar sustituciones no deseadas y reflujo de texto.