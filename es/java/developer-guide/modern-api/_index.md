---
title: "Mejorar el procesamiento de imágenes con la API moderna"
linktitle: "API moderna"
type: docs
weight: 237
url: /es/java/modern-api/
keywords:
- "API moderna"
- "dibujo"
- "miniatura de diapositiva"
- "diapositiva a imagen"
- "miniatura de forma"
- "forma a imagen"
- "miniatura de presentación"
- "presentación a imágenes"
- "añadir imagen"
- "añadir foto"
- "Java"
- "Aspose.Slides"
description: "Modernice el procesamiento de imágenes de diapositivas sustituyendo las API de imágenes obsoletas por la API Moderna de Java para una automatización fluida de PowerPoint y OpenDocument."
---
## **Introducción**

Históricamente, Aspose Slides tiene una dependencia de java.awt y en la API pública contiene las siguientes clases de allí:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

A partir de la versión 24.4, esta API pública está declarada como obsoleta.

Para eliminar las dependencias de estas clases, hemos añadido la llamada "API Moderna", es decir, la API que debe usarse en lugar de la obsoleta, cuyas firmas contienen dependencias de [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html). [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) está declarada obsoleta y su soporte se ha eliminado de la API pública de Slides.

En las versiones actuales, trate la API pública que depende de tipos java.awt como legado/obsoleta. Use la API Moderna para código nuevo y al migrar flujos de trabajo de procesamiento de imágenes existentes.

## **API Moderna**

Se agregaron las siguientes clases y enumeraciones a la API pública:

- [IImage](https://reference.aspose.com/slides/es/java/com.aspose.slides/iimage/) - representa la imagen raster o vectorial.
- [ImageFormat](https://reference.aspose.com/slides/es/java/com.aspose.slides/imageformat/) - representa el formato de archivo de la imagen.
- [Images](https://reference.aspose.com/slides/es/java/com.aspose.slides/images/) - métodos para instanciar y trabajar con la interfaz [IImage](https://reference.aspose.com/slides/es/java/com.aspose.slides/iimage/).

Tenga en cuenta que [IImage](https://reference.aspose.com/slides/es/java/com.aspose.slides/iimage/) es descartable y su uso debe ir seguido de una llamada a `dispose()` o de otro patrón de eliminación conveniente.

Use `getImage` para renderizar una diapositiva o forma única. Use `getImages` para renderizar varias diapositivas de la presentación. Use los métodos de [Images](https://reference.aspose.com/slides/es/java/com.aspose.slides/images/) para cargar imágenes, `addImage` con [IImage](https://reference.aspose.com/slides/es/java/com.aspose.slides/iimage/) para agregarlas a una presentación, y `replaceImage` con [IImage](https://reference.aspose.com/slides/es/java/com.aspose.slides/iimage/) para actualizar una imagen existente de la presentación.

Un escenario típico de uso de la nueva API puede ser el siguiente:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage;
    // instanciar una instancia descartable de IImage desde el archivo en el disco.
    IImage image = Images.fromFile("image.png");
    try {
        // crear una imagen de PowerPoint añadiendo una instancia de IImage a las imágenes de la presentación.
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // añadir una forma de imagen en la diapositiva nº 1
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // obtener una instancia de IImage que representa la diapositiva nº 1.
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(1920, 1080));
    try {
        // guardar la imagen en el disco.
        slideImage.save("slide1.jpeg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Reemplazo de código antiguo con API Moderna**

En general, deberá reemplazar las llamadas que usan [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) e ImageIO con los nuevos métodos que usan [IImage](https://reference.aspose.com/slides/es/java/com.aspose.slides/iimage/).

API heredada/obsoleta:
``` java
BufferedImage slideImage = pres.getSlides().get_Item(0).getThumbnail(new Dimension(1920, 1080));
try {
    ImageIO.write(slideImage, "PNG", new File("image.png"));
} catch (IOException e) {
    e.printStackTrace();
}
```
API Moderna:
``` java
IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(1920, 1080));
try {
    slideImage.save("image.png", ImageFormat.Png);
} finally {
    if (slideImage != null) slideImage.dispose();
}
```

### **Obtención de una miniatura de diapositiva**

API heredada/obsoleta:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    BufferedImage slideImage = pres.getSlides().get_Item(0).getThumbnail();
    try {
        ImageIO.write(slideImage, "PNG", new File("slide1.png"));
    } catch (IOException e) {
        e.printStackTrace();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

API Moderna:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    IImage slideImage = pres.getSlides().get_Item(0).getImage();
    try {
        slideImage.save("slide1.png", ImageFormat.Png);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **Obtención de una miniatura de forma**

API heredada/obsoleta:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    BufferedImage shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThumbnail();
    try {
        ImageIO.write(shapeImage, "PNG", new File("shape.png"));
    } catch (IOException e) {
        e.printStackTrace();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

API Moderna:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    IImage shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    try {
        shapeImage.save("shape.png");
    } finally {
        if (shapeImage != null) shapeImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **Obtención de una miniatura de presentación**

API heredada/obsoleta:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    BufferedImage[] bitmaps = pres.getThumbnails(new RenderingOptions(), new Dimension(1980, 1028));
    for (int index = 0; index < bitmaps.length; index++)
    {
        try 
        {
            BufferedImage thumbnail = bitmaps[index];
            ImageIO.write(thumbnail, "PNG", new File("slide" + index + ".png"));
        } 
        catch (IOException e) 
        {
            e.printStackTrace();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

API Moderna:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    IImage[] images = pres.getImages(new RenderingOptions(), new Dimension(1980, 1028));
    try
    {
        for (int index = 0; index < images.length; index++)
        {
            IImage thumbnail = images[index];
            thumbnail.save("slide" + index + ".png", ImageFormat.Png);
        }
    }
    finally
    {
        for (IImage image : images)
        {
            image.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **Añadir una imagen a una presentación**

API heredada/obsoleta:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage = null;
    try {
        BufferedImage bufferedImages = ImageIO.read(new File("image.png"));
        ppImage = pres.getImages().addImage(bufferedImages);
    } catch (IOException e) {
        e.printStackTrace();
    }

    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
} finally {
    if (pres != null) pres.dispose();
}
```

API Moderna:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage;
    IImage image = Images.fromFile("image.png");
    try {
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Métodos obsoletos y su reemplazo en la API Moderna**

### **Presentación**
| Firma del método | Firma del método de reemplazo |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Forma**
| Firma del método | Firma del método de reemplazo |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Diapositiva**
| Firma del método | Firma del método de reemplazo |
|----------------------------------------------------------------------|-----------------------------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(float scaleX, float scaleY) | public final IImage getImage(float scaleX, float scaleY) |
| public final BufferedImage getThumbnail(IRenderingOptions options) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, float scaleX, float scaleY) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, Dimension imageSize) | public final IImage getImage(IRenderingOptions options, Dimension imageSize) |
| public final BufferedImage getThumbnail(ITiffOptions options) | public final IImage getImage(ITiffOptions options) |
| public final BufferedImage getThumbnail(Dimension imageSize) | public final IImage getImage(Dimension imageSize) |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics) | No Modern API replacement |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY) | No Modern API replacement |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize) | No Modern API replacement |

### **Salida**
| Firma del método | Firma del método de reemplazo |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| Firma del método | Firma del método de reemplazo |
|-------------------------------------------|--------------------------------------------|
| public final IPPImage addImage(BufferedImage image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| Firma del método | Firma del método de reemplazo |
|--------------------------------------|-----------------------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| Firma del método | Firma del método de reemplazo |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| Firma del método | Firma del método de reemplazo |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## **Compatibilidad de la API con Graphics2D**

Los métodos con [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) están declarados como obsoletos y no tienen un reemplazo directo en la API Moderna.

Utilice los métodos de renderizado de imágenes de la API Moderna en lugar de la API que renderiza a [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html):

[Slide](https://reference.aspose.com/slides/es/java/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/es/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/es/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/es/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

## **Preguntas frecuentes**

**¿Por qué se eliminó [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)?**

El soporte para [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) está obsoleto en la API pública para unificar el trabajo con renderizado e imágenes, eliminar la dependencia de plataformas específicas y pasar a un enfoque multiplataforma con [IImage](https://reference.aspose.com/slides/es/java/com.aspose.slides/iimage/). Use `getImage` o `getImages` en lugar de renderizar a [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html).

**¿Cuál es el beneficio práctico de [IImage](https://reference.aspose.com/slides/es/java/com.aspose.slides/iimage/) comparado con [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)?**

[IImage](https://reference.aspose.com/slides/es/java/com.aspose.slides/iimage/) unifica el trabajo con imágenes raster y vectoriales y simplifica el guardado en varios formatos mediante [ImageFormat](https://reference.aspose.com/slides/es/java/com.aspose.slides/imageformat/).

**¿Afectará la API Moderna al rendimiento de la generación de miniaturas?**

Cambiar de `getThumbnail` a `getImage` no empeora los escenarios: los nuevos métodos proporcionan las mismas capacidades para producir imágenes con opciones y tamaños, manteniendo el soporte para opciones de renderizado. La ganancia o pérdida específica depende del caso, pero funcionalmente los reemplazos son equivalentes.