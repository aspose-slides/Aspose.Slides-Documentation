---
title: Convertir PowerPoint a PNG
type: docs
weight: 30
url: /es/nodejs-java/convert-powerpoint-to-png/
keywords: PowerPoint a PNG, PPT a PNG, PPTX a PNG, java, Aspose.Slides para Node.js mediante Java
description: Convertir presentación de PowerPoint a PNG
---

## **Acerca de la conversión de PowerPoint a PNG**

El formato PNG (Portable Network Graphics) no es tan popular como JPEG (Joint Photographic Experts Group), pero sigue siendo muy popular. 

**Caso de uso:** Cuando tienes una imagen compleja y el tamaño no es un problema, PNG es un formato de imagen mejor que JPEG. 

{{% alert title="Tip" color="primary" %}} Es posible que desees consultar los convertidores gratuitos de Aspose **PowerPoint a PNG**: [PPTX a PNG](https://products.aspose.app/slides/conversion/pptx-to-png) y [PPT a PNG](https://products.aspose.app/slides/conversion/ppt-to-png). Son una implementación en vivo del proceso descrito en esta página. {{% /alert %}}

## **Convertir PowerPoint a PNG**

Sigue estos pasos:

1. Instanciar la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Obtener el objeto de diapositiva de la colección devuelta por el método [Presentation.getSlides()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) bajo la clase [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide).
3. Utilizar el método [Slide.getImage()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide) para obtener la miniatura de cada diapositiva.
4. Utilizar el método [**Image.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Image#save(String formatName, int imageFormat)) para guardar la miniatura de la diapositiva en formato PNG.

Este código JavaScript muestra cómo convertir una presentación de PowerPoint a PNG:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var slideImage = slide.getImage();
        try {
            slideImage.save(("image_java_" + index) + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Convertir PowerPoint a PNG con dimensiones personalizadas**

Si deseas obtener archivos PNG con una escala determinada, puedes establecer los valores de `desiredX` y `desiredY`, que determinan las dimensiones de la miniatura resultante. 

Este código en JavaScript demuestra la operación descrita:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var scaleX = 2.0;
    var scaleY = 2.0;
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var slideImage = slide.getImage(scaleX, scaleY);
        try {
            slideImage.save(("image_java_" + index) + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Convertir PowerPoint a PNG con tamaño personalizado**

Si deseas obtener archivos PNG con un tamaño determinado, puedes pasar tus argumentos preferidos `width` y `height` para `ImageSize`. 

Este código muestra cómo convertir un PowerPoint a PNG especificando el tamaño de las imágenes: 
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var size = java.newInstanceSync("java.awt.Dimension", 960, 720);
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var slideImage = slide.getImage(size);
        try {
            slideImage.save(("image_java_" + index) + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Preguntas frecuentes**

**¿Cómo puedo exportar solo una forma específica (por ejemplo, un gráfico o una imagen) en lugar de toda la diapositiva?**

Aspose.Slides admite [generar miniaturas para formas individuales](/slides/es/nodejs-java/create-shape-thumbnails/); puedes renderizar una forma a una imagen PNG.

**¿Se admite la conversión paralela en un servidor?**

Sí, pero [no compartas](/slides/es/nodejs-java/multithreading/) una única instancia de presentación entre hilos. Usa una instancia separada por hilo o proceso.

**¿Cuáles son las limitaciones de la versión de prueba al exportar a PNG?**

El modo de evaluación añade una marca de agua a las imágenes de salida y aplica [otras restricciones](/slides/es/nodejs-java/licensing/) hasta que se aplique una licencia.