---
title: Convertir PowerPoint a JPG
type: docs
weight: 60
url: /es/nodejs-java/convert-powerpoint-to-jpg/
keywords: "Convertir PowerPoint a JPG, PPTX a JPEG, PPT a JPEG"
description: "Convertir PowerPoint a JPG: PPT a JPG, PPTX a JPG en JavaScript"
---

## **Acerca de la conversión de PowerPoint a JPG**
Con [**Aspose.Slides API**](https://products.aspose.com/slides/nodejs-java/) puedes convertir una presentación PowerPoint PPT o PPTX a imagen JPG. También es posible convertir PPT/PPTX a JPEG, PNG o SVG. Con estas funciones es fácil implementar tu propio visor de presentaciones, crear la miniatura para cada diapositiva. Esto puede ser útil si deseas proteger las diapositivas de la presentación contra la copia, demostrar la presentación en modo de solo lectura. Aspose.Slides permite convertir toda la presentación o una diapositiva concreta a formatos de imagen.  

{{% alert color="primary" %}} 

Para ver cómo Aspose.Slides convierte PowerPoint a imágenes JPG, puedes probar estos convertidores gratuitos en línea: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) y [PPT to JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 

{{% /alert %}} 

![todo:image_alt_text](ppt-to-jpg.png)

## **Convertir PowerPoint PPT/PPTX a JPG**
Estos son los pasos para convertir PPT/PPTX a JPG:

1. Crea una instancia del tipo [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Obtén el objeto de diapositiva del tipo [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide) mediante la colección [Presentation.getSlides()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) .
3. Crea la miniatura de cada diapositiva y luego conviértela a JPG. El método [**Slide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide#getImage-float-float-) se usa para obtener una miniatura de una diapositiva; devuelve un objeto [Imagess](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Images). El método [getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide#getImage-aspose.slides.IRenderingOptions-float-float-) debe llamarse desde la diapositiva necesaria del tipo [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide); las escalas de la miniatura resultante se pasan al método.
4. Después de obtener la miniatura de la diapositiva, llama al método [**Image.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Image#save(String formatName, int imageFormat)) del objeto miniatura. Pasa el nombre del archivo resultante y el formato de imagen.  

{{% alert color="primary" %}}

**Nota**: la conversión de PPT/PPTX a JPG difiere de la conversión a otros tipos en la API de Aspose.Slides. Para otros tipos, normalmente usas el método [**Presentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-), pero aquí necesitas el método [**Image.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Image#save(String formatName, int imageFormat)).  

{{% /alert %}} 
```javascript
var pres = new aspose.slides.Presentation("PowerPoint-Presentation.pptx");
try {
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        // Crea una imagen a escala completa
        var slideImage = sld.getImage(1.0, 1.0);
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


## **Convertir PowerPoint PPT/PPTX a JPG con dimensiones personalizadas**
Para cambiar la dimensión de la miniatura y la imagen JPG resultante, puedes establecer los valores *ScaleX* y *ScaleY* pasándolos a los métodos [**Slide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide#getImage-float-float-):
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
Aspose.Slides for Node.js via Java proporciona una funcionalidad que permite renderizar los comentarios en las diapositivas de una presentación al convertir esas diapositivas a imágenes. Este código JavaScript muestra la operación:
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

Aspose ofrece una [aplicación web GRATUITA de Collage](https://products.aspose.app/slides/collage). Usando este servicio en línea, puedes combinar [JPG a JPG](https://products.aspose.app/slides/collage/jpg) o PNG a PNG, crear [rejillas de fotos](https://products.aspose.app/slides/collage/photo-grid), etc.  

Usando los mismos principios descritos en este artículo, puedes convertir imágenes de un formato a otro. Para más información, consulta estas páginas: convertir [imagen a JPG](https://products.aspose.com/slides/nodejs-java/conversion/image-to-jpg/); convertir [JPG a imagen](https://products.aspose.com/slides/nodejs-java/conversion/jpg-to-image/); convertir [JPG a PNG](https://products.aspose.com/slides/nodejs-java/conversion/jpg-to-png/), convertir [PNG a JPG](https://products.aspose.com/slides/nodejs-java/conversion/png-to-jpg/); convertir [PNG a SVG](https://products.aspose.com/slides/nodejs-java/conversion/png-to-svg/), convertir [SVG a PNG](https://products.aspose.com/slides/nodejs-java/conversion/svg-to-png/).  

{{% /alert %}}

## **Véase también**

Consulta otras opciones para convertir PPT/PPTX a imagen como:

- [Conversión de PPT/PPTX a SVG](/slides/es/nodejs-java/render-a-slide-as-an-svg-image/).

## **Preguntas frecuentes**

**¿Este método admite la conversión por lotes?**

Sí, Aspose.Slides permite la conversión por lotes de varias diapositivas a JPG en una única operación.

**¿La conversión admite SmartArt, gráficos y otros objetos complejos?**

Sí, Aspose.Slides renderiza todo el contenido, incluidos SmartArt, gráficos, tablas, formas y más. Sin embargo, la precisión del renderizado puede variar ligeramente respecto a PowerPoint, especialmente al usar fuentes personalizadas o faltantes.

**¿Existen limitaciones en la cantidad de diapositivas que pueden procesarse?**

Aspose.Slides en sí no impone límites estrictos sobre la cantidad de diapositivas que puedes procesar. No obstante, podrías encontrar errores de falta de memoria al trabajar con presentaciones muy grandes o imágenes de alta resolución.