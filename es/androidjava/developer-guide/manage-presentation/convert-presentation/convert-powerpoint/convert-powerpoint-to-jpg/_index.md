---
title: Convertir Powerpoint a JPG
type: docs
weight: 60
url: /es/androidjava/convert-powerpoint-to-jpg/
keywords:
- Convertir presentación de PowerPoint
- JPG
- JPEG
- PowerPoint a JPG
- PowerPoint a JPEG
- PPT a JPG
- PPTX a JPG
- PPT a JPEG
- PPTX a JPEG
- Android
- Aspose.Slides
description: "Convertir PowerPoint a JPG: PPT a JPG, PPTX a JPG en Java"
---


## **Acerca de la Conversión de PowerPoint a JPG**
Con el [**Aspose.Slides API**](https://products.aspose.com/slides/androidjava/) puedes convertir presentaciones de PowerPoint PPT o PPTX a imágenes JPG. También es posible convertir PPT/PPTX a JPEG, PNG o SVG. Con estas características es fácil implementar tu propio visor de presentaciones, crear la miniatura para cada diapositiva. Esto puede ser útil si deseas proteger las diapositivas de presentación de derechos de autor, demostrar la presentación en modo de solo lectura. Aspose.Slides permite convertir toda la presentación o una diapositiva en formatos de imagen. 

{{% alert color="primary" %}} 

Para ver cómo Aspose.Slides convierte PowerPoint a imágenes JPG, puedes probar estos conversores en línea gratuitos: PowerPoint [PPTX a JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) y [PPT a JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 

{{% /alert %}} 

![todo:texto_alt_imagen](ppt-to-jpg.png)

## **Convertir PowerPoint PPT/PPTX a JPG**
Aquí están los pasos para convertir PPT/PPTX a JPG:

1. Crea una instancia del tipo [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Obtén el objeto diapositiva del tipo [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide) de la colección [Presentation.getSlides()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) .
3. Crea la miniatura de cada diapositiva y luego conviértela a JPG. El método [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide#getImage-float-float-) se utiliza para obtener una miniatura de una diapositiva, devuelve un objeto [Images](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Images) como resultado. El método [getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-float-float-) debe ser llamado desde la diapositiva necesaria del tipo [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide), los escalas de la miniatura resultante se pasan al método.
4. Después de obtener la miniatura de la diapositiva, llama al método [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImage#save(String formatName, int imageFormat)) del objeto de miniatura. Pasa el nombre del archivo resultante y el formato de imagen.

{{% alert color="primary" %}}

**Nota**: La conversión de PPT/PPTX a JPG difiere de la conversión a otros tipos en Aspose.Slides API. Para otros tipos, generalmente utilizas el método [**IPresentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-), pero aquí necesitas el método [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImage#save(String formatName, int imageFormat)).

{{% /alert %}} 

```java
Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    for (ISlide sld : pres.getSlides()) {
        // Crea una imagen a escala completa
        IImage slideImage = sld.getImage(1f, 1f);

        // Guarda la imagen en el disco en formato JPEG
        try {
              slideImage.save(String.format("Slide_%d.jpg", sld.getSlideNumber()), ImageFormat.Jpeg);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Convertir PowerPoint PPT/PPTX a JPG con Dimensiones Personalizadas**
Para cambiar la dimensión de la miniatura resultante y la imagen JPG, puedes establecer los valores *ScaleX* y *ScaleY* pasándolos a los métodos [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide#getImage-float-float-):

```java
Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    // Define dimensiones
    int desiredX = 1200;
    int desiredY = 800;
    // Obtiene valores escalados de X y Y
    float ScaleX = (float) (1.0 / pres.getSlideSize().getSize().getWidth()) * desiredX;
    float ScaleY = (float) (1.0 / pres.getSlideSize().getSize().getHeight()) * desiredY;

    for (ISlide sld : pres.getSlides())
    {
        // Crea una imagen a escala completa
        IImage slideImage = sld.getImage(ScaleX, ScaleY);

        // Guarda la imagen en el disco en formato JPEG
        try {
              slideImage.save(String.format("Slide_%d.jpg", sld.getSlideNumber()), ImageFormat.Jpeg);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Rendir Comentarios al guardar la Presentación en Imagen**
Aspose.Slides para Android a través de Java proporciona una herramienta que te permite renderizar comentarios en las diapositivas de una presentación cuando conviertes esas diapositivas en imágenes. Este código Java demuestra la operación:

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomTruncated);

    IRenderingOptions opts = new RenderingOptions();
    opts.setSlidesLayoutOptions(notesOptions);

    for (ISlide sld : pres.getSlides()) {
        IImage slideImage = sld.getImage(opts, new Dimension(740, 960));
        try {
             slideImage.save(String.format("Slide_%d.png", sld.getSlideNumber()));
        } finally {
                     if (slideImage != null) slideImage.dispose();
                }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Consejo" color="primary" %}}

Aspose proporciona una [aplicación web GRATIS Collage](https://products.aspose.app/slides/collage). Utilizando este servicio en línea, puedes combinar [JPG a JPG](https://products.aspose.app/slides/collage/jpg) o imágenes PNG a PNG, crear [rejillas de fotos](https://products.aspose.app/slides/collage/photo-grid), y más. 

Usando los mismos principios descritos en este artículo, puedes convertir imágenes de un formato a otro. Para más información, consulta estas páginas: convertir [imagen a JPG](https://products.aspose.com/slides/androidjava/conversion/image-to-jpg/); convertir [JPG a imagen](https://products.aspose.com/slides/androidjava/conversion/jpg-to-image/); convertir [JPG a PNG](https://products.aspose.com/slides/androidjava/conversion/jpg-to-png/), convertir [PNG a JPG](https://products.aspose.com/slides/androidjava/conversion/png-to-jpg/); convertir [PNG a SVG](https://products.aspose.com/slides/androidjava/conversion/png-to-svg/), convertir [SVG a PNG](https://products.aspose.com/slides/androidjava/conversion/svg-to-png/).

{{% /alert %}}

## **Ver también**

Consulta otras opciones para convertir PPT/PPTX en imágenes como:

- [Conversión de PPT/PPTX a SVG](/slides/es/androidjava/render-a-slide-as-an-svg-image/).