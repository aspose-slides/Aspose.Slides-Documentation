---
title: Convertir PPT y PPTX a JPG en JavaScript
linktitle: PowerPoint a JPG
type: docs
weight: 60
url: /es/nodejs-java/convert-powerpoint-to-jpg/
keywords:
- convertir PowerPoint
- convertir presentación
- convertir diapositiva
- convertir PPT
- convertir PPTX
- PowerPoint a JPG
- presentación a JPG
- diapositiva a JPG
- PPT a JPG
- PPTX a JPG
- guardar PowerPoint como JPG
- guardar presentación como JPG
- guardar diapositiva como JPG
- guardar PPT como JPG
- guardar PPTX como JPG
- exportar PPT a JPG
- exportar PPTX a JPG
- Node.js
- JavaScript
- Aspose.Slides
description: "Convierta diapositivas PowerPoint (PPT, PPTX) a imágenes JPG de alta calidad en JavaScript con Aspose.Slides para Node.js a través de Java, usando ejemplos de código rápidos y fiables."
---

## **Acerca de la conversión de PowerPoint a JPG**
Con [**Aspose.Slides API**](https://products.aspose.com/slides/nodejs-java/) puedes convertir presentaciones PowerPoint PPT o PPTX a imágenes JPG. También es posible convertir PPT/PPTX a JPEG, PNG o SVG. Con estas funciones es fácil implementar tu propio visor de presentaciones, crear la miniatura de cada diapositiva. Esto puede ser útil si deseas proteger las diapositivas de la presentación contra la copia, o demostrar la presentación en modo de solo lectura. Aspose.Slides permite convertir toda la presentación o una diapositiva concreta a formatos de imagen.

{{% alert color="primary" %}} 
Para ver cómo Aspose.Slides convierte PowerPoint a imágenes JPG, puedes probar estos convertidores gratuitos en línea: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) y [PPT to JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 
{{% /alert %}} 

![todo:image_alt_text](ppt-to-jpg.png)

## **Convertir PowerPoint PPT/PPTX a JPG**
Estos son los pasos para convertir PPT/PPTX a JPG:

1. Crear una instancia del tipo [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Obtener el objeto de diapositiva del tipo [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide) a partir de la colección [Presentation.getSlides()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--).
3. Crear la miniatura de cada diapositiva y luego convertirla a JPG. El método [**Slide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide#getImage-float-float-) se usa para obtener una miniatura de una diapositiva, devuelve un objeto [Imagess](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Images) como resultado. El método [getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide#getImage-aspose.slides.IRenderingOptions-float-float-) debe llamarse desde la diapositiva necesaria del tipo [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide), y las escalas de la miniatura resultante se pasan al método.
4. Después de obtener la miniatura de la diapositiva, llama al método [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) del objeto miniatura. Pasa el nombre de archivo resultante y el formato de imagen.

{{% alert color="primary" %}}

**Nota**: La conversión de PPT/PPTX a JPG difiere de la conversión a otros tipos en la API Aspose.Slides. Para otros tipos, normalmente usas [**Presentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-), pero aquí necesitas el método [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save).

{{% /alert %}} 
```javascript
var pres = new aspose.slides.Presentation("PowerPoint-Presentation.pptx");
try {
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        // Crea una imagen a escala completa
        var slideImage = sld.getImage(1.0, 1.0);
        // Guarda la imagen en el disco en formato JPEG
        try {
            slideImage.save(java.callStaticMethodSync("java.lang.String", "format", "Slide_%d.jpg", sld.getSlideNumber()), aspose.slides.ImageFormat.Jpeg);
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


## **Convertir PowerPoint PPT/PPTX a JPG con dimensiones personalizadas**
Para cambiar la dimensión de la miniatura y la imagen JPG resultantes, puedes establecer los valores *ScaleX* y *ScaleY* pasándolos a los métodos [**Slide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide#getImage-float-float-) :

```javascript
var pres = new aspose.slides.Presentation("PowerPoint-Presentation.pptx");
try {
    // Define las dimensiones
    var desiredX = 1200;
    var desiredY = 800;
    // Obtiene los valores escalados de X y Y
    var ScaleX = 1.0 / pres.getSlideSize().getSize().getWidth() * desiredX;
    var ScaleY = 1.0 / pres.getSlideSize().getSize().getHeight() * desiredY;
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        // Crea una imagen a escala completa
        var slideImage = sld.getImage(ScaleX, ScaleY);
        // Guarda la imagen en disco en formato JPEG
        try {
            slideImage.save(java.callStaticMethodSync("java.lang.String", "format", "Slide_%d.jpg", sld.getSlideNumber()), aspose.slides.ImageFormat.Jpeg);
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


## **Renderizar comentarios al guardar la presentación como imagen**
Aspose.Slides para Node.js a través de Java proporciona una funcionalidad que permite renderizar comentarios en las diapositivas de una presentación al convertir esas diapositivas en imágenes. Este código JavaScript demuestra la operación:
```javascript
var pres = new aspose.slides.Presentation("presentation.pptx");
try {
    var notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);
    var opts = new aspose.slides.RenderingOptions();
    opts.setSlidesLayoutOptions(notesOptions);
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        var slideImage = sld.getImage(opts, java.newInstanceSync("java.awt.Dimension", 740, 960));
        try {
            slideImage.save(java.callStaticMethodSync("java.lang.String", "format", "Slide_%d.png", sld.getSlideNumber()));
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


{{% alert title="Tip" color="primary" %}}

Aspose ofrece una [aplicación web GRATUITA Collage](https://products.aspose.app/slides/collage). Con este servicio en línea, puedes combinar imágenes [JPG a JPG](https://products.aspose.app/slides/collage/jpg) o PNG a PNG, crear [cuadrículas de fotos](https://products.aspose.app/slides/collage/photo-grid), etc.

{{% /alert %}}

## **Ver también**
Consulta otras opciones para convertir PPT/PPTX en imagen, como:

- [Conversión de PPT/PPTX a SVG](/slides/es/nodejs-java/render-a-slide-as-an-svg-image/).

## **Preguntas frecuentes**

**¿Este método admite la conversión por lotes?**

Sí, Aspose.Slides permite la conversión por lotes de varias diapositivas a JPG en una única operación.

**¿La conversión admite SmartArt, gráficos y otros objetos complejos?**

Sí, Aspose.Slides renderiza todo el contenido, incluidos SmartArt, gráficos, tablas, formas y más. Sin embargo, la precisión del renderizado puede variar ligeramente respecto a PowerPoint, especialmente al usar fuentes personalizadas o faltantes.

**¿Hay limitaciones en el número de diapositivas que se pueden procesar?**

Aspose.Slides en sí no impone límites estrictos al número de diapositivas que puedes procesar. No obstante, podrías encontrarte con errores de falta de memoria al trabajar con presentaciones muy grandes o imágenes de alta resolución.