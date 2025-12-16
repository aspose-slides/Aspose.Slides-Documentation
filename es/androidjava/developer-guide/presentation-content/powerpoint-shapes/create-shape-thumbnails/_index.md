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
- PowerPoint
- presentación
- Android
- Java
- Aspose.Slides
description: "Genere miniaturas de forma de alta calidad a partir de diapositivas de PowerPoint con Aspose.Slides para Android vía Java – cree y exporte fácilmente miniaturas de presentaciones."
---

## **Visión general**
{{% alert color="primary" %}} 

Aspose.Slides for Android via Java se puede usar para crear archivos de presentación en los que cada página corresponde a una diapositiva. Las diapositivas pueden verse abriendo los archivos de presentación con Microsoft PowerPoint. Sin embargo, los desarrolladores a veces necesitan ver las imágenes de las formas por separado en un visor de imágenes. En esos casos, Aspose.Slides for Android via Java les ayuda a generar imágenes en miniatura de las formas de la diapositiva.

{{% /alert %}} 

En este tema, mostraremos cómo generar miniaturas de diapositivas en diferentes situaciones:

- Generar una miniatura de forma dentro de una diapositiva.
- Generar una miniatura de forma para una forma de diapositiva con dimensiones definidas por el usuario.
- Generar una miniatura de forma dentro de los límites de la apariencia de la forma.

## **Generar una Miniatura de Forma a partir de una Diapositiva**
Para generar una miniatura de forma a partir de cualquier diapositiva usando Aspose.Slides for Android via Java, haga lo siguiente:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Obtenga la referencia de cualquier diapositiva utilizando su ID o índice.
1. [Obtenga la imagen en miniatura de la forma](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getImage--) de la diapositiva referenciada con la escala predeterminada.
1. Guarde la imagen en miniatura en el formato de imagen que prefiera.

Este código de ejemplo muestra cómo generar una miniatura de forma a partir de una diapositiva:
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


## **Generar una Miniatura con Factor de Escala Definido por el Usuario**
Para generar la miniatura de forma de una diapositiva usando Aspose.Slides for Android via Java, haga lo siguiente:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Obtenga la referencia de cualquier diapositiva utilizando su ID o índice.
1. [Obtenga la imagen en miniatura de la forma](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getImage-int-float-float-) de la diapositiva referenciada con dimensiones definidas por el usuario.
1. Guarde la imagen en miniatura en el formato de imagen que prefiera.

Este código de ejemplo muestra cómo generar una miniatura de forma basada en un factor de escala definido:
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


## **Crear una Miniatura de Apariencia de Forma basada en Límites**
Este método de crear miniaturas de formas permite a los desarrolladores generar una miniatura dentro de los límites de la apariencia de la forma. Tiene en cuenta todos los efectos de la forma. La miniatura de forma generada está restringida por los límites de la diapositiva. Para generar una miniatura de una forma de diapositiva dentro de los límites de su apariencia, haga lo siguiente:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Obtenga la referencia de cualquier diapositiva utilizando su ID o índice.
1. Obtenga la imagen en miniatura de la diapositiva referenciada con los límites de la forma como apariencia.
1. Guarde la imagen en miniatura en el formato de imagen que prefiera.

Este código de ejemplo se basa en los pasos anteriores:
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


## **Preguntas frecuentes**

**¿Qué formatos de imagen se pueden usar al guardar miniaturas de forma?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imageformat/), y otros. Las formas también pueden [exportarse como SVG vectorial](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) al guardar el contenido de la forma como SVG.

**¿Cuál es la diferencia entre los límites Shape y Appearance al renderizar una miniatura?**

`Shape` utiliza la geometría de la forma; `Appearance` tiene en cuenta los [efectos visuales](/slides/es/androidjava/shape-effect/) (sombras, brillos, etc.).

**¿Qué ocurre si una forma está marcada como oculta? ¿Se seguirá renderizando como miniatura?**

Una forma oculta sigue formando parte del modelo y puede renderizarse; la bandera oculta afecta la visualización en la presentación pero no impide generar la imagen de la forma.

**¿Se admiten formas grupales, gráficos, SmartArt y otros objetos complejos?**

Sí. Cualquier objeto representado como [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/) (incluidos [GroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/), y [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartart/)) puede guardarse como miniatura o como SVG.

**¿Afectan las fuentes instaladas en el sistema la calidad de las miniaturas de formas de texto?**

Sí. Debe [proporcionar las fuentes necesarias](/slides/es/androidjava/custom-font/) (o [configurar sustituciones de fuentes](/slides/es/androidjava/font-substitution/)) para evitar sustituciones no deseadas y reajuste del texto.