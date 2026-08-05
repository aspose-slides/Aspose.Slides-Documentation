---
title: Crear miniaturas de formas de presentación en JavaScript
linktitle: Miniaturas de formas
type: docs
weight: 70
url: /es/nodejs-java/create-shape-thumbnails/
keywords:
- miniatura de forma
- imagen de forma
- renderizar forma
- renderizado de forma
- límites visuales
- límites de forma
- PowerPoint
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Genere miniaturas de forma de alta calidad a partir de diapositivas de PowerPoint con JavaScript y Aspose.Slides para Node.js – cree y exporte miniaturas de presentaciones fácilmente."
---
## **Introducción**

Aspose.Slides se utiliza para crear archivos de presentación donde cada página es una diapositiva. Estas diapositivas pueden verse abriendo los archivos de presentación con Microsoft PowerPoint. Pero a veces, los desarrolladores pueden necesitar ver las imágenes de las formas por separado en un visor de imágenes. En esos casos, Aspose.Slides le ayuda a generar imágenes en miniatura de las formas de la diapositiva. Cómo usar esta función se describe en este artículo.

Este artículo explica cómo generar miniaturas de diapositivas de diferentes maneras:

- Generar una miniatura de una forma dentro de una diapositiva.
- Generar una miniatura de una forma de diapositiva con dimensiones definidas por el usuario.
- Generar una miniatura de una forma dentro de los límites de la apariencia de la forma.

## **Generación de miniaturas de forma a partir de diapositivas**

Para generar una miniatura de forma a partir de cualquier diapositiva usando Aspose.Slides para Node.js mediante Java, haga lo siguiente:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation).
1. Obtenga la referencia de cualquier diapositiva usando su ID o índice.
1. [Obtenga la imagen en miniatura de la forma](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/Shape#getImage--) de la diapositiva referenciada con la escala predeterminada.
1. Guarde la imagen en miniatura en el formato de imagen que prefiera.

Este fragmento de código muestra cómo generar una miniatura de forma a partir de una diapositiva:

```javascript
// Instanciar una clase Presentation que representa el archivo de presentación
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Crear una imagen a tamaño completo
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    // Guardar la imagen en disco en formato PNG
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Generación de miniaturas de forma con factor de escala definido por el usuario**

Para generar la miniatura de forma de una diapositiva usando Aspose.Slides para Node.js mediante Java, haga lo siguiente:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation).
1. Obtenga la referencia de cualquier diapositiva usando su ID o índice.
1. [Obtenga la imagen en miniatura de la forma](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/Shape#getImage-int-float-float-) de la diapositiva referenciada con dimensiones definidas por el usuario.
1. Guarde la imagen en miniatura en el formato de imagen que prefiera.

Este fragmento de código muestra cómo generar una miniatura de forma basándose en un factor de escala definido:

```javascript
// Instanciar una clase Presentation que representa el archivo de presentación
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Crear una imagen a escala completa
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Shape, 1, 1);
    // Guardar la imagen en disco en formato PNG
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Generación de miniatura de forma dentro de los límites**

Este método de crear miniaturas de formas permite a los desarrolladores generar una miniatura dentro de los límites de la apariencia de la forma. Tiene en cuenta todos los efectos de la forma. La miniatura generada está restringida por los límites de la diapositiva. Para generar una miniatura de una forma de diapositiva dentro de los límites de su apariencia, haga lo siguiente:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation).
1. Obtenga la referencia de cualquier diapositiva usando su ID o índice.
1. Obtenga la imagen en miniatura de la diapositiva referenciada con los límites de la forma como apariencia.
1. Guarde la imagen en miniatura en el formato de imagen que prefiera.

Este fragmento de código se basa en los pasos anteriores:

```javascript
// Instanciar una clase Presentation que representa el archivo de presentación
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Crear una imagen a escala completa
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Appearance, 1, 1);
    // Guardar la imagen en disco en formato PNG
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Obtener los límites visuales reales de una forma**

Las propiedades del marco de una [Shape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shape/) — sus métodos `getX()`, `getY()`, `getWidth()` y `getHeight()` — describen el rectángulo almacenado en el modelo de la presentación. El contenido que realmente se renderiza puede extenderse más allá de ese marco o ocupar un rectángulo alineado a los ejes diferente. La rotación, los contornos, las puntas de flecha, el diseño y desbordamiento del texto, la geometría generada de SmartArt y otros efectos de renderizado pueden cambiar el área ocupada.

Utilice [Shape.getVisualBounds](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shape/#getVisualBounds--) para calcular esa zona ocupada sin crear una imagen. El método devuelve un objeto [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) en coordenadas de diapositiva. El rectángulo devuelto no está recortado a la diapositiva, por lo que sus coordenadas pueden ser negativas cuando el contenido se extiende más allá del origen de la diapositiva.

El siguiente ejemplo obtiene y compara los límites del marco y los límites visuales:

```javascript
const presentation = new aspose.slides.Presentation("example.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);

    const visualBounds = shape.getVisualBounds();

    const frameBounds = {
        x: shape.getX(),
        y: shape.getY(),
        width: shape.getWidth(),
        height: shape.getHeight()
    };
    const visualBoundsValues = {
        x: visualBounds.getX(),
        y: visualBounds.getY(),
        width: visualBounds.getWidth(),
        height: visualBounds.getHeight()
    };

    console.log(
        `Frame bounds (x, y, width, height): ${frameBounds.x}, ${frameBounds.y}, ${frameBounds.width}, ${frameBounds.height}`
    );
    console.log(
        `Visual bounds (x, y, width, height): ${visualBoundsValues.x}, ${visualBoundsValues.y}, ${visualBoundsValues.width}, ${visualBoundsValues.height}`
    );
} finally {
    presentation.dispose();
}
```

El mismo rectángulo puede usarse para alinear formas cercanas a su borde izquierdo, derecho, superior o inferior; reservar suficiente espacio en un diseño generado; o detectar contenido fuera de una región permitida. Los límites visuales son especialmente útiles para SmartArt, cuadros de texto, flechas, imágenes, formas rotadas y formas agrupadas, donde el marco almacenado puede no representar el resultado renderizado completo.

Utilice [Shape.getVisualBounds](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shape/#getVisualBounds--) cuando necesite coordenadas para el diseño o validación y no necesite un mapa de bits. Utilice [Shape.getImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shape/#getImage--) cuando necesite renderizar la forma. Con [ShapeThumbnailBounds](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shapethumbnailbounds/), `ShapeThumbnailBounds.Shape` dimensiona la imagen a partir de los límites de la forma, incluidos los ajustes de contorno, mientras que `ShapeThumbnailBounds.Appearance` la dimensiona a partir de la apariencia de la forma y restringe el resultado a los límites de la diapositiva. En contraste, [Shape.getVisualBounds](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shape/#getVisualBounds--) solo devuelve el rectángulo calculado y no lo recorta a la diapositiva.

## **Preguntas frecuentes**

**¿Qué formatos de imagen se pueden usar al guardar miniaturas de forma?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/imageformat/), y otros. Las formas también pueden [exportarse como SVG vectorial](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shape/writeassvg/) guardando el contenido de la forma como SVG.

**¿Cuál es la diferencia entre los límites Shape y Appearance al renderizar una miniatura?**

`Shape` utiliza la geometría de la forma; `Appearance` tiene en cuenta los [efectos visuales](/slides/es/nodejs-java/shape-effect/) (sombras, brillos, etc.).

**¿Qué ocurre si una forma está marcada como oculta? ¿Se seguirá renderizando como miniatura?**

Una forma oculta sigue formando parte del modelo y puede renderizarse; la bandera oculta afecta la visualización de la presentación, pero no impide generar la imagen de la forma.

**¿Se admiten formas agrupadas, gráficos, SmartArt y otros objetos complejos?**

Sí. Cualquier objeto representado como [Shape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shape/) (incluyendo [GroupShape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chart/), y [SmartArt](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/smartart/)) puede guardarse como miniatura o como SVG.

**¿Las fuentes instaladas en el sistema afectan la calidad de las miniaturas de formas de texto?**

Sí. Debe [proporcionar las fuentes requeridas](/slides/es/nodejs-java/custom-font/) (o [configurar sustituciones de fuentes](/slides/es/nodejs-java/font-substitution/)) para evitar sustituciones no deseadas y reajustes de texto.