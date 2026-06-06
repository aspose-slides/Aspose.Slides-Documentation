---
title: Mejorar el procesamiento de imágenes con la API moderna
linktitle: API moderna
type: docs
weight: 237
url: /es/nodejs-java/modern-api/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Moderniza el procesamiento de imágenes de diapositivas sustituyendo las APIs de imágenes obsoletas por la API Moderna de JavaScript para una automatización fluida de PowerPoint y OpenDocument."
---
## **Introducción**

Históricamente, Aspose Slides ha dependido de java.awt y tiene en la API pública las siguientes clases de allí:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

A partir de la versión 24.4, esta API pública se declara obsoleta.

Para eliminar las dependencias de estas clases, añadimos la llamada "API moderna" — es decir, la API que debe usarse en lugar de la obsoleta, cuyas firmas contienen dependencias de [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html). [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) se declara obsoleta y su soporte se elimina de la API pública de Slides.

En las versiones actuales, trate la API pública que depende de tipos java.awt como heredada/obsoleta. Use la API moderna para nuevo código y cuando migre flujos de trabajo de procesamiento de imágenes existentes.

## **API moderna**

Se añadieron las siguientes clases y enumeraciones a la API pública:

- [IImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/iimage/) – representa la imagen raster o vectorial.  
- [ImageFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/imageformat/) – representa el formato de archivo de la imagen.  
- [Images](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/images/) – métodos para instanciar y trabajar con la clase [IImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/iimage/).

Tenga en cuenta que [IImage] es desechable y su uso debe ir seguido de una llamada a `dispose()` o de otro patrón de eliminación conveniente.

Use `getImage` para renderizar una sola diapositiva o forma. Use `getImages` para renderizar varias diapositivas de la presentación. Use los métodos de [Images](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/images/) para cargar imágenes, `addImage` con [IImage] para añadirlas a una presentación, y `replaceImage` con [IImage] para actualizar una imagen de presentación existente.

Un escenario típico de uso de la nueva API puede verse así:

``` javascript
var pres = new aspose.slides.Presentation();
try {
    var ppImage;
    // instanciar una instancia desechable de IImage desde el archivo en disco.
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        // crear una imagen de PowerPoint añadiendo una instancia de IImage a las imágenes de la presentación.
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // añadir una forma de imagen en la diapositiva #1
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
    // obtener una instancia de IImage que representa la diapositiva #1.
    var slideImage = pres.getSlides().get_Item(0).getImage(size);
    try {
        // guardar la imagen en el disco.
        slideImage.save("slide1.jpeg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Reemplazar el código antiguo con la API moderna**

En general, necesitará sustituir las llamadas que usan [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) y [ImageIO](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html) por los nuevos métodos que usan [IImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/iimage/).

API heredada/obsoleta:
``` javascript
var imageio = java.import("javax.imageio.ImageIO");
var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
var slideImage = pres.getSlides().get_Item(0).getThumbnail(size);
var file = java.newInstanceSync("java.io.File", "image.png");
imageio.write(slideImage, "PNG", file);
```
API moderna:
``` javascript
var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
var slideImage = pres.getSlides().get_Item(0).getImage(size);
slideImage.save("image.png", aspose.slides.ImageFormat.Png);
slideImage.dispose();
```

### **Obtener una miniatura de diapositiva**

API heredada/obsoleta:

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var slideImage = pres.getSlides().get_Item(0).getThumbnail();
    var imageio = java.import("javax.imageio.ImageIO");
    var file = java.newInstanceSync("java.io.File", "slide1.png");
    imageio.write(slideImage, "PNG", file);
} finally {
    if (pres != null) pres.dispose();
}
```

API moderna:

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var slideImage = pres.getSlides().get_Item(0).getImage();
    slideImage.save("slide1.png", aspose.slides.ImageFormat.Png);
    slideImage.dispose();
} finally {
    if (pres != null) pres.dispose();
}
```

### **Obtener una miniatura de forma**

API heredada/obsoleta:

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThumbnail();
    var imageio = java.import("javax.imageio.ImageIO");
    var file = java.newInstanceSync("java.io.File", "shape.png");
    imageio.write(shapeImage, "PNG", file);
} finally {
    if (pres != null) pres.dispose();
}
```

API moderna:

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    shapeImage.save("shape.png");
    shapeImage.dispose();
} finally {
    if (pres != null) pres.dispose();
}
```

### **Obtener una miniatura de presentación**

API heredada/obsoleta:

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var size = java.newInstanceSync("java.awt.Dimension", 1980, 1028);
    var bitmaps = pres.getThumbnails(new aspose.slides.RenderingOptions(), size);
    for (var index = 0; index < bitmaps.length; index++)
    {
        var thumbnail = bitmaps[index];
        var imageio = java.import("javax.imageio.ImageIO");
        var file = java.newInstanceSync("java.io.File", "slide" + index + ".png");
        imageio.write(thumbnail, "PNG", file);
    }
} finally {
    if (pres != null) pres.dispose();
}
```

API moderna:

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var size = java.newInstanceSync("java.awt.Dimension", 1980, 1028);
    var images = pres.getImages(new aspose.slides.RenderingOptions(), size);
    try
    {
        for (var index = 0; index < images.length; index++)
        {
            var thumbnail = images[index];
            thumbnail.save("slide" + index + ".png", aspose.slides.ImageFormat.Png);
        }
    }
    finally
    {
        images.forEach(item => {item.dispose();});
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **Añadir una imagen a una presentación**

API heredada/obsoleta:

``` javascript
var pres = new aspose.slides.Presentation();
try {
    var imageio = java.import("javax.imageio.ImageIO");
    var file = java.newInstanceSync("java.io.File", "image.png");
    var bufferedImages = imageio.read(file);
    var ppImage = pres.getImages().addImage(bufferedImages);

    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
} finally {
    if (pres != null) pres.dispose();
}
```

API moderna:

``` javascript
var pres = new aspose.slides.Presentation();
try {
    var image = aspose.slides.Images.fromFile("image.png");
    var ppImage = pres.getImages().addImage(image);
    image.dispose();

    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Métodos obsoletos y su reemplazo en la API moderna**

### **Presentación**
| Firma del método | Firma del método de reemplazo |
|------------------|-------------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Forma**
| Firma del método | Firma del método de reemplazo |
|------------------|-------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Diapositiva**
| Firma del método | Firma del método de reemplazo |
|------------------|-------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(float scaleX, float scaleY) | public final IImage getImage(float scaleX, float scaleY) |
| public final BufferedImage getThumbnail(IRenderingOptions options) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, float scaleX, float scaleY) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, Dimension imageSize) | public final IImage getImage(IRenderingOptions options, Dimension imageSize) |
| public final BufferedImage getThumbnail(ITiffOptions options) | public final IImage getImage(ITiffOptions options) |
| public final BufferedImage getThumbnail(Dimension imageSize) | public final IImage getImage(Dimension imageSize) |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics) | No hay reemplazo en la API moderna |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY) | No hay reemplazo en la API moderna |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize) | No hay reemplazo en la API moderna |

### **Salida**
| Firma del método | Firma del método de reemplazo |
|------------------|-------------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| Firma del método | Firma del método de reemplazo |
|------------------|-------------------------------|
| public final PPImage addImage(BufferedImage image) | public final PPImage addImage(IImage image) |

### **PPImage**
| Firma del método | Firma del método de reemplazo |
|------------------|-------------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| Firma del método | Firma del método de reemplazo |
|------------------|-------------------------------|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| Firma del método | Firma del método de reemplazo |
|------------------|-------------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## **Compatibilidad de la API con Graphics2D**

Los métodos con [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) se declaran obsoletos y no tienen un reemplazo directo en la API moderna.

Utilice los métodos de renderizado de imágenes de la API moderna en lugar de la API que renderiza a [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html):

[Slide](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

# **Preguntas frecuentes**

**¿Cuál es el beneficio práctico de [IImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/iimage/) frente a [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)?**

[IImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/iimage/) unifica el trabajo con imágenes raster y vectoriales y simplifica el guardado en varios formatos mediante [ImageFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/imageformat/).

**¿Afectará la API moderna al rendimiento de la generación de miniaturas?**

Cambiar de `getThumbnail` a `getImage` no empeora los escenarios: los nuevos métodos proporcionan las mismas capacidades para producir imágenes con opciones y tamaños, manteniendo el soporte para opciones de renderizado. La ganancia o pérdida específica depende del caso, pero funcionalmente los reemplazos son equivalentes.