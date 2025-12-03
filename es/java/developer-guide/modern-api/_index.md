---
title: Mejorar el procesamiento de imágenes con la API Moderna
linktitle: API Moderna
type: docs
weight: 237
url: /es/java/modern-api/
keywords:
- API moderna
- dibujo
- miniatura de diapositiva
- diapositiva a imagen
- miniatura de forma
- forma a imagen
- miniatura de presentación
- presentación a imágenes
- añadir imagen
- añadir foto
- Java
- Aspose.Slides
description: "Moderniza el procesamiento de imágenes de diapositivas reemplazando las API de imágenes obsoletas con la API Moderna de Java para una automatización fluida de PowerPoint y OpenDocument."
---

## **Introducción**

Históricamente, Aspose Slides tiene una dependencia de java.awt y en la API pública incluye las siguientes clases de allí:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

A partir de la versión 24.4, esta API pública se declara obsoleta.

Para eliminar la dependencia de estas clases, añadimos la llamada “API Moderna”, es decir, la API que debe usarse en lugar de la obsoleta, cuyas firmas contienen dependencias de BufferedImage. Graphics2D se declara obsoleta y su soporte se elimina de la API pública de Slides.

La eliminación de la API pública obsoleta con dependencias en System.Drawing será en la versión 24.8.

## **API Moderna**

Se añadieron las siguientes clases y enumeraciones a la API pública:

- IImage - representa la imagen raster o vectorial.
- ImageFormat - representa el formato de archivo de la imagen.
- Images - métodos para instanciar y trabajar con la interfaz IImage.

Tenga en cuenta que IImage es descartable (implementa la interfaz IDisposable y su uso debe envolverse en una instrucción using o desecharse de otra forma conveniente).

Un escenario típico de uso de la nueva API puede verse como sigue:
``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage;
    // instanciar una instancia desechable de IImage desde el archivo en el disco.
    IImage image = Images.fromFile("image.png");
    try {
        // crear una imagen de PowerPoint añadiendo una instancia de IImage a las imágenes de la presentación.
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // añadir una forma de imagen en la diapositiva #1
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // obtener una instancia de IImage que representa la diapositiva #1.
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


## **Reemplazando Código Antiguo con la API Moderna**

En general, deberás reemplazar la llamada al método antiguo que usa ImageIO por la nueva.

**Antiguo:**
``` java
BufferedImage slideImage = pres.getSlides().get_Item(0).getThumbnail(new Dimension(1920, 1080));
try {
    ImageIO.write(slideImage, "PNG", new File("image.png"));
} catch (IOException e) {
    e.printStackTrace();
}
```

**Nuevo:**
``` java
IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(1920, 1080));
try {
    slideImage.save("image.png", ImageFormat.Png);
} finally {
    if (slideImage != null) slideImage.dispose();
}
```


### **Obteniendo una Miniatura de Diapositiva**

Código usando una API obsoleta:
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


### **Obteniendo una Miniatura de Forma**

Código usando una API obsoleta:
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


### **Obteniendo una Miniatura de Presentación**

Código usando una API obsoleta:
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


### **Añadiendo una Imagen a una Presentación**

Código usando una API obsoleta:
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


## **Métodos que serán Eliminados y sus Reemplazos en la API Moderna**

### **Presentación**
| Firma del Método | Firma del Método de Reemplazo |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options)                   |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY)   |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Forma**
| Firma del Método | Firma del Método de Reemplazo |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Diapositiva**
| Firma del Método | Firma del Método de Reemplazo |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(float scaleX, float scaleY) | public final IImage getImage(float scaleX, float scaleY) |
| public final BufferedImage getThumbnail(IRenderingOptions options) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, float scaleX, float scaleY) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, Dimension imageSize) | public final IImage getImage(IRenderingOptions options, Dimension imageSize) |
| public final BufferedImage getThumbnail(ITiffOptions options) | public final IImage getImage(ITiffOptions options) |
| public final BufferedImage getThumbnail(Dimension imageSize) | public final IImage getImage(Dimension imageSize) |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics) | Se eliminará completamente |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY) | Se eliminará completamente |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize) | Se eliminará completamente |

### **Salida**
| Firma del Método | Firma del Método de Reemplazo |
|-----------------------------------------------|---------------------------------------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| Firma del Método | Firma del Método de Reemplazo |
|-----------------------------------------------|---------------------------------------------------------|
| public final IPPImage addImage(BufferedImage image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| Firma del Método | Firma del Método de Reemplazo |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| Firma del Método | Firma del Método de Reemplazo |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| Firma del Método | Firma del Método de Reemplazo |
|-----------------------------------------------|---------------------------------------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## **El Soporte de la API para Graphics2D será Descontinuado**

Los métodos con [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) se declaran obsoletos y su soporte se eliminará de la API pública.

La parte de la API que lo usa será eliminada:

[Slide](https://reference.aspose.com/slides/java/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

## **Preguntas frecuentes**

**¿Por qué se eliminó java.awt.Graphics2D?**

Se elimina el soporte para `Graphics2D` de la API pública para unificar el trabajo con renderizado e imágenes, eliminar dependencias específicas de la plataforma y pasar a un enfoque multiplataforma con [IImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/). Todos los métodos de renderizado a `Graphics2D` serán eliminados.

**¿Cuál es el beneficio práctico de IImage comparado con BufferedImage?**

[IImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/) unifica el trabajo con imágenes raster y vectoriales y simplifica el guardado en varios formatos mediante [ImageFormat](https://reference.aspose.com/slides/java/com.aspose.slides/imageformat/).

**¿Afectará la API Moderna al rendimiento de generación de miniaturas?**

Cambiar de `getThumbnail` a `getImage` no empeora los escenarios: los nuevos métodos proporcionan las mismas capacidades para producir imágenes con opciones y tamaños, manteniendo el soporte para opciones de renderizado. La ganancia o pérdida específica depende del caso, pero funcionalmente los reemplazos son equivalentes.