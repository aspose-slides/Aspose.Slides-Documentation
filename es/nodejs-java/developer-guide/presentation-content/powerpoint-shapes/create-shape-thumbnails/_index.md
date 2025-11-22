---
title: Crear miniaturas de forma
type: docs
weight: 70
url: /es/nodejs-java/create-shape-thumbnails/
---

## **Visión general**
{{% alert color="primary" %}} 

Aspose.Slides for Node.js via Java se puede usar para crear archivos de presentación en los que cada página corresponde a una diapositiva. Las diapositivas pueden visualizarse abriendo los archivos de presentación con Microsoft PowerPoint. Sin embargo, a veces los desarrolladores necesitan ver las imágenes de las formas por separado en un visor de imágenes. En esos casos, Aspose.Slides for Node.js via Java les ayuda a generar imágenes en miniatura de las formas de la diapositiva.

{{% /alert %}} 

En este artículo, mostraremos cómo generar miniaturas de diapositivas en diferentes situaciones:

- Generar una miniatura de forma dentro de una diapositiva.
- Generar una miniatura de forma para una forma de diapositiva con dimensiones definidas por el usuario.
- Generar una miniatura de forma dentro de los límites de la apariencia de una forma.

## **Generar miniaturas de forma a partir de diapositivas**
Para generar una miniatura de forma a partir de cualquier diapositiva usando Aspose.Slides for Node.js via Java, haga lo siguiente:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
1. Obtenga la referencia de cualquier diapositiva usando su ID o índice.
1. [Obtener la miniatura de la forma](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getImage--) de la diapositiva referenciada con escala predeterminada.
1. Guarde la imagen miniatura en el formato de imagen que prefiera.

Este código de ejemplo muestra cómo generar una miniatura de forma a partir de una diapositiva:
```javascript
// Instanciar una clase Presentation que representa el archivo de presentación
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Crear una imagen a escala completa
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


## **Generar miniaturas de forma con factor de escala definido por el usuario**
Para generar la miniatura de forma de una diapositiva usando Aspose.Slides for Node.js via Java, haga lo siguiente:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
1. Obtenga la referencia de cualquier diapositiva usando su ID o índice.
1. [Obtener la miniatura de la forma](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getImage-int-float-float-) de la diapositiva referenciada con dimensiones definidas por el usuario.
1. Guarde la imagen miniatura en el formato de imagen que prefiera.

Este código de ejemplo muestra cómo generar una miniatura de forma basada en un factor de escala definido:
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


## **Generar miniatura de forma de los límites**
Este método de creación de miniaturas de formas permite a los desarrolladores generar una miniatura dentro de los límites de la apariencia de la forma. Tiene en cuenta todos los efectos de la forma. La miniatura de forma generada está restringida por los límites de la diapositiva. Para generar una miniatura de una forma de diapositiva dentro de los límites de su apariencia, haga lo siguiente:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
1. Obtenga la referencia de cualquier diapositiva usando su ID o índice.
1. Obtenga la imagen miniatura de la diapositiva referenciada con los límites de la forma como apariencia.
1. Guarde la imagen miniatura en el formato de imagen que prefiera.

Este código de ejemplo se basa en los pasos anteriores:
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


## **FAQ**

**¿Qué formatos de imagen se pueden usar al guardar miniaturas de forma?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imageformat/), y otros. Las formas también pueden [exportarse como SVG vectorial](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/) guardando el contenido de la forma como SVG.

**¿Cuál es la diferencia entre los límites Shape y Appearance al renderizar una miniatura?**

`Shape` usa la geometría de la forma; `Appearance` tiene en cuenta [efectos visuales](/slides/es/nodejs-java/shape-effect/) (sombras, resplandores, etc.).

**¿Qué ocurre si una forma está marcada como oculta? ¿Se seguirá renderizando como miniatura?**

Una forma oculta sigue formando parte del modelo y puede renderizarse; la bandera oculta afecta la visualización de la presentación pero no impide generar la imagen de la forma.

**¿Se admiten formas agrupadas, gráficos, SmartArt y otros objetos complejos?**

Sí. Cualquier objeto representado como [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) (incluidos [GroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/) y [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/)) puede guardarse como miniatura o como SVG.

**¿Las fuentes instaladas en el sistema afectan la calidad de las miniaturas de formas de texto?**

Sí. Debe [proveer las fuentes necesarias](/slides/es/nodejs-java/custom-font/) (o [configurar sustituciones de fuentes](/slides/es/nodejs-java/font-substitution/)) para evitar retrocesos no deseados y reflujo de texto.