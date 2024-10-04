---
title: Crear miniaturas de formas
type: docs
weight: 70
url: /java/create-shape-thumbnails/
---


## **Descripción general**
{{% alert color="primary" %}} 

Aspose.Slides para Java se puede utilizar para crear archivos de presentación en los que cada página corresponde a una diapositiva. Las diapositivas se pueden ver abriendo los archivos de presentación con Microsoft PowerPoint. Sin embargo, a veces los desarrolladores necesitan ver las imágenes de las formas por separado en un visor de imágenes. En tales casos, Aspose.Slides para Java les ayuda a generar imágenes en miniatura de las formas de diapositivas.

{{% /alert %}} 

En este tema, mostraremos cómo generar miniaturas de diapositivas en diferentes situaciones:

- Generar una miniatura de forma dentro de una diapositiva.
- Generar una miniatura de forma para una forma de diapositiva con dimensiones definidas por el usuario.
- Generar una miniatura de forma dentro de los límites de la apariencia de una forma.

## **Generación de miniaturas de forma desde diapositivas**
Para generar una miniatura de forma desde cualquier diapositiva usando Aspose.Slides para Java, haga lo siguiente:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. Obtenga la referencia de cualquier diapositiva usando su ID o índice.
1. [Obtenga la imagen de miniatura de la forma](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getImage--) de la diapositiva referenciada en escala predeterminada.
1. Guarde la imagen en miniatura en su formato de imagen preferido.

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

## **Generación de miniaturas de forma con factor de escalado definido por el usuario**
Para generar la miniatura de forma de una diapositiva usando Aspose.Slides para Java, haga lo siguiente:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. Obtenga la referencia de cualquier diapositiva usando su ID o índice.
1. [Obtenga la imagen de miniatura de la forma](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getImage-int-float-float-) de la diapositiva referenciada con dimensiones definidas por el usuario.
1. Guarde la imagen en miniatura en su formato de imagen preferido.

Este código de ejemplo muestra cómo generar una miniatura de forma basada en un factor de escalado definido:

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

## **Generación de miniatura de forma de límites**
Este método de creación de miniaturas de formas permite a los desarrolladores generar una miniatura dentro de los límites de la apariencia de la forma. Tiene en cuenta todos los efectos de la forma. La miniatura de forma generada está restringida por los límites de la diapositiva. Para generar una miniatura de una forma de diapositiva en los límites de su apariencia, haga lo siguiente:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. Obtenga la referencia de cualquier diapositiva usando su ID o índice.
1. Obtenga la imagen de miniatura de la diapositiva referenciada con los límites de forma como apariencia.
1. Guarde la imagen en miniatura en su formato de imagen preferido.

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