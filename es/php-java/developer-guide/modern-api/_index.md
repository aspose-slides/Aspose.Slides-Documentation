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
- agregar imagen
- agregar foto
- PHP
- Aspose.Slides
description: "Modernice el procesamiento de imágenes de diapositivas reemplazando las API de imágenes obsoletas con la API Moderna de PHP para una automatización fluida de PowerPoint y OpenDocument."
---

## **Introducción**

Históricamente, Aspose Slides tiene una dependencia de java.awt y tiene en la API pública las siguientes clases de allí:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

A partir de la versión 24.4, esta API pública se declara obsoleta.

Con el fin de eliminar las dependencias de estas clases, añadimos la llamada “API Moderna”, es decir, la API que debe usarse en lugar de la obsoleta, cuyas firmas contienen dependencias en BufferedImage. Graphics2D se declara obsoleta y su soporte se elimina de la API pública de Slides.

La eliminación de la API pública obsoleta con dependencias en System.Drawing será en la versión 24.8.

## **API Moderna**

Se añadieron las siguientes clases y enumeraciones a la API pública:

- IImage - representa la imagen raster o vectorial.
- ImageFormat - representa el formato de archivo de la imagen.
- Images - métodos para instanciar y trabajar con la interfaz IImage.

Tenga en cuenta que IImage es descartable (implementa la interfaz IDisposable y su uso debe envolver‑se en using o descartarse de otra forma conveniente).

Un escenario típico de uso de la nueva API puede verse así:
``` php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\ImageFormat;
use aspose\slides\Images;


$pres = new Presentation();

# instanciar una instancia desechable de IImage desde el archivo en el disco.
$image = Images::fromFile("image.png");

# crear una imagen de PowerPoint agregando una instancia de IImage a las imágenes de la presentación.
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


## **Reemplazando Código Antiguo con la API Moderna**

En general, deberá reemplazar la llamada al método antiguo que usa ImageIO por la nueva.

**Antiguo:**
``` php
$dimension = new Java("java.awt.Dimension", 1920, 1080);
$slideImage = $pres->getSlides()->get_Item(0)->getThumbnail($dimension);
$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "image.png");
$imageio->write($slideImage, "PNG", $javafile);
```

**Nuevo:**
``` php
$dimension = new Java("java.awt.Dimension", 1920, 1080);
$slideImage = $pres->getSlides()->get_Item(0)->getImage($dimension);
$slideImage->save("image.png", ImageFormat::Png);
$slideImage->dispose();
```


### **Obteniendo una Miniatura de Diapositiva**

Código que usa una API obsoleta:
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


### **Obteniendo una Miniatura de Forma**

Código que usa una API obsoleta:
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


### **Obteniendo una Miniatura de Presentación**

Código que usa una API obsoleta:
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


### **Añadiendo una Imagen a una Presentación**

Código que usa una API obsoleta:
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


## **Métodos que Serán Eliminados y su Reemplazo en la API Moderna**

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
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics) | Will be deleted completely |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY) | Will be deleted completely |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize) | Will be deleted completely |

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

## **El Soporte de la API para Graphics2D Será Descontinuado**

Los métodos con [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) se declaran obsoletos y su soporte será eliminado de la API pública.

La parte de la API que lo utiliza será eliminada:

[Slide](https://reference.aspose.com/slides/java/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

## **Preguntas Frecuentes**

**¿Por qué se eliminó java.awt.Graphics2D?**

El soporte para `Graphics2D` se elimina de la API pública para unificar el trabajo con renderizado e imágenes, eliminar vínculos con dependencias específicas de la plataforma y pasar a un enfoque multiplataforma con [IImage](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/). Todos los métodos de renderizado a `Graphics2D` serán eliminados.

**¿Cuál es el beneficio práctico de IImage en comparación con BufferedImage?**

[IImage](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/) unifica el trabajo con imágenes raster y vectoriales y simplifica el guardado en varios formatos mediante [ImageFormat](https://reference.aspose.com/slides/php-java/aspose.slides/imageformat/).

**¿Afectará la API Moderna al rendimiento de generación de miniaturas?**

Cambiar de `getThumbnail` a `getImage` no empeora los escenarios: los nuevos métodos brindan las mismas capacidades para producir imágenes con opciones y tamaños, conservando el soporte para opciones de renderizado. La ganancia o pérdida específica depende del caso, pero funcionalmente los reemplazos son equivalentes.