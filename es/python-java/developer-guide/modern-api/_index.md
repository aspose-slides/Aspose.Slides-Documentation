---
title: Mejorar el procesamiento de imágenes con la API Moderna en Python
linktitle: API Moderna
type: docs
weight: 237
url: /es/python-java/modern-api/
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
- Python
- Java
- Aspose.Slides
description: "Modernice el procesamiento de imágenes en Python vía Java: renderice diapositivas y formas, añada imágenes, y migre llamadas de imagen obsoletas a la API Moderna de Aspose.Slides."
---
## **Introducción**

Aspose.Slides for Python via Java accede a la biblioteca Java a través de JPype. Su API heredada de procesamiento de imágenes utilizaba [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) y [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) de `java.awt`.

La biblioteca Java dejó de usar estas APIs de imágenes a partir de la versión 24.4. La API Moderna utiliza [IImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/iimage/) para cargar, renderizar y guardar imágenes. Utilícela para código Python nuevo y al migrar flujos de trabajo de procesamiento de imágenes existentes.

{{% alert color="info" title="Note" %}}
Los nombres de método antiguos que aparecen a continuación son referencias de migración. Ya no están disponibles en las versiones actuales. Los ejemplos ejecutables usan la API Moderna.

Este cambio no elimina todos los tipos `java.awt`: las sobrecargas de tamaño de imagen y color de patrón siguen aceptando [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) y [Color](https://docs.oracle.com/javase/8/docs/api/java/awt/Color.html).
{{% /alert %}}

## **API Moderna**

Los principales tipos de procesamiento de imágenes son:

- [IImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/iimage/) — representa una imagen raster o vectorial.  
- [ImageFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/imageformat/) — proporciona constantes de formatos de archivo de imagen.  
- [Images](https://reference.aspose.com/slides/es/python-java/aspose.slides/images/) — crea imágenes, por ejemplo con [Images.fromFile](https://reference.aspose.com/slides/es/python-java/aspose.slides/images/#fromFile).

Utilice [Slide.getImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/slide/#getImage) o [Shape.getImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#getImage) para renderizar una diapositiva o forma. Utilice [Presentation.getImages](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getImages) con opciones de renderizado para renderizar varias diapositivas. La sobrecarga sin argumentos devuelve la colección de imágenes de la presentación.

Cargue una imagen con [Images.fromFile](https://reference.aspose.com/slides/es/python-java/aspose.slides/images/#fromFile), añádala con [ImageCollection.addImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/imagecollection/#addImage) o actualice una imagen existente de la presentación con [PPImage.replaceImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/ppimage/#replaceImage). Ambas operaciones de colección de imágenes aceptan [IImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/iimage/).

Libere cada imagen que cargue o renderice llamando a su método `dispose` dentro de un bloque `finally`. Libere la presentación con [Presentation.dispose](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#dispose).

### **Preparar el entorno Python**

Instale los paquetes como se describe en [Installation](/slides/es/python-java/installation/). Cada ejemplo importa `asposeslides` antes de iniciar la JVM, y luego importa la API una vez que la JVM está en ejecución. Los ejemplos dejan la JVM en marcha para que pueda reutilizarse. Consulte [Limitations and API Differences](/slides/es/python-java/limitations-and-api-differences/#import-the-library) para obtener orientación sobre el ciclo de vida del cuaderno y de la JVM.

Los ejemplos que abren `pres.pptx` requieren una presentación en el directorio de trabajo. Los ejemplos que cargan `image.png` requieren un archivo de imagen existente.

### **Cargar una imagen y renderizar una diapositiva**

Este ejemplo añade una imagen a la primera diapositiva y guarda la diapositiva como una imagen JPEG. [IImage.save](https://reference.aspose.com/slides/es/python-java/aspose.slides/iimage/#save) escribe la imagen renderizada en el formato especificado.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Images, Presentation, ShapeType
from java.awt import Dimension

presentation = Presentation()
try:
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)

    image_size = Dimension(1920, 1080)
    slide_image = slide.getImage(image_size)
    try:
        slide_image.save("slide1.jpeg", ImageFormat.Jpeg)
    finally:
        slide_image.dispose()
finally:
    presentation.dispose()
```

## **Reemplazar código antiguo con la API Moderna**

Reemplace las llamadas heredadas a miniaturas con métodos que devuelvan [IImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/iimage/), y luego guarde el resultado con [IImage.save](https://reference.aspose.com/slides/es/python-java/aspose.slides/iimage/#save). Esto elimina la necesidad de pasar imágenes renderizadas a [ImageIO.write](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html#write-java.awt.image.RenderedImage-java.lang.String-java.io.File-).

### **Renderizar una diapositiva con un tamaño especificado**

Reemplace la llamada heredada `slide.getThumbnail(image_size)` por [Slide.getImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/slide/#getImage) usando el mismo tamaño de imagen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        image_size = Dimension(1920, 1080)
        slide_image = presentation.getSlides().get_Item(0).getImage(image_size)
        try:
            slide_image.save("image.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

### **Obtener una miniatura de diapositiva**

Reemplace la llamada heredada `slide.getThumbnail()` por [Slide.getImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/slide/#getImage) sin argumentos.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        slide_image = presentation.getSlides().get_Item(0).getImage()
        try:
            slide_image.save("slide1.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

### **Obtener una miniatura de forma**

Reemplace la llamada heredada `shape.getThumbnail()` por [Shape.getImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#getImage). Verifique que la diapositiva contenga una forma antes de acceder a ella.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        slide = presentation.getSlides().get_Item(0)
        if slide.getShapes().size() > 0:
            shape_image = slide.getShapes().get_Item(0).getImage()
            try:
                shape_image.save("shape.png", ImageFormat.Png)
            finally:
                shape_image.dispose()
        else:
            print("The first slide contains no shapes.")
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

### **Obtener una miniatura de presentación**

Reemplace la llamada heredada `presentation.getThumbnails(options, image_size)` por [Presentation.getImages](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getImages). Utilice [RenderingOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/renderingoptions/) para configurar el renderizado.

Itere directamente sobre la matriz devuelta con `enumerate` de Python. Libere cada imagen devuelta en un bloque `finally` para que una falla al guardar no deje imágenes sin liberar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, RenderingOptions
from java.awt import Dimension

presentation = Presentation("pres.pptx")
try:
    rendering_options = RenderingOptions()
    image_size = Dimension(1920, 1080)
    images = presentation.getImages(rendering_options, image_size)
    try:
        for index, image in enumerate(images, start=1):
            image.save(f"slide{index}.png", ImageFormat.Png)
    finally:
        for image in images:
            image.dispose()
finally:
    presentation.dispose()
```

### **Añadir una imagen a una presentación**

Reemplace la carga mediante [ImageIO.read](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html#read-java.io.File-) por [Images.fromFile](https://reference.aspose.com/slides/es/python-java/aspose.slides/images/#fromFile), y luego pase la imagen resultante a [ImageCollection.addImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/imagecollection/#addImage). Añada la imagen a la diapositiva y guarde la presentación.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)
    presentation.save("picture.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Métodos obsoletos y sus sustitutos en la API Moderna**

Las tablas utilizan notación de llamada de Python. Los nombres en la columna heredada identifican APIs eliminadas; use los métodos de sustitución enlazados. Los métodos modernos de renderizado de imágenes devuelven objetos [IImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/iimage/) en lugar de imágenes Java en búfer.

### **Presentation**

[Presentation.getImages](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getImages) devuelve una matriz de imágenes renderizadas cuando se llama con opciones de renderizado.

| Llamada heredada | Reemplazo moderno |
| --- | --- |
| `presentation.getThumbnails(options)` | [getImages](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getImages) con `options` |
| `presentation.getThumbnails(options, scale_x, scale_y)` | [getImages](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getImages) con `options, scale_x, scale_y` |
| `presentation.getThumbnails(options, slides)` | [getImages](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getImages) con `options, slides` |
| `presentation.getThumbnails(options, slides, scale_x, scale_y)` | [getImages](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getImages) con `options, slides, scale_x, scale_y` |
| `presentation.getThumbnails(options, slides, image_size)` | [getImages](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getImages) con `options, slides, image_size` |
| `presentation.getThumbnails(options, image_size)` | [getImages](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getImages) con `options, image_size` |

Aquí, `slides` es un `int[]` de Java con números de diapositiva base‑uno; créelo con `jpype.JArray(jpype.JInt)([1, 3])` para seleccionar las diapositivas 1 y 3. `image_size` es un [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html).

### **Shape**

| Llamada heredada | Reemplazo moderno |
| --- | --- |
| `shape.getThumbnail()` | [getImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#getImage) sin argumentos |
| `shape.getThumbnail(bounds, scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#getImage) con `bounds, scale_x, scale_y` |

### **Slide**

| Llamada heredada | Reemplazo moderno |
| --- | --- |
| `slide.getThumbnail()` | [getImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/slide/#getImage) sin argumentos |
| `slide.getThumbnail(scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/slide/#getImage) con `scale_x, scale_y` |
| `slide.getThumbnail(options)` | [getImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/slide/#getImage) con `options` |
| `slide.getThumbnail(options, scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/slide/#getImage) con `options, scale_x, scale_y` |
| `slide.getThumbnail(options, image_size)` | [getImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/slide/#getImage) con `options, image_size` |
| `slide.getThumbnail(tiff_options)` | [getImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/slide/#getImage) con `tiff_options` |
| `slide.getThumbnail(image_size)` | [getImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/slide/#getImage) con `image_size` |
| `slide.renderToGraphics(options, graphics)` | No hay sustituto directo; renderice a una imagen en su lugar |
| `slide.renderToGraphics(options, graphics, scale_x, scale_y)` | No hay sustituto directo; renderice a una imagen en su lugar |
| `slide.renderToGraphics(options, graphics, image_size)` | No hay sustituto directo; renderice a una imagen en su lugar |

Aquí, `options` es [RenderingOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/renderingoptions/), y `tiff_options` es [TiffOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/tiffoptions/).

### **Output**

| Llamada heredada | Reemplazo moderno |
| --- | --- |
| `output.add(path, buffered_image)` | [Output.add](https://reference.aspose.com/slides/es/python-java/aspose.slides/output/#add) con `path, image`, donde `image` es [IImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/iimage/) |

### **ImageCollection**

| Llamada heredada | Reemplazo moderno |
| --- | --- |
| `collection.addImage(buffered_image)` | [ImageCollection.addImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/imagecollection/#addImage) con un [IImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/iimage/) |

### **PPImage**

| Llamada heredada | Reemplazo moderno |
| --- | --- |
| `picture.getSystemImage()` | [PPImage.getImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/ppimage/#getImage) |

Para reemplazar el contenido de una imagen de presentación existente, use [PPImage.replaceImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/ppimage/#replaceImage) con un [IImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/iimage/).

### **PatternFormat**

| Llamada heredada | Reemplazo moderno |
| --- | --- |
| `pattern.getTileImage(style_color)` | [PatternFormat.getTile](https://reference.aspose.com/slides/es/python-java/aspose.slides/patternformat/#getTile) con `style_color` |
| `pattern.getTileImage(background, foreground)` | [PatternFormat.getTile](https://reference.aspose.com/slides/es/python-java/aspose.slides/patternformat/#getTile) con `background, foreground` |

Los argumentos de color permanecen objetos Java [Color](https://docs.oracle.com/javase/8/docs/api/java/awt/Color.html).

### **PatternFormatEffectiveData**

Para los datos de patrón efectivos devueltos por la API Java a través de JPype, el método de sustitución conserva el nombre `getTileIImage`.

| Llamada heredada | Reemplazo moderno |
| --- | --- |
| `effective_pattern.getTileImage(background, foreground)` | `effective_pattern.getTileIImage(background, foreground)`, devolviendo [IImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/iimage/) |

## **Compatibilidad de la API con Graphics2D**

Las sobrecargas heredadas de `renderToGraphics` dibujaban en un contexto [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) suministrado por el llamador. La API Moderna no tiene sustituto directo que dibuje en ese contexto.

Utilice [Slide.getImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/slide/#getImage) para renderizar una diapositiva o [Presentation.getImages](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getImages) para renderizar varias diapositivas, y luego guarde las imágenes devueltas con [IImage.save](https://reference.aspose.com/slides/es/python-java/aspose.slides/iimage/#save). Las aplicaciones que combinaban el renderizado de diapositivas con dibujo Java personalizado deberán adaptar su paso de composición.

## **Preguntas frecuentes**

**¿Por qué se sustituyó la antigua API de imágenes de Java?**

La API Moderna traslada la carga, el renderizado y el guardado de imágenes a [IImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/iimage/). Esto proporciona una abstracción de imagen común en lugar de exponer imágenes Java en búfer o un contexto gráfico Java.

**¿Sigo necesitando Java y JPype?**

Sí. Aspose.Slides for Python via Java sigue ejecutándose sobre la JVM. La API Moderna solo cambia las llamadas de procesamiento de imágenes, no los requisitos de tiempo de ejecución. Consulte [System Requirements](/slides/es/python-java/system-requirements/).

**¿Cómo libero las imágenes en Python?**

Llame a `dispose` sobre cada imagen que cargue o renderice dentro de un bloque `finally`. Si renderiza varias diapositivas, libere cada imagen en la matriz devuelta. Libere la presentación por separado con [Presentation.dispose](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#dispose).

**¿Cambiar a la API Moderna garantiza una generación de miniaturas más rápida?**

No se garantiza ninguna mejora de rendimiento. Los reemplazos admiten opciones de renderizado, escalado y tamaños de imagen; mida el rendimiento con sus presentaciones y configuraciones de salida.

**¿Por qué el método de obtención de imágenes a veces devuelve una colección?**

[Presentation.getImages](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getImages) sin argumentos devuelve las imágenes incrustadas de la presentación. Sus sobrecargas con opciones de renderizado devuelven imágenes de diapositivas renderizadas.