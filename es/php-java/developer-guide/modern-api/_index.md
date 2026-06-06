---
title: Mejorar el procesamiento de imágenes con la API Moderna
linktitle: API Moderna
type: docs
weight: 237
url: /es/php-java/modern-api/
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
- PHP
- Aspose.Slides
description: "Moderniza el procesamiento de imágenes de diapositivas sustituyendo las API de imágenes obsoletas por la API Moderna de PHP para una automatización fluida de PowerPoint y OpenDocument."
---
## **Introducción**

Históricamente, Aspose Slides tiene una dependencia de **java.awt** y expone en su API pública las siguientes clases de ese paquete:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

A partir de la versión 24.4, esta API pública está declarada como obsoleta.

Para eliminar las dependencias de estas clases, añadimos la llamada “API moderna”, es decir, la API que debe usarse en lugar de la obsoleta, cuyas firmas ya no dependen de [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html). [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) está declarada obsoleta y su soporte se ha eliminado de la API pública de Slides.

En las versiones actuales, trate la API pública que depende de tipos **java.awt** como heredada/obsoleta. Use la API Moderna para código nuevo y al migrar flujos de trabajo de procesamiento de imágenes existentes.

## **API Moderna**

Se añadieron las siguientes clases y enumeraciones a la API pública:

- [IImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/iimage/) – representa la imagen raster o vectorial.
- [ImageFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/imageformat/) – representa el formato de archivo de la imagen.
- [Images](https://reference.aspose.com/slides/es/php-java/aspose.slides/images/) – métodos para instanciar y trabajar con la clase [IImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/iimage/).

Tenga en cuenta que [IImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/iimage/) es desechable (debe liberarse después de su uso).

Utilice `getImage` para renderizar una sola diapositiva o forma. Utilice `getImages` para renderizar varias diapositivas de una presentación. Use los métodos de [Images](https://reference.aspose.com/slides/es/php-java/aspose.slides/images/) para cargar imágenes, `addImage` con [IImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/iimage/) para añadirlas a una presentación, y `replaceImage` con [IImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/iimage/) para actualizar una imagen existente de la presentación.

Un escenario típico de uso de la nueva API puede ser el siguiente:

``` php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\ImageFormat;
use aspose\slides\Images;


$pres = new Presentation();

# instanciar una instancia desechable de IImage desde el archivo en disco.
$image = Images::fromFile("image.png");

# crear una imagen de PowerPoint añadiendo una instancia de IImage a las imágenes de la presentación.
$ppImage = $pres->getImages()->addImage($image);
$image->dispose();

# añadir una forma de imagen en la diapositiva #1
$pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $ppImage);

$dimension = new Java("java.awt.Dimension", 1920, 1080);
# obtener una instancia de IImage que representa la diapositiva #1.
$slideImage = $pres->getSlides()->get_Item(0)->getImage($dimension);

# guardar la imagen en el disco.
$slideImage->save("slide1.jpeg", ImageFormat::Jpeg);
$slideImage->dispose();

$pres->dispose();
```

## **Reemplazo del código antiguo con la API Moderna**

En general, deberá sustituir las llamadas que usan [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) y [ImageIO](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html) por los nuevos métodos que usan [IImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/iimage/).

API heredada/obsoleta:
``` php
$dimension = new Java("java.awt.Dimension", 1920, 1080);
$slideImage = $pres->getSlides()->get_Item(0)->getThumbnail($dimension);
$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "image.png");
$imageio->write($slideImage, "PNG", $javafile);
```
API Moderna:
``` php
$dimension = new Java("java.awt.Dimension", 1920, 1080);
$slideImage = $pres->getSlides()->get_Item(0)->getImage($dimension);
$slideImage->save("image.png", ImageFormat::Png);
$slideImage->dispose();
```

### **Obtener una miniatura de diapositiva**

API heredada/obsoleta:

``` php
use aspose\slides\Presentation;


$pres = new Presentation("pres.pptx");

$slideImage = $pres->getSlides()->get_Item(0)->getThumbnail();

$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "slide1.png");
$imageio->write($slideImage, "PNG", $javafile);

$pres->dispose();
```

API Moderna:

``` php
use aspose\slides\Presentation;
use aspose\slides\ImageFormat;


$pres = new Presentation("pres.pptx");

$slideImage = $pres->getSlides()->get_Item(0)->getImage();
$slideImage->save("slide1.png", ImageFormat::Png);
$slideImage->dispose();

$pres->dispose();
```

### **Obtener una miniatura de forma**

API heredada/obsoleta:

``` php
use aspose\slides\Presentation;


$pres = new Presentation("pres.pptx");

$shapeImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThumbnail();

$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "shape.png");
$imageio->write($shapeImage, "PNG", $javafile);

$pres->dispose();
```

API Moderna:

``` php
use aspose\slides\Presentation;
use aspose\slides\ImageFormat;


$pres = new Presentation("pres.pptx");

$shapeImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage();
$shapeImage->save("shape.png");
$shapeImage->dispose();

$pres->dispose();
```

### **Obtener una miniatura de presentación**

API heredada/obsoleta:

``` php
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;


$pres = new Presentation("pres.pptx");

$renderingOptions = new RenderingOptions();
$dimension = new Java("java.awt.Dimension", 1920, 1080);

$bitmaps = $pres->getThumbnails($renderingOptions, $dimension);
for ($i = 0; $i < count(java_values($bitmaps)); $i++)
{
    $thumbnail = $bitmaps[$i];
    $imageio = new Java("javax.imageio.ImageIO");
    $javafile = new Java("java.io.File", "slide" . $i . ".png");
    $imageio->write($thumbnail, "PNG", $javafile);
}

$pres->dispose();
```

API Moderna:

``` php
use aspose\slides\Presentation;
use aspose\slides\ImageFormat;
use aspose\slides\RenderingOptions;


$pres = new Presentation("pres.pptx");

$renderingOptions = new RenderingOptions();
$dimension = new Java("java.awt.Dimension", 1920, 1080);

$images = $pres->getImages($renderingOptions, $dimension);
for ($i = 0; $i < count(java_values($images)); $i++)
{
    $thumbnail = $images[$i];
    $thumbnail->save("slide" . $i . ".png", ImageFormat::Png);
}

$pres->dispose();
```

### **Añadir una imagen a una presentación**

API heredada/obsoleta:

``` php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;


$pres = new Presentation();

$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "image.png");

$bufferedImages = $imageio->read($javafile);
$ppImage = $pres->getImages()->addImage($bufferedImages);

$pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $ppImage);

$pres->dispose();
```

API Moderna:

``` php
use aspose\slides\Presentation;
use aspose\slides\Images;
use aspose\slides\ShapeType;


$pres = new Presentation();

$image = Images::fromFile("image.png");
$ppImage = $pres->getImages()->addImage($image);
$image->dispose();

$pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $ppImage);

$pres->dispose();
```

## **Métodos obsoletos y su sustitución en la API Moderna**

### **Presentation**
| Firma del método | Firma del método de reemplazo |
|------------------|------------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Shape**
| Firma del método | Firma del método de reemplazo |
|------------------|------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| Firma del método | Firma del método de reemplazo |
|------------------|------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(float scaleX, float scaleY) | public final IImage getImage(float scaleX, float scaleY) |
| public final BufferedImage getThumbnail(IRenderingOptions options) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, float scaleX, float scaleY) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, Dimension imageSize) | public final IImage getImage(IRenderingOptions options, Dimension imageSize) |
| public final BufferedImage getThumbnail(ITiffOptions options) | public final IImage getImage(ITiffOptions options) |
| public final BufferedImage getThumbnail(Dimension imageSize) | public final IImage getImage(Dimension imageSize) |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics) | No hay sustitución en la API Moderna |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY) | No hay sustitución en la API Moderna |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize) | No hay sustitución en la API Moderna |

### **Output**
| Firma del método | Firma del método de reemplazo |
|------------------|------------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| Firma del método | Firma del método de reemplazo |
|------------------|------------------------------|
| public final IPPImage addImage(BufferedImage image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| Firma del método | Firma del método de reemplazo |
|------------------|------------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| Firma del método | Firma del método de reemplazo |
|------------------|------------------------------|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| Firma del método | Firma del método de reemplazo |
|------------------|------------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## **Compatibilidad de la API para Graphics2D**

Los métodos con [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) están declarados como obsoletos y no tienen una sustitución directa en la API Moderna.

Utilice los métodos de renderizado de imágenes de la API Moderna en lugar de la API que renderiza a [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html):

[Slide](https://reference.aspose.com/slides/es/php-java/aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/es/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/es/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/es/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

## **FAQ**

**¿Por qué se eliminó [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)?**

El soporte para [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) se ha declarado obsoleto en la API pública para unificar el trabajo con renderizado e imágenes, eliminar dependencias específicas de la plataforma y pasar a un enfoque multiplataforma con [IImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/iimage/). Utilice `getImage` o `getImages` en lugar de renderizar a [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html).

**¿Cuál es el beneficio práctico de [IImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/iimage/) frente a [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)?**

[IImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/iimage/) unifica el trabajo con imágenes raster y vectoriales y simplifica el guardado en varios formatos mediante [ImageFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/imageformat/).

**¿Afectará la API Moderna al rendimiento de la generación de miniaturas?**

Cambiar de `getThumbnail` a `getImage` no empeora los escenarios: los nuevos métodos proporcionan las mismas capacidades para producir imágenes con opciones y tamaños, manteniendo el soporte para opciones de renderizado. La ganancia o pérdida específica depende del caso, pero funcionalmente los reemplazos son equivalentes.