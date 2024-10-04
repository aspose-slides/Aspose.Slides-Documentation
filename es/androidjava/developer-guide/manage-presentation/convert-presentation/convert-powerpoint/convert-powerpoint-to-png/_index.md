---
title: Convertir PowerPoint a PNG
type: docs
weight: 30
url: /androidjava/convert-powerpoint-to-png/
keywords: PowerPoint a PNG, PPT a PNG, PPTX a PNG, java, Aspose.Slides para Android a través de Java
description: Convertir presentación de PowerPoint a PNG
---

## **Acerca de la conversión de PowerPoint a PNG**

El formato PNG (Portable Network Graphics) no es tan popular como JPEG (Joint Photographic Experts Group), pero sigue siendo muy popular.

**Caso de uso:** Cuando tienes una imagen compleja y el tamaño no es un problema, PNG es un mejor formato de imagen que JPEG.

{{% alert title="Consejo" color="primary" %}} Puede que quieras probar los **Convertidores de PowerPoint a PNG** gratuitos de Aspose: [PPTX a PNG](https://products.aspose.app/slides/conversion/pptx-to-png) y [PPT a PNG](https://products.aspose.app/slides/conversion/ppt-to-png). Son una implementación en vivo del proceso descrito en esta página. {{% /alert %}}

## **Convertir PowerPoint a PNG**

Sigue estos pasos:

1. Instancia la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Obtén el objeto slide de la colección [Presentation.getSlides()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) bajo la interfaz [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide).
3. Usa el método [ISlide.getImage()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide) para obtener la miniatura de cada diapositiva.
4. Usa el método [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImage#save(String formatName, int imageFormat)) para guardar la miniatura de la diapositiva en formato PNG.

Este código Java te muestra cómo convertir una presentación de PowerPoint a PNG:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage();
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Convertir PowerPoint a PNG con dimensiones personalizadas**

Si deseas obtener archivos PNG de un cierto tamaño, puedes establecer los valores de `desiredX` y `desiredY`, que determinan las dimensiones de la miniatura resultante.

Este código en Java demuestra la operación descrita:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    float scaleX = 2f;
    float scaleY = 2f;
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage(scaleX, scaleY);
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Convertir PowerPoint a PNG con tamaño personalizado**

Si deseas obtener archivos PNG de un cierto tamaño, puedes pasar tus argumentos preferidos `width` y `height` para `ImageSize`.

Este código te muestra cómo convertir un PowerPoint a PNG mientras specifies el tamaño para las imágenes:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Dimension size = new Dimension(960, 720);
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage(size);
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```