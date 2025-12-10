---
title: Convertir diapositivas de PowerPoint a PNG en Java
linktitle: PowerPoint a PNG
type: docs
weight: 30
url: /es/java/convert-powerpoint-to-png/
keywords:
- convertir PowerPoint
- convertir presentación
- convertir diapositiva
- convertir PPT
- convertir PPTX
- PowerPoint a PNG
- presentación a PNG
- diapositiva a PNG
- PPT a PNG
- PPTX a PNG
- guardar PPT como PNG
- guardar PPTX como PNG
- exportar PPT a PNG
- exportar PPTX a PNG
- Java
- Aspose.Slides
description: "Convertir presentaciones de PowerPoint a imágenes PNG de alta calidad rápidamente con Aspose.Slides para Java, garantizando resultados precisos y automatizados."
---

## **Acerca de la conversión de PowerPoint a PNG**

El formato PNG (Portable Network Graphics) no es tan popular como JPEG (Joint Photographic Experts Group), pero sigue siendo muy popular. 

**Caso de uso:** Cuando tienes una imagen compleja y el tamaño no es un problema, PNG es un formato de imagen mejor que JPEG. 

{{% alert title="Tip" color="primary" %}} Quizá quieras probar los conversores gratuitos de Aspose **PowerPoint a PNG**: [PPTX a PNG](https://products.aspose.app/slides/conversion/pptx-to-png) y [PPT a PNG](https://products.aspose.app/slides/conversion/ppt-to-png). Son una implementación en vivo del proceso descrito en esta página. {{% /alert %}}

## **Convertir PowerPoint a PNG**

Sigue estos pasos:

1. Instancia la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Obtén el objeto diapositiva de la colección [Presentation.getSlides()](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) bajo la interfaz [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide). 
3. Usa el método [ISlide.getImage()](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide) para obtener la miniatura de cada diapositiva.
4. Utiliza el método [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/java/com.aspose.slides/IImage#save(String%20formatName,%20int%20imageFormat)) para guardar la miniatura de la diapositiva en formato PNG.

Este código Java muestra cómo convertir una presentación de PowerPoint a PNG:
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

Si deseas obtener archivos PNG a cierta escala, puedes establecer los valores de `desiredX` y `desiredY`, que determinan las dimensiones de la miniatura resultante. 

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

Si deseas obtener archivos PNG a cierto tamaño, puedes pasar los argumentos `width` y `height` que prefieras para `ImageSize`. 

Este código muestra cómo convertir un PowerPoint a PNG especificando el tamaño de las imágenes: 
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


## **FAQ**

**¿Cómo puedo exportar solo una forma específica (p. ej., gráfico o imagen) en lugar de toda la diapositiva?**

Aspose.Slides soporta [generar miniaturas para formas individuales](/slides/es/java/create-shape-thumbnails/); puedes renderizar una forma a una imagen PNG.

**¿Se admite la conversión paralela en un servidor?**

Sí, pero [no compartas](/slides/es/java/multithreading/) una única instancia de presentación entre hilos. Utiliza una instancia separada por hilo o proceso.

**¿Cuáles son las limitaciones de la versión de prueba al exportar a PNG?**

El modo de evaluación agrega una marca de agua a las imágenes de salida y aplica [otras restricciones](/slides/es/java/licensing/) hasta que se aplique una licencia.