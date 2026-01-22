---
title: Convertir diapositivas de PowerPoint a PNG en JavaScript
linktitle: PowerPoint a PNG
type: docs
weight: 30
url: /es/nodejs-java/convert-powerpoint-to-png/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Convierta presentaciones de PowerPoint a imágenes PNG de alta calidad en JavaScript rápidamente con Aspose.Slides para Node.js, garantizando resultados precisos y automatizados."
---

## **Acerca de la conversión de PowerPoint a PNG**

El formato PNG (Portable Network Graphics) no es tan popular como JPEG (Joint Photographic Experts Group), pero sigue siendo muy popular. 

**Caso de uso:** Cuando tienes una imagen compleja y el tamaño no es un problema, PNG es un formato de imagen mejor que JPEG. 

{{% alert title="Tip" color="primary" %}} Puede que desee consultar los conversores gratuitos de Aspose **PowerPoint a PNG**: [PPTX a PNG](https://products.aspose.app/slides/conversion/pptx-to-png) y [PPT a PNG](https://products.aspose.app/slides/conversion/ppt-to-png). Son una implementación en vivo del proceso descrito en esta página. {{% /alert %}}

## **Convertir PowerPoint a PNG**

Siga estos pasos:

1. Instanciar la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Obtener el objeto de diapositiva de la colección devuelta por el método [Presentation.getSlides()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) bajo la clase [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide).
3. Utilizar el método [Slide.getImage()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide) para obtener la miniatura de cada diapositiva.
4. Utilizar el método [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) para guardar la miniatura de la diapositiva en formato PNG.

Este código JavaScript le muestra cómo convertir una presentación PowerPoint a PNG:
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

Si desea obtener archivos PNG con una determinada escala, puede establecer los valores de `desiredX` y `desiredY`, que determinan las dimensiones de la miniatura resultante. 

Este código JavaScript demuestra la operación descrita:
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

Si desea obtener archivos PNG con un tamaño determinado, puede pasar los argumentos `width` y `height` que prefiera para `ImageSize`. 

Este código le muestra cómo convertir un PowerPoint a PNG especificando el tamaño de las imágenes: 
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


## **FAQ**

**¿Cómo puedo exportar solo una forma específica (p. ej., gráfico o imagen) en lugar de toda la diapositiva?**

Aspose.Slides admite [generar miniaturas para formas individuales](/slides/es/nodejs-java/create-shape-thumbnails/); puede renderizar una forma a una imagen PNG.

**¿Se admite la conversión paralela en un servidor?**

Sí, pero [no comparta](/slides/es/nodejs-java/multithreading/) una única instancia de presentación entre hilos. Utilice una instancia separada por hilo o proceso.

**¿Cuáles son las limitaciones de la versión de prueba al exportar a PNG?**

El modo de evaluación añade una marca de agua a las imágenes de salida y aplica [otras restricciones](/slides/es/nodejs-java/licensing/) hasta que se aplique una licencia.